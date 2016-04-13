using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class StartUpController : ApiController
    {


        #region 测试接口
        [HttpPost]
        public HttpResponseMessage GetName()
        {
         String   retstr = "hello";
            return new HttpResponseMessage { Content = new StringContent(retstr, System.Text.Encoding.UTF8, "application/json") };
        }
        #endregion

    }
}
