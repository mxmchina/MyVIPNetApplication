using Mxm.Extension.Main.BLL.RemoteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mxm.Extension.Service.Controllers
{
    public class ShortMessageController : ApiController
    {
        [HttpGet]
        public bool Send(string key,string password,string content,string phones)
        {
            ShortMessageRemoteService service = new ShortMessageRemoteService();
            return service.Send(key,password,content,phones);
        }
    }
}
