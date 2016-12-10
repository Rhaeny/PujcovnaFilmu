using System.Collections.ObjectModel;
using ORM.DAO;

namespace ORM.DTO
{
    public class Zakaznik
    {
        public int IdZak { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        private Collection<Objednavka> _objednavky;
        public Collection<Objednavka> GetObjednavky(Database pDb = null)
        {
            if (_objednavky == null)
            {
                _objednavky = ObjednavkaTable.SelectBy(idZak: IdZak, pDb: pDb);
;           }
            return _objednavky;
        }
    }
}
