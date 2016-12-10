using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FilmService : IFilmService
    {
        public int Insert(Film film, Database pDb = null)
        {
            return FilmTable.Insert(film, pDb);
        }

        public int Update(Film film, Database pDb = null)
        {
            return FilmTable.Update(film, pDb);
        }

        public Collection<Film> Select(Database pDb = null)
        {
            return FilmTable.Select(pDb);
        }

        public Collection<Film> SelectBy(string nazev = "", int? rok = null, int? cena = null, int? kusu = null,
            string typ = "", Database pDb = null)
        {
            return FilmTable.SelectBy(nazev, rok, cena, kusu, typ, pDb);
        }

        public Film Detail(int idFilm, Database pDb = null)
        {
            return FilmTable.Detail(idFilm, pDb);
        }

        public int Delete(int idFilm, Database pDb = null)
        {
            return FilmTable.Delete(idFilm, pDb);
        }
    }
}
