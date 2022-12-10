
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace CSM.Models.ViewModels
{
	
		public class BookingViewModel
		{

		[Required]
		public DateTime Date { get; set; }

		[Required]
		[StringLength(50)]
		public string Source { get; set; }

		[Required]
		[StringLength(50)]
		public string Destination { get; set; }

		

        public IEnumerable<Routes>? Routes { get; set; }
        public IEnumerable<ApplicationUser>? ApplicationUsers { get; set; }


    }
} 
