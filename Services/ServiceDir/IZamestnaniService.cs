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

        [OperationContract]
        int Update(Zamestnani zam);

        [OperationContract]
        Collection<Zamestnani> Select();

        [OperationContract]
        Zamestnani Detail(int idZam);

        [OperationContract]
        int Delete(int idZam);
    }
}
