using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IZakaznikService
    {
        [OperationContract]
        int Insert(Zakaznik zakaznik, Database pDb = null);
        int Update(Zakaznik zakaznik, Database pDb = null);
        Collection<Zakaznik> Select(Database pDb = null);
        Collection<Zakaznik> SelectBy(string jmeno = "", string prijmeni = "", string email = "", Database pDb = null);
        Zakaznik Detail(int idZak, Database pDb = null);
        int Delete(int idZak, Database pDb = null);
    }
}
