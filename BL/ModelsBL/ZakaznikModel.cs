using DTO;

namespace BL.ModelsBL
{
    public class ZakaznikModel
    {
        public int IdZak { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public ZakaznikModel(Zakaznik zakaznik)
        {
            IdZak = zakaznik.IdZak;
            Jmeno = zakaznik.Jmeno;
            Prijmeni = zakaznik.Prijmeni;
            Email = zakaznik.Email;
            Telefon = zakaznik.Telefon;
        }

        public Zakaznik ToDTO()
        {
            Zakaznik zakaznik = new Zakaznik()
            {
                IdZak = IdZak,
                Jmeno = Jmeno,
                Prijmeni = Prijmeni,
                Email = Email,
                Telefon = Telefon
            };
            return zakaznik;
        }
    }
}
