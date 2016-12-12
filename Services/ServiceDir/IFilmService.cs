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
        int Update(Film film);
        Collection<Film> Select();
        Collection<Film> SelectBy(FilmNull filmNull);
        Film Detail(int idFilm);
        int Delete(int idFilm);
    }
}
