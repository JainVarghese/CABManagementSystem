using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSM.Models
{
    public enum VehicleType
    {
        Hatchback,
        SUV,
        Sedan

    }
    public class Detail
    {
        [Key]
        public string LicenceNumber { get; set; }

        public string VehicleNumber { get; set; }
        public VehicleType VehicleType { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string DriverId { get; set; }

    }
}
