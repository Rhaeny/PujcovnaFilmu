using System.Collections.ObjectModel;
using System.ServiceModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IVydejceService
    {
        [OperationContract]
        int Insert(Vydejce vydejce, Database pDb = null);
        int Update(Vydejce vydejce, Database pDb = null);
        Collection<Vydejce> Select(Database pDb = null);
        Collection<Vydejce> SelectBy(string jmeno = "", string prijmeni = "", string email = "", Database pDb = null);
        Vydejce Detail(int idVydejce, Database pDb = null);
        int Delete(int idVydejce, Database pDb = null);
    }
}
