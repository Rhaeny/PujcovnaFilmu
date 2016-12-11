using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FilmService : IFilmService
    {
        public int Insert(Film film)
        {
            return FilmGateway.Insert(film);
        }

        public int Update(Film film)
        {
            return FilmGateway.Update(film);
        }

        public Collection<Film> Select()
        {
            return FilmGateway.Select();
        }

        public Collection<Film> SelectBy(string nazev = "", int? rok = null, int? cena = null, int? kusu = null, string typ = "")
        {
            return FilmGateway.SelectBy(nazev, rok, cena, kusu, typ);
        }

        public Film Detail(int idFilm)
        {
            return FilmGateway.Detail(idFilm);
        }

        public int Delete(int idFilm)
        {
            return FilmGateway.Delete(idFilm);
        }
    }
}
