using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IZamestnaniService
    {
        [OperationContract]
        int Insert(Zamestnani zam, Database pDb = null);
        int Update(Zamestnani zam, Database pDb = null);
        Collection<Zamestnani> Select(Database pDb = null);
        Zamestnani Detail(int idZam, Database pDb = null);
        int Delete(int idZam, Database pDb = null);
    }
}
