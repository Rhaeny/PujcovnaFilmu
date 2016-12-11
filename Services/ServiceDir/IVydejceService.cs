using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IVydejceService
    {
        [OperationContract]
        int Insert(Vydejce vydejce);
        int Update(Vydejce vydejce);
        Collection<Vydejce> Select();
        Collection<Vydejce> SelectBy(string jmeno = "", string prijmeni = "", string email = "");
        Vydejce Detail(int idVydejce);
        int Delete(int idVydejce);
    }
}
