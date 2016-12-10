using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IOsobaService
    {
        [OperationContract]
        int Insert(Osoba osoba, Database pDb = null);
        int Update(Osoba osoba, Database pDb = null);
        Collection<Osoba> Select(Database pDb = null);
        Collection<Osoba> SelectBy(string jmeno = "", string prijmeni = "", Database pDb = null);
        Osoba Detail(int idOsoba, Database pDb = null);
        int Delete(int idOsoba, Database pDb = null);
    }
}
