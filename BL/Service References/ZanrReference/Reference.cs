﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BL.ZanrReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ZanrReference.IZanrService")]
    public interface IZanrService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Insert", ReplyAction="http://tempuri.org/IZanrService/InsertResponse")]
        int Insert(DTO.Zanr zanr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Insert", ReplyAction="http://tempuri.org/IZanrService/InsertResponse")]
        System.Threading.Tasks.Task<int> InsertAsync(DTO.Zanr zanr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Update", ReplyAction="http://tempuri.org/IZanrService/UpdateResponse")]
        int Update(DTO.Zanr zanr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Update", ReplyAction="http://tempuri.org/IZanrService/UpdateResponse")]
        System.Threading.Tasks.Task<int> UpdateAsync(DTO.Zanr zanr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Select", ReplyAction="http://tempuri.org/IZanrService/SelectResponse")]
        System.Collections.ObjectModel.Collection<DTO.Zanr> Select();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Select", ReplyAction="http://tempuri.org/IZanrService/SelectResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.Collection<DTO.Zanr>> SelectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Detail", ReplyAction="http://tempuri.org/IZanrService/DetailResponse")]
        DTO.Zanr Detail(int idZanr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Detail", ReplyAction="http://tempuri.org/IZanrService/DetailResponse")]
        System.Threading.Tasks.Task<DTO.Zanr> DetailAsync(int idZanr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Delete", ReplyAction="http://tempuri.org/IZanrService/DeleteResponse")]
        int Delete(int idZanr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IZanrService/Delete", ReplyAction="http://tempuri.org/IZanrService/DeleteResponse")]
        System.Threading.Tasks.Task<int> DeleteAsync(int idZanr);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IZanrServiceChannel : BL.ZanrReference.IZanrService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ZanrServiceClient : System.ServiceModel.ClientBase<BL.ZanrReference.IZanrService>, BL.ZanrReference.IZanrService {
        
        public ZanrServiceClient() {
        }
        
        public ZanrServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ZanrServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ZanrServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ZanrServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Insert(DTO.Zanr zanr) {
            return base.Channel.Insert(zanr);
        }
        
        public System.Threading.Tasks.Task<int> InsertAsync(DTO.Zanr zanr) {
            return base.Channel.InsertAsync(zanr);
        }
        
        public int Update(DTO.Zanr zanr) {
            return base.Channel.Update(zanr);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAsync(DTO.Zanr zanr) {
            return base.Channel.UpdateAsync(zanr);
        }
        
        public System.Collections.ObjectModel.Collection<DTO.Zanr> Select() {
            return base.Channel.Select();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.Collection<DTO.Zanr>> SelectAsync() {
            return base.Channel.SelectAsync();
        }
        
        public DTO.Zanr Detail(int idZanr) {
            return base.Channel.Detail(idZanr);
        }
        
        public System.Threading.Tasks.Task<DTO.Zanr> DetailAsync(int idZanr) {
            return base.Channel.DetailAsync(idZanr);
        }
        
        public int Delete(int idZanr) {
            return base.Channel.Delete(idZanr);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int idZanr) {
            return base.Channel.DeleteAsync(idZanr);
        }
    }
}