using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class VydejceService : IVydejceService
    {
        public int Insert(Vydejce vydejce, Database pDb = null)
        {
            return VydejceGateway.Insert(vydejce, pDb);
        }

        public int Update(Vydejce vydejce, Database pDb = null)
        {
            return VydejceGateway.Update(vydejce, pDb);
        }

        public Collection<Vydejce> Select(Database pDb = null)
        {
            return VydejceGateway.Select(pDb);
        }

        public Collection<Vydejce> SelectBy(string jmeno = "", string prijmeni = "", string email = "", Database pDb = null)
        {
            return VydejceGateway.SelectBy(jmeno, prijmeni, email, pDb);
        }

        public Vydejce Detail(int idVydejce, Database pDb = null)
        {
            return VydejceGateway.Detail(idVydejce, pDb);
        }

        public int Delete(int idVydejce, Database pDb = null)
        {
            return VydejceGateway.Delete(idVydejce, pDb);
        }
    }
}
