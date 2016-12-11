using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FilmZanrService : IFilmZanrService
    {
        public int Insert(FilmZanr filmZanr)
        {
            return FilmZanrGateway.Insert(filmZanr);
        }

        public Collection<FilmZanr> Select()
        {
            return FilmZanrGateway.Select();
        }

        public Collection<FilmZanr> SelectBy(int? idZanr = null, int? idFilm = null)
        {
            return FilmZanrGateway.SelectBy(idZanr, idFilm);
        }

        public int Delete(int idFilm, int idZanr)
        {
            return FilmZanrGateway.Delete(idFilm, idZanr);
        }
    }
}
