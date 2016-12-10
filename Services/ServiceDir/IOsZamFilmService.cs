using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IOsZamFilmService
    {
        [OperationContract]
        int Insert(OsZamFilm osZamFilm, Database pDb = null);
        Collection<OsZamFilm> Select(Database pDb = null);
        Collection<OsZamFilm> SelectBy(int? idZam = null, int? idFilm = null, int? idOsoba = null, Database pDb = null);
        OsZamFilm Detail(int idFilm, int idZam, int idOsoba, Database pDb = null);
        int Delete(int idZam, int idFilm, int idOsoba, Database pDb = null);
    }
}
