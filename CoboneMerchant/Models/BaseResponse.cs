using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoboneMerchant.Models
{
    public class BaseResponse<T>
    {

            public int Success { get; set; }
            public string[]? Error { get; set; }
            public T? Data { get; set; }
        
    }
}
