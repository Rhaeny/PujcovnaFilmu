using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IZamestnaniService
    {
        [OperationContract]
        int Insert(Zamestnani zam);
        int Update(Zamestnani zam);
        Collection<Zamestnani> Select();
        Zamestnani Detail(int idZam);
        int Delete(int idZam);
    }
}
