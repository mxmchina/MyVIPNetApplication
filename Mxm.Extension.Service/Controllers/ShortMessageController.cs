using Mxm.Extension.Main.BLL.RemoteServices;
using Mxm.Extension.Main.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mxm.Extension.Service.Controllers
{
    [RoutePrefix("api/sms")]
    public class ShortMessageController : ApiController
    {
        [HttpGet]
        public bool Send(string key,string password,string content,string phones)
        {
            try
            {
                LoggerTxt.WriteLog("95504短信发送", "消息", $"key={key},password={password},content={content},phones={phones}");
                ShortMessageRemoteService service = new ShortMessageRemoteService();
                return service.Send(key, password, content, phones);
            }
            catch (Exception ex)
            {
                LoggerTxt.WriteLog("95504短信发送", "错误", $"key={key},password={password},content={content},phones={phones},error={ex.ToString()}");
                throw ex;
            }
            
        }

        [HttpGet]
        [Route("sendtrq")]
        public bool SendTrq(string phones, string content)
        {
            try
            {
                LoggerTxt.WriteLog("电信短信发送", "消息", $"content={content},phones={phones}");

                TrqShortMessageRemoteService service = new TrqShortMessageRemoteService();

                return service.Send(phones, content);
            }
            catch (Exception ex)
            {
                LoggerTxt.WriteLog("电信短信发送", "错误", $"content={content},phones={phones},error={ex.ToString()}");
                throw ex;
            }

            
        }
    }
}
