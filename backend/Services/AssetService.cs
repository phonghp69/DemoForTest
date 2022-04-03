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
        public async Task AddAsset(AssetDTO asset)
        {
            try
            {
                var foundCategory = await _context.Categories.FindAsync(asset.CategoryId);
                int code = _context.Assets.ToList().Count + 1;
                if (foundCategory != null)
                {
                    DateTime dateTimeParseResult;
                    AssetState enumParseResult;
                    Asset newAsset = new Asset
                    {
                        CategoryId = asset.CategoryId,
                        CategoryName = foundCategory.CategoryName,
                        AssetName = asset.AssetName,
                        AssetCode = foundCategory.Perfix + "0000" + code.ToString(),
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
            try
            {
                var foundCategory = await _context.Categories.FindAsync(asset.CategoryId);
                var foundAsset = await _context.Assets.FindAsync(id);
                if (foundAsset != null || foundCategory != null)
                {
                    DateTime dateTimeParseResult;
                    AssetState enumParseResult;
                    //Enter new data for founded asset
                    foundAsset.AssetName = asset.AssetName;
                    foundAsset.CategoryId = asset.CategoryId;
                    foundAsset.CategoryName = foundCategory.CategoryName;
                    foundAsset.AssetCode = foundCategory.Perfix + "0000" + foundAsset.AssetId.ToString();
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
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task DeleteAsset(int id)
        {
            try
            {
                var foundAssigment = _context.Assignments.FirstOrDefault(x => x.AssetId == id);
                var foundAsset = await _context.Assets.FindAsync(id);
                if (foundAsset != null && foundAssigment == null)
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