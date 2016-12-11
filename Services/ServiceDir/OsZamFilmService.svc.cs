using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class OsZamFilmService : IOsZamFilmService
    {
        public int Insert(OsZamFilm osZamFilm)
        {
            return OsZamFilmGateway.Insert(osZamFilm);
        }

        public Collection<OsZamFilm> Select()
        {
            return OsZamFilmGateway.Select();
        }

        public Collection<OsZamFilm> SelectBy(int? idZam = null, int? idFilm = null, int? idOsoba = null)
        {
            return OsZamFilmGateway.SelectBy(idZam, idFilm, idOsoba);
        }

        public OsZamFilm Detail(int idZam, int idFilm, int idOsoba)
        {
            return OsZamFilmGateway.Detail(idZam, idFilm, idOsoba);
        }

        public int Delete(int idZam, int idFilm, int idOsoba)
        {
            return OsZamFilmGateway.Delete(idZam, idFilm, idOsoba);
        }
    }
}
