using System.Collections.ObjectModel;
using BL.ModelsBL;
using BL.ZakaznikReference;
using DTO;
using NullDTO;

namespace BL.ClassesBL
{
    public class ZakaznikBL
    {
        private ZakaznikServiceClient _zakaznikAdapter;
        protected ZakaznikServiceClient Adapter
        {
            get
            {
                if (_zakaznikAdapter == null)
                {
                    _zakaznikAdapter = new ZakaznikServiceClient();
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
            ZakaznikNull zakaznikNull = new ZakaznikNull()
            {
                Jmeno = jmeno,
                Prijmeni = prijmeni,
                Email = email
            };
            Collection<Zakaznik> zakaznici = Adapter.SelectBy(zakaznikNull);
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
