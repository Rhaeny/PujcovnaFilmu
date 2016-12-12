using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFilmService
    {
        [OperationContract]
        int Insert(Film film);

        [OperationContract]
        int Update(Film film);

        [OperationContract]
        Collection<Film> Select();

        [OperationContract]
        Collection<Film> SelectBy(FilmNull filmNull);

        [OperationContract]
        Film Detail(int idFilm);

        [OperationContract]
        int Delete(int idFilm);
    }
}
