using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Common.ApiActionResult
{
    public class ErrorResult<TEntity> : ApiResult<TEntity>
    {
        public ErrorResult(int statuscode, string message)
        {
            StatusCode = statuscode;
            Message = message;
            IsSuccess = false;
        }
    }
}
