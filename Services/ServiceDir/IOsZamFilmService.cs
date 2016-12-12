using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IOsZamFilmService
    {
        [OperationContract]
        int Insert(OsZamFilm osZamFilm);
        Collection<OsZamFilm> Select();
        Collection<OsZamFilm> SelectBy(OsZamFilmNull osZamFilmNull);
        OsZamFilm Detail(int idFilm, int idZam, int idOsoba);
        int Delete(int idZam, int idFilm, int idOsoba);
    }
}
