using DTO;

namespace BL.ModelsBL
{
    public class OsobaModel
    {
        public int IdOsoba { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Biografie { get; set; }

        public OsobaModel(Osoba osoba)
        {
            IdOsoba = osoba.IdOsoba;
            Jmeno = osoba.Jmeno;
            Prijmeni = osoba.Prijmeni;
            Biografie = osoba.Biografie;
        }

        public Osoba ToDTO()
        {
            Osoba osoba = new Osoba
            {
                IdOsoba = IdOsoba,
                Jmeno = Jmeno,
                Prijmeni = Prijmeni,
                Biografie = Biografie
            };
            return osoba;
        }
    }
}
