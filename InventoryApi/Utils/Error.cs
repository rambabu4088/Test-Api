using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApi.Utils
{
    public class Error
    {
        public Error(int Code, string Message)
        {
            this.Code = Code;
            this.Message = Message;
        }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
