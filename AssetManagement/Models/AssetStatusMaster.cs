using System.ComponentModel.DataAnnotations;
namespace AssetManagement.Models
{
    public class AssetStatusMaster
    {
        [Key]
        public int AssetStatusId { get; set; }         // PK
        public string StatusName { get; set; } = string.Empty;   // Available, Assigned, In Service, Under Audit


        public ICollection<Asset?> Assets { get; set; }
    }
}
