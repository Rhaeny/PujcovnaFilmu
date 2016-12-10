using System.Collections.ObjectModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    public class ZamestnaniService : IZamestnaniService
    {
        public int Insert(Zamestnani zam, Database pDb = null)
        {
            return ZamestnaniTable.Insert(zam, pDb);
        }

        public int Update(Zamestnani zam, Database pDb = null)
        {
            return ZamestnaniTable.Update(zam, pDb);
        }

        public Collection<Zamestnani> Select(Database pDb = null)
        {
            return ZamestnaniTable.Select(pDb);
        }

        public Zamestnani Detail(int idZam, Database pDb = null)
        {
            return ZamestnaniTable.Detail(idZam, pDb);
        }

        public int Delete(int idZam, Database pDb = null)
        {
            return ZamestnaniTable.Delete(idZam, pDb);
        }
    }
}
