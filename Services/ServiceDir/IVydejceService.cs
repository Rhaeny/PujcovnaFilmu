using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IVydejceService
    {
        [OperationContract]
        int Insert(Vydejce vydejce);

        [OperationContract]
        int Update(Vydejce vydejce);

        [OperationContract]
        Collection<Vydejce> Select();

        [OperationContract]
        Collection<Vydejce> SelectBy(VydejceNull vydejceNull);

        [OperationContract]
        Vydejce Detail(int idVydejce);

        [OperationContract]
        int Delete(int idVydejce);
    }
}
