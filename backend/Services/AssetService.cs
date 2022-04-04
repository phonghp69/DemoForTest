using backend.Interfaces;
using backend.Data;
using backend.DTO;
using Microsoft.EntityFrameworkCore;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Assets;
using backend.Entities;
using backend.Helpers;
using backend.Enums;

namespace backend.Services
{
    public class AssetService : IAssetService
    {
        private MyDbContext _context;
        public AssetService(MyDbContext context)
        {
            _context = context;
        }

        private bool CheckInstalledDate(DateTime date)
        {
            if (DateTime.Compare(DateTime.Now, date) < 0)
            {
                return false;
            }
            return true;
        }

        private bool CheckValidCategory(int categoryId)
        {
            return _context.Categories.Any(c => c.CategoryId == categoryId);
        }

        private string GenerateAssetCode(int categoryId)
        {
            var prefix = _context.Categories.Find(categoryId).Perfix;
            var sameCatalogue = _context.Assets.Where(a => a.CategoryId == categoryId);
            if (sameCatalogue.Count() == 0)
            {
                return prefix + "000001";
            }
            else
            {
                var lastAssetCode = sameCatalogue.OrderByDescending(o => o.AssetId).FirstOrDefault()?.AssetCode;
                var lastAssetId = Convert.ToInt32(lastAssetCode?.Substring(lastAssetCode.Length - 6)) + 1;
                return prefix + String.Format("{0,0:D6}", lastAssetId++);
            }
        }

        public async Task AddAsset(AssetCreateModel asset, string location)
        {
            try
            {
                if (!CheckValidCategory(asset.CategoryId)) throw new AppException("CategoryId is not valid");
                if (!CheckInstalledDate(asset.InstalledDate)) throw new AppException("Installed Date must not be in the future");
                var foundCategory = await _context.Categories.FindAsync(asset.CategoryId);
                if (foundCategory != null)
                {
                    var newAsset = new Asset
                    {
                        AssetCode = GenerateAssetCode(asset.CategoryId),
                        AssetName = asset.AssetName,
                        CategoryId = asset.CategoryId,
                        CategoryName = foundCategory.CategoryName,
                        Specification = asset.Specification,
                        InstalledDate = asset.InstalledDate,
                        Location = location,
                        AssetState = asset.AssetState.Equals("Available") ? AssetState.Available : AssetState.NotAvailable
                    };
                    await _context.Assets.AddAsync(newAsset);
                    await _context.SaveChangesAsync();
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateAsset(AssetUpdateModel asset, int assetId)
        {
            var foundAsset = await _context.Assets.FindAsync(assetId);
            var foundCategory = await _context.Categories.FindAsync(asset.CategoryId);
            if (foundAsset != null)
            {
                foundAsset.AssetName = asset.AssetName;
                foundAsset.CategoryId = asset.CategoryId;
                foundAsset.CategoryName = foundAsset.CategoryName;
                foundAsset.Specification = asset.Specification;

                if (asset.AssetState.Equals("Not Available"))
                {
                    foundAsset.AssetState = AssetState.NotAvailable;
                }
                else if (asset.AssetState.Equals("Waiting For Recycle"))
                {
                    foundAsset.AssetState = AssetState.WaitingForRecycle;
                }
                else if (asset.AssetState.Equals("Recycled"))
                {
                    foundAsset.AssetState = AssetState.Recycled;
                }
                else
                {
                    foundAsset.AssetState = AssetState.Available;
                }

                _context.Assets.Update(foundAsset);
                await _context.SaveChangesAsync();
            };

        }

        public async Task<ActionResult<AssetDTO>> GetAsset(int id)
        {
            if (_context.Assets != null)
            {
                try
                {
                    var foundAsset = await _context.Assets.FindAsync(id);
                    if (foundAsset != null)
                        return new OkObjectResult(foundAsset.AssetEntityToDTO());
                    else
                        return new NotFoundResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }

        public async Task<ActionResult<List<AssetDTO>>> GetAllAsset()
        {
            if (_context.Assets != null)
            {
                try
                {
                    var assets = await _context.Assets
                        .Include(c => c.Category)
                        .Select(asset => asset.AssetEntityToDTO())
                        .ToListAsync();
                    return new OkObjectResult(assets);
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            return new NoContentResult();
        }


        public async Task DeleteAsset(int id)
        {
            try
            {
                var foundAsset = await _context.Assets.FindAsync(id);
                if(foundAsset != null)
                {
                    _context.Assets.Remove(foundAsset);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {  
                throw e;
            }
        }
    }
}