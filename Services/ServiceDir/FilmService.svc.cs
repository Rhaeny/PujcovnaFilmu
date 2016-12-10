using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FilmService : IFilmService
    {
        public int Insert(Film film, Database pDb = null)
        {
            return FilmGateway.Insert(film, pDb);
        }

        public int Update(Film film, Database pDb = null)
        {
            return FilmGateway.Update(film, pDb);
        }

        public Collection<Film> Select(Database pDb = null)
        {
            return FilmGateway.Select(pDb);
        }

        public Collection<Film> SelectBy(string nazev = "", int? rok = null, int? cena = null, int? kusu = null,
            string typ = "", Database pDb = null)
        {
            return FilmGateway.SelectBy(nazev, rok, cena, kusu, typ, pDb);
        }

        public Film Detail(int idFilm, Database pDb = null)
        {
            return FilmGateway.Detail(idFilm, pDb);
        }

        public int Delete(int idFilm, Database pDb = null)
        {
            return FilmGateway.Delete(idFilm, pDb);
        }
    }
}
