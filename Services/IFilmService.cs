using System.Collections.ObjectModel;
using System.ServiceModel;
using ORM.DAO;
using ORM.DTO;

namespace Services
{
    [ServiceContract]
    public interface IFilmService
    {
        [OperationContract]
        void DoWork();
        int Insert(Film film, Database pDb = null);
        int Update(Film film, Database pDb = null);
        Collection<Film> Select(Database pDb = null);
    }
}
