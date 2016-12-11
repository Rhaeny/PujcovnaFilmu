using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ObjednavkaService : IObjednavkaService
    {
        public int Insert(Objednavka objednavka)
        {
            return ObjednavkaGateway.Insert(objednavka);
        }

        public int Update(Objednavka objednavka)
        {
            return ObjednavkaGateway.Update(objednavka);
        }

        public Collection<Objednavka> Select()
        {
            return ObjednavkaGateway.Select();
        }

        public Collection<Objednavka> SelectBy(char? vydano = null, char? vraceno = null, 
            int? idZak = null, int? idFilm = null, int? idVydejce = null)
        {
            return ObjednavkaGateway.SelectBy(vydano, vraceno, idZak, idFilm, idVydejce);
        }

        public Objednavka Detail(int idObj)
        {
            return ObjednavkaGateway.Detail(idObj);
        }

        public int Delete(int idObj)
        {
            return ObjednavkaGateway.Delete(idObj);
        }
    }
}
