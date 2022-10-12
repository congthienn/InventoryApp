using InventoryApp.Data.Models;
using InventoryApp.Infrastructures.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Infrastructures.Interfaces.Services
{
    public interface IEmailService
    {
        IEnumerable<EmailTemplateDTO> GetEmailTemplate();
        int CreateEmailTemplate(EmailTemplateDTO model);
        Task SendEmailChangePasswordAsync(string email, string username);
        Task SendEmailResetPasswordAsync(string email, string userName);
        Task SendEmailForgotPasswordAsync(string email, string userName, string code);
        Task<EmailTemplate> GetTemplate(string name);
    }
}
