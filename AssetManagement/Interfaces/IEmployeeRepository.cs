using AssetManagement.Models;

namespace AssetManagement.Interfaces
{
    public interface IEmployeeRepository : IRepository<int, Employee>
    {
        // No extra methods needed now (generic handles CRUD)
    }
}
