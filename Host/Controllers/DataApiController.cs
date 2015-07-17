using System;
using System.Web.Http;

namespace Host.Controllers
{
    public class DataApiController : ApiController
    {
        [HttpGet]
        public string Time()
        {
            return DateTime.Now.ToString("HH:mm:ss.fff");
        }
    }
}
