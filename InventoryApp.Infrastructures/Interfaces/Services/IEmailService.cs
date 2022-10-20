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
        IEnumerable<EmailTemplateCreateModel> GetEmailTemplate();
        Task<Guid> CreateEmailTemplate(EmailTemplateCreateModel model, UserIdentity user);
        Task SendEmailChangePasswordAsync(string email, string username);
        Task SendEmailResetPasswordAsync(string email, string userName, string password);
        Task SendEmailForgotPasswordAsync(string email, string userName, string code);
        Task SendEmailCreateNewUserAsync(string email, string userName, string password, string token);
        Task<EmailTemplateCreateModel> GetTemplate(Guid id);
        IEnumerable<string> GetListEmailTemplateNames();
        Task<bool> DeleteEmailTemplate(Guid id);
        Task<EmailTemplateCreateModel> UpdateEmailTemplate(Guid id, EmailTemplateCreateModel model, UserIdentity user);
    }
}
