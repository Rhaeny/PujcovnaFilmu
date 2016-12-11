using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFilmZanrService
    {
        [OperationContract]
        int Insert(FilmZanr filmZanr);
        Collection<FilmZanr> Select();
        Collection<FilmZanr> SelectBy(int? idZanr = null, int? idFilm = null);
        int Delete(int idFilm, int idZanr);
    }
}
