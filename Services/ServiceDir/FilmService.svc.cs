using System.Collections.ObjectModel;
using DTO;
using NullDTO;
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

        public Collection<Film> SelectBy(FilmNull filmNull)
        {
            return FilmGateway.SelectBy(filmNull.Nazev, filmNull.Rok, filmNull.Cena, filmNull.Kusu, filmNull.Typ);
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
