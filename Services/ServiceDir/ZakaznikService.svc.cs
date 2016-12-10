using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ZakaznikService : IZakaznikService
    {
        public int Insert(Zakaznik zakaznik, Database pDb = null)
        {
            return ZakaznikTable.Insert(zakaznik, pDb);
        }

        public int Update(Zakaznik zakaznik, Database pDb = null)
        {
            return ZakaznikTable.Update(zakaznik, pDb);
        }

        public Collection<Zakaznik> Select(Database pDb = null)
        {
            return ZakaznikTable.Select(pDb);
        }

        public Collection<Zakaznik> SelectBy(string jmeno = "", string prijmeni = "", string email = "", Database pDb = null)
        {
            return ZakaznikTable.SelectBy(jmeno, prijmeni, email, pDb);
        }

        public Zakaznik Detail(int idZak, Database pDb = null)
        {
            return ZakaznikTable.Detail(idZak, pDb);
        }

        public int Delete(int idZak, Database pDb = null)
        {
            return ZakaznikTable.Delete(idZak, pDb);
        }
    }
}
