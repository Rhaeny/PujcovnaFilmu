using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FilmZanrService : IFilmZanrService
    {
        public int Insert(FilmZanr filmZanr, Database pDb = null)
        {
            return FilmZanrGateway.Insert(filmZanr, pDb);
        }

        public Collection<FilmZanr> Select(Database pDb = null)
        {
            return FilmZanrGateway.Select(pDb);
        }

        public Collection<FilmZanr> SelectBy(int? idZanr = null, int? idFilm = null, Database pDb = null)
        {
            return FilmZanrGateway.SelectBy(idZanr, idFilm);
        }

        public int Delete(int idFilm, int idZanr, Database pDb = null)
        {
            return FilmZanrGateway.Delete(idFilm, idZanr);
        }
    }
}
