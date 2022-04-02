using backend.Interfaces;
using backend.Data;
using backend.DTO;
using Microsoft.EntityFrameworkCore;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using backend.Enums;
using backend.Entities;

namespace backend.Services
{
    public class AssetService : IAssetService
    {
        private MyDbContext _context;
        public AssetService(MyDbContext context)
        {
            _context = context;
        }
        public async Task AddAsset(AssetDTO asset, int categoryId)
        {
            try
            {
                var foundCategory = await _context.Categories.FindAsync(categoryId);
                int code = _context.Assets.ToList().Count + 1;
                if (foundCategory != null)
                {
                    DateTime dateTimeParseResult;
                    AssetState enumParseResult;
                    Asset newAsset = new Asset
                    {
                        CategoryId = categoryId,
                        CategoryName = foundCategory.CategoryName,
                        AssetName = asset.AssetName,
                        AssetCode = foundCategory.Perfix + "00000" + code.ToString(),
                        Specification = asset.Specification,
                        InstalledDate = DateTime.TryParse(asset.InstalledDate, out dateTimeParseResult)
                            ? dateTimeParseResult
                            : DateTime.Now,
                        AssetState = Enum.TryParse(asset.AssetState, out enumParseResult)
                            ? enumParseResult
                            : AssetState.Available,
                    };
                    await _context.Assets.AddAsync(newAsset);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task UpdateAsset(AssetDTO asset, int id)
        {
            var foundAsset = await _context.Assets.FindAsync(id);
            if (foundAsset != null)
            {
                DateTime dateTimeParseResult;
                AssetState enumParseResult;

                foundAsset.AssetName = asset.AssetName;
                foundAsset.CategoryId = asset.CategoryId;
                foundAsset.CategoryName = asset.CategoryName;
                foundAsset.Specification = asset.Specification;
                foundAsset.InstalledDate = DateTime.TryParse(asset.InstalledDate, out dateTimeParseResult)
                            ? dateTimeParseResult
                            : DateTime.Now;
                foundAsset.AssetState = Enum.TryParse(asset.AssetState, out enumParseResult)
                            ? enumParseResult
                            : AssetState.Available;

                _context.Assets.Update(foundAsset);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsset(int id)
        {
            var foundAsset = await _context.Assets.FindAsync(id);
            if (foundAsset != null)
            {
                _context.Assets.Remove(foundAsset);
                await _context.SaveChangesAsync();
            }
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
    }
}