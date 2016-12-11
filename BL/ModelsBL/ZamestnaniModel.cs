using DTO;

namespace BL.ModelsBL
{
    public class ZamestnaniModel
    {
        public int IdZam { get; set; }
        public string Nazev { get; set; }

        public ZamestnaniModel(Zamestnani zam)
        {
            IdZam = zam.IdZam;
            Nazev = zam.Nazev;
        }

        public Zamestnani ToDTO()
        {
            Zamestnani zam = new Zamestnani
            {
                IdZam = IdZam,
                Nazev = Nazev
            };
            return zam;
        }
    }
}
