using backend.Data;
using backend.Entities;
using backend.Enums;
using backend.Helpers;
using backend.Models.Assets;

namespace backend.Repositories
{
    public interface IAssetRepository
    {
        Task AddAsset(AssetCreateModel asset, string location);
        Task UpdateAsset(AssetUpdateModel asset, int assetId);
        Task DeleteAsset(int id);
    }
    public class AssetRepository : IAssetRepository
    {
        private MyDbContext _context;
        public AssetRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsset(AssetCreateModel asset, string location)
        {
            try
            {
                if(!CheckValidCategory(asset.CategoryId)) throw new AppException("CategoryId is not valid");
                if(!CheckInstalledDate(asset.InstalledDate)) throw new AppException("Installed Date must not be in the future");
                var foundCategory = await _context.Categories.FindAsync(asset.CategoryId);
                if (!CheckValidCategory(asset.CategoryId) && !CheckInstalledDate(asset.InstalledDate))
                {
                    var newAsset = new Asset()
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
                    await _context.AddAsync(newAsset);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateAsset(AssetUpdateModel asset, int assetId)
        {
            try
            {
                AssetState enumParseResult;
                var foundCategory = await _context.Categories.FindAsync(asset.CategoryId);
                var foundAsset = await _context.Assets.FindAsync(assetId);
                if (foundAsset != null && !CheckValidCategory(asset.CategoryId))
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
                        foundAsset.AssetState = AssetState.WaitingForRecycle;
                    }
                    else
                    {
                        foundAsset.AssetState = AssetState.Available;
                    }
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
    }
}