using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFrontaService
    {
        [OperationContract]
        int Insert(Fronta fronta, Database pDb = null);
        int Update(Fronta fronta, Database pDb = null);
        Collection<Fronta> Select(Database pDb = null);
        Collection<Fronta> SelectBy(int? idZak = null, int? idFilm = null, Database pDb = null);
        Fronta Detail(int idZak, int idFilm, Database pDb = null);
        int Delete(int idZak, int idFilm, Database pDb = null);
    }
}
