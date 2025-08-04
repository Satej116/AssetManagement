using AssetManagement.Models;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Interfaces
{
    public interface IAssetService : IRepository<int, Asset>
    {
        Task UpdateAsync(int id, AssetDTO dto);
    }
}
