using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IZanrService
    {
        [OperationContract]
        int Insert(Zanr zanr);

        [OperationContract]
        int Update(Zanr zanr);

        [OperationContract]
        Collection<Zanr> Select();

        [OperationContract]
        Zanr Detail(int idZanr);

        [OperationContract]
        int Delete(int idZanr);
    }
}
