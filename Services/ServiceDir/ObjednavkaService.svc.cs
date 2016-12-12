using System.Collections.ObjectModel;
using DTO;
using NullDTO;
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

        public Collection<Objednavka> SelectBy(ObjednavkaNull objednavkaNull)
        {
            return ObjednavkaGateway.SelectBy(objednavkaNull.Vydano, objednavkaNull.Vraceno, objednavkaNull.IdZak,
                objednavkaNull.IdFilm, objednavkaNull.IdVydejce);
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
