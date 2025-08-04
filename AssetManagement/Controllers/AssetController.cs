using AssetManagement.Interfaces;
using AssetManagement.Models;
using AssetManagement.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        // ✅ POST: Add new asset
        [HttpPost]
        public async Task<ActionResult<AssetDTO>> Add([FromBody] AssetDTO dto)
        {
            var created = await _assetService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.AssetId }, created);
        }

        // ✅ GET: Get single asset by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDTO>> GetById(int id)
        {
            var result = await _assetService.GetByIdAsync(id);
            if (result == null)
                return NotFound(new { message = $"Asset with ID {id} not found." });

            return Ok(result);
        }

        // ✅ PUT: Update asset
        [HttpPut("{id}")]
        public async Task<ActionResult<AssetDTO>> Update(int id, [FromBody] AssetDTO dto)
        {
            if (id != dto.AssetId)
                return BadRequest(new { message = "ID in route does not match ID in body." });

            var updated = await _assetService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        // ✅ DELETE: Remove asset
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssetDTO>> Delete(int id)
        {
            var deleted = await _assetService.DeleteAsync(id);
            return Ok(deleted);
        }

        // ✅ GET: Get all assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetDTO>>> GetAll()
        {
            var assets = await _assetService.GetAllAsync();
            return Ok(assets);
        }
    }
}
