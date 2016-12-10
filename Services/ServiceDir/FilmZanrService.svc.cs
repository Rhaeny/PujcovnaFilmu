using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FilmZanrService : IFilmZanrService
    {
        public int Insert(FilmZanr filmZanr, Database pDb = null)
        {
            return FilmZanrTable.Insert(filmZanr, pDb);
        }

        public Collection<FilmZanr> Select(Database pDb = null)
        {
            return FilmZanrTable.Select(pDb);
        }

        public Collection<FilmZanr> SelectBy(int? idZanr = null, int? idFilm = null, Database pDb = null)
        {
            return FilmZanrTable.SelectBy(idZanr, idFilm);
        }

        public int Delete(int idFilm, int idZanr, Database pDb = null)
        {
            return FilmZanrTable.Delete(idFilm, idZanr);
        }
    }
}
