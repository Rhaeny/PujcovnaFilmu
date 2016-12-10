using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ObjednavkaService : IObjednavkaService
    {
        public int Insert(Objednavka objednavka, Database pDb = null)
        {
            return ObjednavkaTable.Insert(objednavka, pDb);
        }

        public int Update(Objednavka objednavka, Database pDb = null)
        {
            return ObjednavkaTable.Update(objednavka, pDb);
        }

        public Collection<Objednavka> Select(Database pDb = null)
        {
            return ObjednavkaTable.Select(pDb);
        }

        public Collection<Objednavka> SelectBy(char? vydano = null, char? vraceno = null,
            int? idZak = null, int? idFilm = null, int? idVydejce = null, Database pDb = null)
        {
            return ObjednavkaTable.SelectBy(vydano, vraceno, idZak, idFilm, idVydejce, pDb);
        }

        public Objednavka Detail(int idObj, Database pDb = null)
        {
            return ObjednavkaTable.Detail(idObj, pDb);
        }

        public int Delete(int idObj, Database pDb = null)
        {
            return ObjednavkaTable.Delete(idObj, pDb);
        }
    }
}
