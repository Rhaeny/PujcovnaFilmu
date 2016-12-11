using System.Collections.ObjectModel;
using BL.ModelsBL;
using DTO;
using ORM.DAO;
using Services.ServiceDir;

namespace BL.ClassesBL
{
    public class ZakaznikBL
    {
        private ZakaznikService _zakaznikAdapter;
        protected ZakaznikService Adapter
        {
            get
            {
                if (_zakaznikAdapter == null)
                {
                    _zakaznikAdapter = new ZakaznikService();
                }
                return _zakaznikAdapter;
            }
        }

        public int Insert(ZakaznikModel zakaznik)
        {
            return Adapter.Insert(zakaznik.ToDTO());
        }

        public int Update(ZakaznikModel zakaznik)
        {
            return Adapter.Update(zakaznik.ToDTO());
        }

        public Collection<ZakaznikModel> Select()
        {
            Collection<Zakaznik> zakaznici = Adapter.Select();
            Collection<ZakaznikModel> ret = new Collection<ZakaznikModel>();
            foreach (var zakaznik in zakaznici)
            {
                ret.Add(new ZakaznikModel(zakaznik));
            }
            return ret;
        }

        public Collection<ZakaznikModel> SelectBy(string jmeno = "", string prijmeni = "", string email = "")
        {
            Collection<Zakaznik> zakaznici = Adapter.SelectBy(jmeno, prijmeni, email);
            Collection<ZakaznikModel> ret = new Collection<ZakaznikModel>();
            foreach (var zakaznik in zakaznici)
            {
                ret.Add(new ZakaznikModel(zakaznik));
            }
            return ret;
        }

        public ZakaznikModel Detail(int idZak)
        {
            return new ZakaznikModel(Adapter.Detail(idZak));
        }

        public int Delete(int idZak)
        {
            return Adapter.Delete(idZak);
        }
    }
}
