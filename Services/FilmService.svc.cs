using System.Collections.ObjectModel;
using ORM.DAO;
using ORM.DTO;

namespace Services
{
    public class FilmService : IFilmService
    {
        public void DoWork()
        {
        }

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
    }
}
