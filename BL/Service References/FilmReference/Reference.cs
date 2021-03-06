﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BL.FilmReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FilmReference.IFilmService")]
    public interface IFilmService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Insert", ReplyAction="http://tempuri.org/IFilmService/InsertResponse")]
        int Insert(DTO.Film film);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Insert", ReplyAction="http://tempuri.org/IFilmService/InsertResponse")]
        System.Threading.Tasks.Task<int> InsertAsync(DTO.Film film);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Update", ReplyAction="http://tempuri.org/IFilmService/UpdateResponse")]
        int Update(DTO.Film film);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Update", ReplyAction="http://tempuri.org/IFilmService/UpdateResponse")]
        System.Threading.Tasks.Task<int> UpdateAsync(DTO.Film film);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Select", ReplyAction="http://tempuri.org/IFilmService/SelectResponse")]
        System.Collections.ObjectModel.Collection<DTO.Film> Select();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Select", ReplyAction="http://tempuri.org/IFilmService/SelectResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.Collection<DTO.Film>> SelectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/SelectBy", ReplyAction="http://tempuri.org/IFilmService/SelectByResponse")]
        System.Collections.ObjectModel.Collection<DTO.Film> SelectBy(NullDTO.FilmNull filmNull);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/SelectBy", ReplyAction="http://tempuri.org/IFilmService/SelectByResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.Collection<DTO.Film>> SelectByAsync(NullDTO.FilmNull filmNull);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Detail", ReplyAction="http://tempuri.org/IFilmService/DetailResponse")]
        DTO.Film Detail(int idFilm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Detail", ReplyAction="http://tempuri.org/IFilmService/DetailResponse")]
        System.Threading.Tasks.Task<DTO.Film> DetailAsync(int idFilm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Delete", ReplyAction="http://tempuri.org/IFilmService/DeleteResponse")]
        int Delete(int idFilm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFilmService/Delete", ReplyAction="http://tempuri.org/IFilmService/DeleteResponse")]
        System.Threading.Tasks.Task<int> DeleteAsync(int idFilm);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFilmServiceChannel : BL.FilmReference.IFilmService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FilmServiceClient : System.ServiceModel.ClientBase<BL.FilmReference.IFilmService>, BL.FilmReference.IFilmService {
        
        public FilmServiceClient() {
        }
        
        public FilmServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FilmServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilmServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FilmServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Insert(DTO.Film film) {
            return base.Channel.Insert(film);
        }
        
        public System.Threading.Tasks.Task<int> InsertAsync(DTO.Film film) {
            return base.Channel.InsertAsync(film);
        }
        
        public int Update(DTO.Film film) {
            return base.Channel.Update(film);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAsync(DTO.Film film) {
            return base.Channel.UpdateAsync(film);
        }
        
        public System.Collections.ObjectModel.Collection<DTO.Film> Select() {
            return base.Channel.Select();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.Collection<DTO.Film>> SelectAsync() {
            return base.Channel.SelectAsync();
        }
        
        public System.Collections.ObjectModel.Collection<DTO.Film> SelectBy(NullDTO.FilmNull filmNull) {
            return base.Channel.SelectBy(filmNull);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.Collection<DTO.Film>> SelectByAsync(NullDTO.FilmNull filmNull) {
            return base.Channel.SelectByAsync(filmNull);
        }
        
        public DTO.Film Detail(int idFilm) {
            return base.Channel.Detail(idFilm);
        }
        
        public System.Threading.Tasks.Task<DTO.Film> DetailAsync(int idFilm) {
            return base.Channel.DetailAsync(idFilm);
        }
        
        public int Delete(int idFilm) {
            return base.Channel.Delete(idFilm);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int idFilm) {
            return base.Channel.DeleteAsync(idFilm);
        }
    }
}
