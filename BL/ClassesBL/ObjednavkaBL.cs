using System.Collections.ObjectModel;
using BL.ModelsBL;
using BL.ObjednavkaReference;
using DTO;
using NullDTO;
using ORM.DAO;

namespace BL.ClassesBL
{
    public class ObjednavkaBL
    {
        private ObjednavkaServiceClient _objednavkaAdapter;

        protected ObjednavkaServiceClient Adapter
        {
            get
            {
                if (_objednavkaAdapter == null)
                {
                    _objednavkaAdapter = new ObjednavkaServiceClient();
                }
                return _objednavkaAdapter;
            }
        }

        public int Insert(ObjednavkaModel objednavka)
        {
            return ObjednavkaGateway.Insert(objednavka.ToDTO());
        }

        public int Update(ObjednavkaModel objednavka)
        {
            return ObjednavkaGateway.Update(objednavka.ToDTO());
        }

        public Collection<ObjednavkaModel> Select()
        {
            Collection<Objednavka> objednavky = Adapter.Select();
            Collection<ObjednavkaModel> ret = new Collection<ObjednavkaModel>();
            foreach (var objednavka in objednavky)
            {
                ret.Add(new ObjednavkaModel(objednavka));
            }
            return ret;
        }

        public Collection<ObjednavkaModel> SelectBy(bool? vydano = null, bool? vraceno = null,
            int? idZak = null, int? idFilm = null, int? idVydejce = null)
        {
            ObjednavkaNull objednavkaNull = new ObjednavkaNull()
            {
                Vydano = vydano,
                Vraceno = vraceno,
                IdZak = idZak,
                IdFilm = idZak,
                IdVydejce = idVydejce
            };
            Collection<Objednavka> objednavky = Adapter.SelectBy(objednavkaNull);
            Collection<ObjednavkaModel> ret = new Collection<ObjednavkaModel>();
            foreach (var objednavka in objednavky)
            {
                ret.Add(new ObjednavkaModel(objednavka));
            }
            return ret;
        }

        public ObjednavkaModel Detail(int idObj)
        {
            return new ObjednavkaModel(Adapter.Detail(idObj));
        }

        public int Delete(int idObj)
        {
            return Adapter.Delete(idObj);
        }
    }
}
