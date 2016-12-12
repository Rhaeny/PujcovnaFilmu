using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IZakaznikService
    {
        [OperationContract]
        int Insert(Zakaznik zakaznik);

        [OperationContract]
        int Update(Zakaznik zakaznik);

        [OperationContract]
        Collection<Zakaznik> Select();

        [OperationContract]
        Collection<Zakaznik> SelectBy(ZakaznikNull zakaznikNull);

        [OperationContract]
        Zakaznik Detail(int idZak);

        [OperationContract]
        int Delete(int idZak);
    }
}
