using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ZakaznikService : IZakaznikService
    {
        public int Insert(Zakaznik zakaznik, Database pDb = null)
        {
            return ZakaznikGateway.Insert(zakaznik, pDb);
        }

        public int Update(Zakaznik zakaznik, Database pDb = null)
        {
            return ZakaznikGateway.Update(zakaznik, pDb);
        }

        public Collection<Zakaznik> Select(Database pDb = null)
        {
            return ZakaznikGateway.Select(pDb);
        }

        public Collection<Zakaznik> SelectBy(string jmeno = "", string prijmeni = "", string email = "", Database pDb = null)
        {
            return ZakaznikGateway.SelectBy(jmeno, prijmeni, email, pDb);
        }

        public Zakaznik Detail(int idZak, Database pDb = null)
        {
            return ZakaznikGateway.Detail(idZak, pDb);
        }

        public int Delete(int idZak, Database pDb = null)
        {
            return ZakaznikGateway.Delete(idZak, pDb);
        }
    }
}
