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

        [OperationContract]
        Collection<OsZamFilm> Select();

        [OperationContract]
        Collection<OsZamFilm> SelectBy(OsZamFilmNull osZamFilmNull);

        [OperationContract]
        OsZamFilm Detail(int idFilm, int idZam, int idOsoba);

        [OperationContract]
        int Delete(int idZam, int idFilm, int idOsoba);
    }
}
