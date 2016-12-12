using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFilmZanrService
    {
        [OperationContract]
        int Insert(FilmZanr filmZanr);
        Collection<FilmZanr> Select();
        Collection<FilmZanr> SelectBy(FilmZanrNull filmZanrNull);
        int Delete(int idFilm, int idZanr);
    }
}
