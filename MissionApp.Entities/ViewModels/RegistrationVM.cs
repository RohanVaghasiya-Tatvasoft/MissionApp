using Azure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionApp.Entities.Models;

namespace MissionApp.Entities.ViewModels
{
    public class RegistrationVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Mobile Number is not valid")]
        public long PhoneNumber { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City? City { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
    }
}
