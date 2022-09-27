using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Common.ApiActionResult
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; set; }

        public T Object { get; set; }

        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
