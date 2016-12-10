using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ZanrService : IZanrService
    {
        public int Insert(Zanr zanr, Database pDb = null)
        {
            return ZanrGateway.Insert(zanr, pDb);
        }

        public int Update(Zanr zanr, Database pDb = null)
        {
            return ZanrGateway.Update(zanr, pDb);
        }

        public Collection<Zanr> Select(Database pDb = null)
        {
            return ZanrGateway.Select(pDb);
        }

        public Zanr Detail(int idZanr, Database pDb = null)
        {
            return ZanrGateway.Detail(idZanr, pDb);
        }

        public int Delete(int idZanr, Database pDb = null)
        {
            return ZanrGateway.Delete(idZanr, pDb);
        }
    }
}
