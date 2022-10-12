using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Models.DTO
{
    public class EmailTemplateDTO
    {
        [Required(ErrorMessage = "Please enter email name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter email content")]
        public string EmailContent { get; set; }
        [Required(ErrorMessage = "Please enter email subject")]
        public string EmailSubject { get; set; }
    }
}