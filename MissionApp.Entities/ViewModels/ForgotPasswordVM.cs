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
    public class ForgotPasswordVM
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Token { get; set; }
        public PasswordReset? PasswordsReset { get; set; }
    }
}
