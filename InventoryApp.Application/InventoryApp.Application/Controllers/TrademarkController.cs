using InventoryApp.Data.Helper;
using InventoryApp.Infrastructures.Interfaces.Services;
using InventoryApp.Infrastructures.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Application.Controllers
{
    [Authorize]
    public class TrademarkController : BaseController
    {
        private readonly ITrademarkService _trademarkService;
        public TrademarkController(ITrademarkService trademarkService)
        {
            _trademarkService = trademarkService;
        }
        
        [HttpGet]
        public IEnumerable<TrademarkModelRq> GetAllTrademarks()
        {
            return _trademarkService.GetAllTrademarks();
        }

        [HttpPost]
        public async Task<IActionResult> AddTrademark([FromBody]TrademarkModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _trademarkService.AddTrademark(model, userIdentity));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTrademark(Guid id,[FromBody]TrademarkModelRq model)
        {
            try
            {
                UserIdentity userIdentity = GetCurrentUserIdentity();
                return Ok(await _trademarkService.UpdateTrademark(id, model, userIdentity));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTrademark(Guid id)
        {
            try
            {
                return Ok(await _trademarkService.DeleteTrademark(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
