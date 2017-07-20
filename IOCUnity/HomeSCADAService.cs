using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IOCUnity
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "", ConfigurationName = "PPS2.Scada.HomeSCADAService")]
    public interface HomeSCADAService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetNowValueByTag", ReplyAction = "urn:HomeSCADAService/GetNowValueByTagResponse")]
        System.Data.DataTable GetNowValueByTag(string tag);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetNowValueByTag", ReplyAction = "urn:HomeSCADAService/GetNowValueByTagResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetNowValueByTagAsync(string tag);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetValueByTagDureTime", ReplyAction = "urn:HomeSCADAService/GetValueByTagDureTimeResponse")]
        System.Data.DataTable GetValueByTagDureTime(string tag, System.DateTime dtStart, System.DateTime dtEnd);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetValueByTagDureTime", ReplyAction = "urn:HomeSCADAService/GetValueByTagDureTimeResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetValueByTagDureTimeAsync(string tag, System.DateTime dtStart, System.DateTime dtEnd);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetLastValueByTag", ReplyAction = "urn:HomeSCADAService/GetLastValueByTagResponse")]
        System.Data.DataTable GetLastValueByTag(string tag, System.DateTime lastDateTime);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetLastValueByTag", ReplyAction = "urn:HomeSCADAService/GetLastValueByTagResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetLastValueByTagAsync(string tag, System.DateTime lastDateTime);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetLastValueByTag2", ReplyAction = "urn:HomeSCADAService/GetLastValueByTag2Response")]
        System.Data.DataSet GetLastValueByTag2(string tag, System.DateTime lastDateTime);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetLastValueByTag2", ReplyAction = "urn:HomeSCADAService/GetLastValueByTag2Response")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetLastValueByTag2Async(string tag, System.DateTime lastDateTime);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetHistoryValueByTag", ReplyAction = "urn:HomeSCADAService/GetHistoryValueByTagResponse")]
        System.Data.DataTable GetHistoryValueByTag(string tag, System.DateTime currentDateTime);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetHistoryValueByTag", ReplyAction = "urn:HomeSCADAService/GetHistoryValueByTagResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetHistoryValueByTagAsync(string tag, System.DateTime currentDateTime);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetScadaValueOPCDataByTag", ReplyAction = "urn:HomeSCADAService/GetScadaValueOPCDataByTagResponse")]
        System.Data.DataTable GetScadaValueOPCDataByTag(string strTag);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetScadaValueOPCDataByTag", ReplyAction = "urn:HomeSCADAService/GetScadaValueOPCDataByTagResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetScadaValueOPCDataByTagAsync(string strTag);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetScadaValueOPCDataByTags", ReplyAction = "urn:HomeSCADAService/GetScadaValueOPCDataByTagsResponse")]
        System.Data.DataTable GetScadaValueOPCDataByTags(string[] strTags);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/GetScadaValueOPCDataByTags", ReplyAction = "urn:HomeSCADAService/GetScadaValueOPCDataByTagsResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetScadaValueOPCDataByTagsAsync(string[] strTags);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/ExecuteOilAmountService", ReplyAction = "urn:HomeSCADAService/ExecuteOilAmountServiceResponse")]
        void ExecuteOilAmountService(System.DateTime dtime);

        [System.ServiceModel.OperationContractAttribute(Action = "urn:HomeSCADAService/ExecuteOilAmountService", ReplyAction = "urn:HomeSCADAService/ExecuteOilAmountServiceResponse")]
        System.Threading.Tasks.Task ExecuteOilAmountServiceAsync(System.DateTime dtime);
    }
}
