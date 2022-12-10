using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSM.Models
{
	public class Booking
	{

		public int Id { get; set; }
		public DateTime Date { get; set; }

        //public string Source { get; set; }

        //public string Destination { get; set; }
        public Routes Route { get; set; }

        [ForeignKey(nameof(Route))]

        public int RouteId { get; set; }

		public string? DriverId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		[ForeignKey(nameof(ApplicationUser))]
		public string UserId { get; set; }
		public bool Status { get; set; }

	}
}
