using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IRecenzeService
    {
        [OperationContract]
        int Insert(Recenze recenze, Database pDb = null);
        int Update(Recenze recenze, Database pDb = null);
        Collection<Recenze> Select(Database pDb = null);
        Collection<Recenze> SelectBy(int? idZak = null, int? idFilm = null, int? cislo = null, Database pDb = null);
        Recenze Detail(int idZak, int idFilm, Database pDb = null);
        int Delete(int idZak, int idFilm, Database pDb = null);
    }
}
