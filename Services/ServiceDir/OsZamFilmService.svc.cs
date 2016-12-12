using System.Collections.ObjectModel;
using DTO;
using NullDTO;
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

        public Collection<OsZamFilm> SelectBy(OsZamFilmNull osZamFilmNull)
        {
            return OsZamFilmGateway.SelectBy(osZamFilmNull.IdZam, osZamFilmNull.IdFilm, osZamFilmNull.IdOsoba);
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
