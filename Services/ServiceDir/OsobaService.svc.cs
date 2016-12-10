using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class OsobaService : IOsobaService
    {
        public int Insert(Osoba osoba, Database pDb = null)
        {
            return OsobaGateway.Insert(osoba, pDb);
        }

        public int Update(Osoba osoba, Database pDb = null)
        {
            return OsobaGateway.Update(osoba, pDb);
        }

        public Collection<Osoba> Select(Database pDb = null)
        {
            return OsobaGateway.Select(pDb);
        }

        public Collection<Osoba> SelectBy(string jmeno = "", string prijmeni = "", Database pDb = null)
        {
            return OsobaGateway.SelectBy(jmeno, prijmeni, pDb);
        }

        public Osoba Detail(int idOsoba, Database pDb = null)
        {
            return OsobaGateway.Detail(idOsoba, pDb);
        }

        public int Delete(int idOsoba, Database pDb = null)
        {
            return OsobaGateway.Delete(idOsoba, pDb);
        }
    }
}
