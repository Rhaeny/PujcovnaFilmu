using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ZamestnaniService : IZamestnaniService
    {
        public int Insert(Zamestnani zam, Database pDb = null)
        {
            return ZamestnaniGateway.Insert(zam, pDb);
        }

        public int Update(Zamestnani zam, Database pDb = null)
        {
            return ZamestnaniGateway.Update(zam, pDb);
        }

        public Collection<Zamestnani> Select(Database pDb = null)
        {
            return ZamestnaniGateway.Select(pDb);
        }

        public Zamestnani Detail(int idZam, Database pDb = null)
        {
            return ZamestnaniGateway.Detail(idZam, pDb);
        }

        public int Delete(int idZam, Database pDb = null)
        {
            return ZamestnaniGateway.Delete(idZam, pDb);
        }
    }
}
