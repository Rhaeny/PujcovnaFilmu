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

        [OperationContract]
        Collection<FilmZanr> Select();

        [OperationContract]
        Collection<FilmZanr> SelectBy(FilmZanrNull filmZanrNull);

        [OperationContract]
        int Delete(int idFilm, int idZanr);
    }
}
