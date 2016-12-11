using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFilmService
    {
        [OperationContract]
        int Insert(Film film);
        int Update(Film film);
        Collection<Film> Select();
        Collection<Film> SelectBy(string nazev = "", int? rok = null, int? cena = null, int? kusu = null, string typ = "");
        Film Detail(int idFilm);
        int Delete(int idFilm);
    }
}
