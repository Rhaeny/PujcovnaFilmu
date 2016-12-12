using System.Collections.ObjectModel;
using DTO;
using NullDTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class OsobaService : IOsobaService
    {
        public int Insert(Osoba osoba)
        {
            return OsobaGateway.Insert(osoba);
        }

        public int Update(Osoba osoba)
        {
            return OsobaGateway.Update(osoba);
        }

        public Collection<Osoba> Select()
        {
            return OsobaGateway.Select();
        }

        public Collection<Osoba> SelectBy(OsobaNull osobaNull)
        {
            return OsobaGateway.SelectBy(osobaNull.Jmeno, osobaNull.Prijmeni);
        }

        public Osoba Detail(int idOsoba)
        {
            return OsobaGateway.Detail(idOsoba);
        }

        public int Delete(int idOsoba)
        {
            return OsobaGateway.Delete(idOsoba);
        }
    }
}
