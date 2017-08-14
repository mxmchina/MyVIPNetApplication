using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mxm.Extension.Main.Utility
{
    /// <summary>
    /// 发送短信服务
    /// </summary>
    [ServiceContract]
    public interface ISendMessageService
    {
        [OperationContract(Action = "http://tempuri.org/Submit", ReplyAction = "*")]
        SendMessageSubmitResponse Submit(SendMessageSubmitRequest request);
    }


    [MessageContract(IsWrapped = false)]
    public class SendMessageSubmitRequest
    {
        [MessageBodyMember(Name = "Submit", Namespace = "http://tempuri.org/")]
        public SendMessageSubmitRequestBody Body
        {
            get;
            set;
        }
    }


    [DataContract(Namespace = "http://tempuri.org/")]
    public class SendMessageSubmitRequestBody
    {
        [DataMember(Name = "login", EmitDefaultValue = false)]
        public SendMessageSubmitRequestLogin Login
        {
            get;
            set;
        }

        [DataMember(Name = "submit", EmitDefaultValue = false)]
        public SendMessageSubmitRequestSubmit Submit
        {
            get;
            set;
        }
    }

    [DataContract(Name = "Login", Namespace = "http://model.cpsms.hollycrm.com/xsd")]
    public class SendMessageSubmitRequestLogin
    {
        [DataMember(IsRequired = true, Name = "name")]
        public string Name
        {
            get;
            set;
        }

        [DataMember(IsRequired = true, Name = "passwd")]
        public string Passwd
        {
            get;
            set;
        }
    }


    [DataContract(Name = "Submit", Namespace = "http://model.cpsms.hollycrm.com/xsd")]
    public class SendMessageSubmitRequestSubmit
    {
        [DataMember(IsRequired = true, Name = "atTime")]
        public string AtTime
        {
            get;
            set;
        }

        [DataMember(IsRequired = true, Name = "destTermId")]
        public string DestTermId
        {
            get;
            set;
        }

        [DataMember(IsRequired = true, Name = "intervalValidTime")]
        public string IntervalValidTime
        {
            get;
            set;
        }


        [DataMember(IsRequired = true, Name = "msgContent")]
        public string MsgContent
        {
            get;
            set;
        }


        [DataMember(IsRequired = true, Name = "needReport")]
        public string NeedReport
        {
            get;
            set;
        }

        [DataMember(IsRequired = true, Name = "pid")]
        public string Pid
        {
            get;
            set;
        }

        [DataMember(IsRequired = true, Name = "priority")]
        public string Priority
        {
            get;
            set;
        }

        [DataMember(IsRequired = true, Name = "service_id")]
        public string ServiceId
        {
            get;
            set;
        }

        [DataMember(IsRequired = true, Name = "srcTermId")]
        public string SrcTermId
        {
            get;
            set;
        }

        [DataMember(IsRequired = true, Name = "ticketId")]
        public string TicketId
        {
            get;
            set;
        }

    }


    [MessageContract(IsWrapped = false)]
    public class SendMessageSubmitResponse
    {
        [MessageBodyMember(Name = "SubmitResponse", Namespace = "http://tempuri.org/")]
        public SendMessageSubmitResponseBody Body
        {
            get;
            set;
        }
    }

    [DataContract(Namespace = "http://tempuri.org/")]
    public class SendMessageSubmitResponseBody
    {
        [DataMember(EmitDefaultValue = false)]
        public SendMessageSubmitResponseResult SubmitResult
        {
            get;
            set;
        }
    }

    [DataContract(Name = "Result", Namespace = "http://model.cpsms.hollycrm.com/xsd")]
    public class SendMessageSubmitResponseResult
    {
        [DataMember(Name = "body", IsRequired = true)]
        public string Body
        {
            get;
            set;
        }
        [DataMember(Name = "head", IsRequired = true)]
        public string Head
        {
            get;
            set;
        }
    }
}
