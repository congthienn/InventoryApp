using InventoryApp.Data.Helper;
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
        Task<Guid> CreateEmailTemplate(EmailTemplateDTO model, UserIdentity user);
        Task SendEmailChangePasswordAsync(string email, string username);
        Task SendEmailResetPasswordAsync(string email, string userName, string password);
        Task SendEmailForgotPasswordAsync(string email, string userName, string code);
        Task SendEmailCreateNewUserAsync(string email, string userName, string password);
        Task<EmailTemplateDTO> GetTemplate(Guid id);
        IEnumerable<string> GetListEmailTemplateNames();
        Task<bool> DeleteEmailTemplate(Guid id);
    }
}
