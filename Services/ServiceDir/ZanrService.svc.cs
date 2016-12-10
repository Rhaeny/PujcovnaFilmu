using System.Collections.ObjectModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    public class ZanrService : IZanrService
    {
        public int Insert(Zanr zanr, Database pDb = null)
        {
            return ZanrTable.Insert(zanr, pDb);
        }

        public int Update(Zanr zanr, Database pDb = null)
        {
            return ZanrTable.Update(zanr, pDb);
        }

        public Collection<Zanr> Select(Database pDb = null)
        {
            return ZanrTable.Select(pDb);
        }

        public Zanr Detail(int idZanr, Database pDb = null)
        {
            return ZanrTable.Detail(idZanr, pDb);
        }

        public int Delete(int idZanr, Database pDb = null)
        {
            return ZanrTable.Delete(idZanr, pDb);
        }
    }
}
