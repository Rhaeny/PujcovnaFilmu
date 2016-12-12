using System.Collections.ObjectModel;
using DTO;
using NullDTO;
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

        public Collection<FilmZanr> SelectBy(FilmZanrNull filmZanrNull)
        {
            return FilmZanrGateway.SelectBy(filmZanrNull.IdZanr, filmZanrNull.IdFilm);
        }

        public int Delete(int idFilm, int idZanr)
        {
            return FilmZanrGateway.Delete(idFilm, idZanr);
        }
    }
}
