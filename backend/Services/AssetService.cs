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
        public async Task AddAsset(int categoryId, AssetDTO assetDTO)
        {
            try
            {
                var foundCategory = await _context.Categories.FindAsync(categoryId);
                if (foundCategory != null)
                {
                    AssetDTO dto = new AssetDTO()
                    {
                        AssetId = assetDTO.AssetId,
                        CategoryId = categoryId,
                        CategoryName = foundCategory.CategoryName,
                        AssetState = AssetState.Availiable.ToString(),
                        AssetName = assetDTO.AssetName,
                        AssetCode = assetDTO.AssetCode,

                    };
                    Asset  newAsset = new Asset(){
                        AssetId = dto.AssetId,
                        CategoryId = categoryId,
                        CategoryName = foundCategory.CategoryName,
                        AssetState = AssetState.Availiable,
                        AssetName = dto.AssetName,
                        AssetCode = dto.AssetCode,
                    };
                    await _context.AddAsync(newAsset);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        public async Task<ActionResult> UpdateAsset(AssetDTO asset, int id)
        {
            if (_context.Assets != null)
            {
                try
                {
                    var foundAsset = await _context.Assets.FindAsync(id);
                    if (foundAsset != null)
                    {
                        foundAsset = asset.AssetDTOToEntity();
                        _context.Assets.Update(foundAsset);
                        await _context.SaveChangesAsync();
                        return new OkResult();
                    }
                    else
                        return new NotFoundResult();
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            else
                return new NoContentResult();
        }
        public async Task<ActionResult> DeleteAsset(int id)
        {
            if (_context.Assets != null)
            {
                try
                {
                    var foundAsset = await _context.Assets.FindAsync(id);
                    if (foundAsset != null)
                    {
                        _context.Assets.Remove(foundAsset);
                        await _context.SaveChangesAsync();
                        return new OkResult();
                    }
                    else
                    {
                        return new NotFoundResult();
                    }
                }
                catch (Exception e)
                {
                    return new BadRequestObjectResult(e);
                }
            }
            else
                return new NoContentResult();
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
        // public async Task<ActionResult<List<AssetInforDTO>>> GetListAssetInfor(){
        //     if (_context.Categories !=null && _context.Assets !=null){
        //         try{
        //             var categorys = await _context.Categories
        //                 .Include(c=>c.Assets)
        //                 .Select(category=>category.AssetInforDTO())
        //                 .ToListAsync();
        //             return new OkObjectResult( categorys);
        //         }
        //     }

        // }

        public async Task<AssetInforDTO> GetAssetInfor(int id)
        {
            AssetState enumParseResult;
            var foundAsset = await _context.Assets.FindAsync(id);
            var foundCategory = await _context.Categories.FindAsync(foundAsset.CategoryId);
            if (foundCategory != null && foundCategory != null)
            {
                AssetInforDTO dTO = new AssetInforDTO()
                {
                    AssetId = foundAsset.AssetId,
                    AssetCode = foundAsset.AssetCode,
                    CategoryName = foundCategory.CategoryName,
                    AssetName = foundAsset.AssetName,
                    AssetState = ((AssetState)foundAsset.AssetState).ToString()
                };
                return dTO;
            }
            return null;
        }
        // public async Task<ActionResult<List<AssetInforDTO>>> GetListAssetInfor()
        // {
        //     if (_context.Assets != null)
        //     {
        //         try
        //         {
        //             var assets = await _context.Assets
        //                 .Include(c => c.Category)
        //                 .Select(asset => asset.AssetEntityToDTO())
        //                 .ToListAsync();
        //             return new OkObjectResult(assets);
        //         }
        //         catch (Exception e)
        //         {
        //             return new BadRequestObjectResult(e);
        //         }
        //     }
        //     return new NoContentResult();
        // }
    }
}