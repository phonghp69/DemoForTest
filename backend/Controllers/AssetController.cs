using backend.Interfaces;
using backend.DTO;
using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Models.Assets;

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

        [HttpPost("/add")]
        public async Task AddAsset([FromBody] AssetCreateModel asset, string location)
        {
            await _service.AddAsset(asset, location);
        }

        [HttpPost("/update")]
        public async Task UpdateAsset([FromBody] AssetUpdateModel asset, int id)
        {
            await _service.UpdateAsset(asset, id);
        }
        
        [HttpDelete("/delete")]
        public async Task DeleteAsset(int id)
        {
            await _service.DeleteAsset(id);
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