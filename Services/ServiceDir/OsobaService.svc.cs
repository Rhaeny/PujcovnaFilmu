using System.Collections.ObjectModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    public class OsobaService : IOsobaService
    {
        public int Insert(Osoba osoba, Database pDb = null)
        {
            return OsobaTable.Insert(osoba, pDb);
        }

        public int Update(Osoba osoba, Database pDb = null)
        {
            return OsobaTable.Update(osoba, pDb);
        }

        public Collection<Osoba> Select(Database pDb = null)
        {
            return OsobaTable.Select(pDb);
        }

        public Collection<Osoba> SelectBy(string jmeno = "", string prijmeni = "", Database pDb = null)
        {
            return OsobaTable.SelectBy(jmeno, prijmeni, pDb);
        }

        public Osoba Detail(int idOsoba, Database pDb = null)
        {
            return OsobaTable.Detail(idOsoba, pDb);
        }

        public int Delete(int idOsoba, Database pDb = null)
        {
            return OsobaTable.Delete(idOsoba, pDb);
        }
    }
}
