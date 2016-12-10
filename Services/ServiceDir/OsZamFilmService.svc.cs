using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class OsZamFilmService : IOsZamFilmService
    {
        public int Insert(OsZamFilm osZamFilm, Database pDb = null)
        {
            return OsZamFilmGateway.Insert(osZamFilm, pDb);
        }

        public Collection<OsZamFilm> Select(Database pDb = null)
        {
            return OsZamFilmGateway.Select(pDb);
        }

        public Collection<OsZamFilm> SelectBy(int? idZam = null, int? idFilm = null, int? idOsoba = null,
            Database pDb = null)
        {
            return OsZamFilmGateway.SelectBy(idZam, idFilm, idOsoba);
        }

        public OsZamFilm Detail(int idZam, int idFilm, int idOsoba, Database pDb = null)
        {
            return OsZamFilmGateway.Detail(idZam, idFilm, idOsoba, pDb);
        }

        public int Delete(int idZam, int idFilm, int idOsoba, Database pDb = null)
        {
            return OsZamFilmGateway.Delete(idZam, idFilm, idOsoba, pDb);
        }
    }
}
