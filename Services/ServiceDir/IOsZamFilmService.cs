using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IOsZamFilmService
    {
        [OperationContract]
        int Insert(OsZamFilm osZamFilm);
        Collection<OsZamFilm> Select();
        Collection<OsZamFilm> SelectBy(int? idZam = null, int? idFilm = null, int? idOsoba = null);
        OsZamFilm Detail(int idFilm, int idZam, int idOsoba);
        int Delete(int idZam, int idFilm, int idOsoba);
    }
}
