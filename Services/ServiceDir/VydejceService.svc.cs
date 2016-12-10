using System.Collections.ObjectModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    public class VydejceService : IVydejceService
    {
        public int Insert(Vydejce vydejce, Database pDb = null)
        {
            return VydejceTable.Insert(vydejce, pDb);
        }

        public int Update(Vydejce vydejce, Database pDb = null)
        {
            return VydejceTable.Update(vydejce, pDb);
        }

        public Collection<Vydejce> Select(Database pDb = null)
        {
            return VydejceTable.Select(pDb);
        }

        public Collection<Vydejce> SelectBy(string jmeno = "", string prijmeni = "", string email = "", Database pDb = null)
        {
            return VydejceTable.SelectBy(jmeno, prijmeni, email, pDb);
        }

        public Vydejce Detail(int idVydejce, Database pDb = null)
        {
            return VydejceTable.Detail(idVydejce, pDb);
        }

        public int Delete(int idVydejce, Database pDb = null)
        {
            return VydejceTable.Delete(idVydejce, pDb);
        }
    }
}
