using System.Collections.ObjectModel;
using System.ServiceModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFilmZanrService
    {
        [OperationContract]
        int Insert(FilmZanr filmZanr, Database pDb = null);
        Collection<FilmZanr> Select(Database pDb = null);
        Collection<FilmZanr> SelectBy(int? idZanr = null, int? idFilm = null, Database pDb = null);
        int Delete(int idFilm, int idZanr, Database pDb = null);
    }
}
