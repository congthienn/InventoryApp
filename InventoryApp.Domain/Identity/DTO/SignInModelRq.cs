using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Domain.Identity.DTO
{
    public class SignInModelRq
    {
        [Required(ErrorMessage = "Please enter your login email")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter the login password")]
        
        public string Password { get; set; }
    }
}
