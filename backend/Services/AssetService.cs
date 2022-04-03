using backend.Interfaces;
using backend.Data;
using backend.DTO;
using Microsoft.EntityFrameworkCore;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using backend.Enums;
using backend.Entities;
using backend.Models.Assets;
using backend.Repositories;

namespace backend.Services
{
    public class AssetService : IAssetService
    {
        private MyDbContext _context;
        private readonly IAssetRepository _assetRepository;
        public AssetService(MyDbContext context, IAssetRepository assetRepository)
        {
            _context = context;
            _assetRepository = assetRepository;
        }

        public async Task AddAsset(AssetCreateModel asset, string location)
        {
            await _assetRepository.AddAsset(asset, location);
        }

        public async Task UpdateAsset(AssetUpdateModel asset, int assetId)
        {
            await _assetRepository.UpdateAsset(asset, assetId);
        }
        public async Task DeleteAsset(int id)
        {
            await _assetRepository.DeleteAsset(id);
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