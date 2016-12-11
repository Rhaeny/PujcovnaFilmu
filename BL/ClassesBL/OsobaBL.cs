using System.Collections.ObjectModel;
using BL.ModelsBL;
using DTO;
using ORM.DAO;
using Services.ServiceDir;

namespace BL.ClassesBL
{
    public class OsobaBL
    {
        private OsobaService _osobaAdapter;
        protected OsobaService Adapter
        {
            get
            {
                if (_osobaAdapter == null)
                {
                    _osobaAdapter = new OsobaService();
                }
                return _osobaAdapter;
            }
        }

        public int Insert(OsobaModel osoba)
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

        public Collection<Osoba> SelectBy(string jmeno = "", string prijmeni = "")
        {
            return OsobaGateway.SelectBy(jmeno, prijmeni);
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
