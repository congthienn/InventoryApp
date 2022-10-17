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
        public async Task<IActionResult> CreateEmailTemplate([FromBody]EmailTemplateDTO emailTemplate)
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
        public IEnumerable<EmailTemplateDTO> GetEmailTemplate()
        {
            return _emailService.GetEmailTemplate();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<EmailTemplateDTO> GetTemplate(Guid id)
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
    }
}
