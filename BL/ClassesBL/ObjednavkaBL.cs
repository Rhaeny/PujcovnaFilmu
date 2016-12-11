using System.Collections.ObjectModel;
using BL.ModelsBL;
using DTO;
using ORM.DAO;
using Services.ServiceDir;

namespace BL.ClassesBL
{
    public class ObjednavkaBL
    {
        private ObjednavkaService _objednavkaAdapter;

        protected ObjednavkaService Adapter
        {
            get
            {
                if (_objednavkaAdapter == null)
                {
                    _objednavkaAdapter = new ObjednavkaService();
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

        public Collection<ObjednavkaModel> SelectBy(char? vydano = null, char? vraceno = null,
            int? idZak = null, int? idFilm = null, int? idVydejce = null)
        {
            Collection<Objednavka> objednavky = Adapter.SelectBy(vydano, vraceno, idZak, idFilm, idVydejce);
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
