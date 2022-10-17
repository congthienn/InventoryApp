using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class EmailController : BaseController
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmailTemplate([FromBody]EmailTemplateCreateModel emailTemplate)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _emailService.CreateEmailTemplate(emailTemplate, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }   
        }

        [Route("templatenames")]
        [HttpGet]
        public IEnumerable<string> GetListEmailTemplateNames()
        {
            return _emailService.GetListEmailTemplateNames();
        }

        [HttpGet]
        public IEnumerable<EmailTemplateCreateModel> GetEmailTemplate()
        {
            return _emailService.GetEmailTemplate();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<EmailTemplateCreateModel> GetTemplate(Guid id)
        {
            return await _emailService.GetTemplate(id);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTemplate(Guid id)
        {
            try
            {
                return Ok(await _emailService.DeleteEmailTemplate(id));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmailTemplate(Guid id, [FromBody] EmailTemplateCreateModel emailTemplate)
        {
            try
            {
                var user = GetCurrentUserIdentity();
                return Ok(await _emailService.UpdateEmailTemplate(id, emailTemplate, user));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
