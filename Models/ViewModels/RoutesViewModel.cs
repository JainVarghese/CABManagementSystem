using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CSM.Models.ViewModels
{
    public class RoutesViewModel
    {
      
        public string Source { get; set; }
    
        public string Destination { get; set; }
        public int Cost { get; set; }
       
    }
}
