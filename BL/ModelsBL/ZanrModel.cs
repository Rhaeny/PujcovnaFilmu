using DTO;

namespace BL.ModelsBL
{
    public class ZanrModel
    {
        public int IdZanr { get; set; }
        public string Nazev { get; set; }

        public ZanrModel(Zanr zanr)
        {
            IdZanr = zanr.IdZanr;
            Nazev = zanr.Nazev;
        }

        public Zanr ToDTO()
        {
            Zanr zanr = new Zanr
            {
                IdZanr = IdZanr,
                Nazev = Nazev
            };
            return zanr;
        }
    }
}
