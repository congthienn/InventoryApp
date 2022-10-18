using AutoMapper;
using InventoryApp.Data.Models;
using InventoryApp.Domain.EmailSender;
using InventoryApp.Infrastructures;
using InventoryApp.Infrastructures.Helper;
using InventoryApp.Infrastructures.Interfaces.Repositories;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using InventoryApp.Common;
using System.Web;
using InventoryApp.Data.Helper;
using Microsoft.Extensions.Logging;
using InventoryApp.Infrastructures.Repositories;

namespace InventoryApp.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmailService(
            IEmailSender emailSender,
            IMapper mapper, 
            ILogger<EmailService> logger)
        {
            _unitOfWork = new UnitOfWork();
            _emailRepository = new EmailRepository(_unitOfWork);
            _emailSender = emailSender;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<string> GetListEmailTemplateNames()
        {
            return new List<string>()
            {
                EMAILTEMPLATE_CONSTANT.EMAIL_FORGOT_PASSWORD,
                EMAILTEMPLATE_CONSTANT.NEW_USER_CREATION_EMAIL,
                EMAILTEMPLATE_CONSTANT.USER_PASSWORD_CHANGE_EMAIL,
                EMAILTEMPLATE_CONSTANT.USER_PASSWORD_RESET_EMAIL
            };
        }
        public async Task<Guid> CreateEmailTemplate(EmailTemplateCreateModel model, UserIdentity user)
        {
            try
            {
                EmailTemplate emailTemplate = _mapper.Map<EmailTemplate>(model);
                emailTemplate.CreateBy(user);
                emailTemplate.UpdateBy(user);
                await _emailRepository.Insert(emailTemplate);
                _unitOfWork.Save();
                return emailTemplate.Id;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }

        public IEnumerable<EmailTemplateCreateModel> GetEmailTemplate()
        {
            return _mapper.Map<IEnumerable<EmailTemplateCreateModel>>(_emailRepository.Get());
        }

        public async Task<EmailTemplateCreateModel> GetTemplate(Guid id)
        {
            return _mapper.Map<EmailTemplateCreateModel>(await _emailRepository.GetByID(id));
        }

        public async Task SendEmailChangePasswordAsync(string email, string username)
        {
            EmailTemplate emailTemplate = _emailRepository.Get(x=> x.Name == EMAILTEMPLATE_CONSTANT.USER_PASSWORD_CHANGE_EMAIL).FirstOrDefault();
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#email", email);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#username", username);
            await _emailSender.SendEmailAsync(email, emailTemplate.EmailSubject, emailTemplate.EmailContent, true);
        }

        public async Task SendEmailCreateNewUserAsync(string email, string userName, string password)
        {
            EmailTemplate emailTemplate = _emailRepository.Get(x => x.Name == EMAILTEMPLATE_CONSTANT.NEW_USER_CREATION_EMAIL).FirstOrDefault();
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#email", email);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#username", userName);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#password", password);
            await _emailSender.SendEmailAsync(email, emailTemplate.EmailSubject, emailTemplate.EmailContent, true);
        }

        public async Task SendEmailForgotPasswordAsync(string email, string userName, string code)
        {
            string urlCode = HttpUtility.UrlEncode(code);
            string urlResetPassword = $"<a href='{Appsetting.GetAppSettingValue("EmailURL:ForgotPassword")}?email={email}&code={urlCode}'>" +
                $"Nhấn vào đây để thay đổi.</a>";
            EmailTemplate emailTemplate = _emailRepository.Get(x => x.Name == EMAILTEMPLATE_CONSTANT.EMAIL_FORGOT_PASSWORD).FirstOrDefault();
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#email", email);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#url", urlResetPassword);
            await _emailSender.SendEmailAsync(email, emailTemplate.EmailSubject, emailTemplate.EmailContent, true);
        }

        public async Task SendEmailResetPasswordAsync(string email, string userName, string password)
        {
            EmailTemplate emailTemplate = _emailRepository.Get(x => x.Name == EMAILTEMPLATE_CONSTANT.USER_PASSWORD_RESET_EMAIL).FirstOrDefault();
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#email", email);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#username", userName);
            await _emailSender.SendEmailAsync(email, emailTemplate.EmailSubject, emailTemplate.EmailContent, true);
        }

        public async Task<bool> DeleteEmailTemplate(Guid id)
        {
            try
            {
                EmailTemplate emailTemplate = await _emailRepository.GetByID(id);
                if (emailTemplate == null)
                    return false;

                await _emailRepository.Delete(emailTemplate);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
            
        }

        public async Task<EmailTemplateCreateModel> UpdateEmailTemplate(Guid id, EmailTemplateCreateModel model, UserIdentity user)
        {
            try
            {
                var emailTemplate = await _emailRepository.GetByID(id);

                if (emailTemplate == null)
                    throw new NotImplementedException();

                emailTemplate.EmailSubject = model.EmailSubject;
                emailTemplate.EmailContent = model.EmailContent;
                emailTemplate.UpdateBy(user);

                await _emailRepository.Update(emailTemplate);
                _unitOfWork.Save();

                return _mapper.Map<EmailTemplateCreateModel>(emailTemplate);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new NotImplementedException(e.Message);
            }
        }
    }
}
