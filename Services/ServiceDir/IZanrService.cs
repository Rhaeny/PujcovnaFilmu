using System.Collections.ObjectModel;
using System.ServiceModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IZanrService
    {
        [OperationContract]
        int Insert(Zanr zanr, Database pDb = null);
        int Update(Zanr zanr, Database pDb = null);
        Collection<Zanr> Select(Database pDb = null);
        Zanr Detail(int idZanr, Database pDb = null);
        int Delete(int idZanr, Database pDb = null);
    }
}
