using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Common.ApiActionResult
{
    public class SuccessResult<TEntity> : ApiResult<TEntity>
    {
        public SuccessResult(int statuscode, string message, TEntity obj)
        {
            StatusCode = statuscode;
            Message = message;
            Object = obj;
            IsSuccess = true;
        }
        public SuccessResult(int statuscode, string message)
        {
            StatusCode = statuscode;
            Message = message;
            IsSuccess = true;
        }
    }
}
