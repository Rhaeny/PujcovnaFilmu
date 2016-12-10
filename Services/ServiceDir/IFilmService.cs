using System.Collections.ObjectModel;
using System.ServiceModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFilmService
    {
        [OperationContract]
        int Insert(Film film, Database pDb = null);
        int Update(Film film, Database pDb = null);
        Collection<Film> Select(Database pDb = null);
        Collection<Film> SelectBy(string nazev = "", int? rok = null, int? cena = null, int? kusu = null, string typ = "", Database pDb = null);
        Film Detail(int idFilm, Database pDb = null);
        int Delete(int idFilm, Database pDb = null);
    }
}
