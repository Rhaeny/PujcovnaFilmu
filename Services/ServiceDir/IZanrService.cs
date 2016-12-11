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
        int Update(Zanr zanr);
        Collection<Zanr> Select();
        Zanr Detail(int idZanr);
        int Delete(int idZanr);
    }
}
