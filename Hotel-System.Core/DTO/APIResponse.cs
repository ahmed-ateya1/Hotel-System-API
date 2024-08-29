using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Core.DTO
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode;
        public bool IsSuccess = true;
        public List<string> ErrorMessages = new List<string>();
        public object Result {  get; set; }
    }
}
