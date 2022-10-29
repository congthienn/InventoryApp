using InventoryApp.Data.Helper;
using InventoryApp.Domain.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryApp.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private Serilog.ILogger _logger;
        [ApiExplorerSettings(IgnoreApi = true)]
        private string GetCurrentUser()
        {
            var claim = this.User.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual object GetValueFromToken(string typeName)
        {
            var result = this.User.Claims.ToList().FirstOrDefault(p => p.Type == typeName);
            if (result != null)
            {
                switch (result.ValueType)
                {
                    case ClaimValueTypes.Integer:
                        return int.Parse(result.Value);
                    case ClaimValueTypes.String:
                        return (string)result.Value;
                    case ClaimValueTypes.Boolean:
                        return bool.Parse(result.Value);
                };
            }
            return new Exception("Not enough information. Please login again");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private Guid GetCurrentUserId()
        {
            return new Guid(GetCurrentUser());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private string GetCurrentUserName()
        {
            return this.User.FindFirst(ClaimTypes.Name).Value;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private List<string> GetCurrentUserRoles()
        {
            return this.User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public virtual UserIdentity GetCurrentUserIdentity()
        {
            try
            {
                Guid oid = GetCurrentUserId();
                if (oid == null) return null;

                var issuer = new UserIdentity
                {
                    Id = oid,
                    UserName = GetCurrentUserName(),
                    Roles = GetCurrentUserRoles()
                };
                return issuer;
            }
            catch (Exception e)
            {
                _logger = LoggerHelper.GetConfig();
                _logger.Error(e.Message);
                return null;
            }
        }
    }
}
