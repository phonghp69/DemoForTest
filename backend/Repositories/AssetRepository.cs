using backend.Data;
using backend.Entities;
using backend.Enums;
using backend.Models.Assets;

namespace backend.Repositories
{
    public interface IAssetRepository
    {
        Task AddAsset(AssetCreateModel asset, string location);
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
                if(!CheckValidCategory(asset.CategoryId) || !CheckInstalledDate(asset.InstalledDate))
                {
                    var newAsset = new Asset()
                    {
                        AssetCode = GenerateAssetCode(asset.CategoryId),
                        AssetName = asset.AssetName,
                        CategoryId = asset.CategoryId,
                        Specification = asset.Specification,
                        InstalledDate = asset.InstalledDate,
                        Location = location,
                        AssetState = asset.AssetState.Equals("Available") ? AssetState.Available : AssetState.NotAvailable
                    };
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