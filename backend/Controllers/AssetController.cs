using backend.Interfaces;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;
using backend.Entities;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private IAssetService _service;
        public AssetController(IAssetService service)
        {
            _service = service;
        }
        // [HttpGet("all")]
        // public async Task<ActionResult<List<AssetInforDTO>>> GetListAssetInfor()
        // {
        //     return await _service.GetAllAsset();
        // }
        
        [HttpGet]
        public async Task<AssetInforDTO> GetAssetInforDTO(int id){
            return await _service.GetAssetInfor(id);
        }
        [HttpPost]
        public async Task AddAsset(int categoryId,[FromBody] AssetDTO assetDTO)
        {
            await _service.AddAsset(categoryId,assetDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsset(int id, [FromBody] AssetDTO asset)
        {
            return await _service.UpdateAsset(asset, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsset(int id)
        {
            return await _service.DeleteAsset(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDTO>> GetAsset(int id)
        {
            return await _service.GetAsset(id);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<AssetDTO>>> GetAllAsset()
        {
            return await _service.GetAllAsset();
        }
        
    }
}