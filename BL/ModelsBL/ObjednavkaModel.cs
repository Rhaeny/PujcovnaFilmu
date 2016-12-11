using System;
using DTO;

namespace BL.ModelsBL
{
    public class ObjednavkaModel
    {
        public int IdObj { get; set; }
        public DateTime DatumObj { get; set; }
        public int DobaPujceni { get; set; }
        public bool Vydano { get; set; }
        public DateTime? DatumVydani { get; set; }
        public bool Vraceno { get; set; }
        public DateTime? DatumVraceni { get; set; }
        public int IdZak { get; set; }
        public int IdFilm { get; set; }
        public int IdVydejce { get; set; }

        public ObjednavkaModel(Objednavka objednavka)
        {
            IdObj = objednavka.IdObj;
            DatumObj = objednavka.DatumObj;
            DobaPujceni = objednavka.DobaPujceni;
            Vydano = objednavka.Vydano;
            DatumVydani = objednavka.DatumVydani;
            Vraceno = objednavka.Vraceno;
            DatumVraceni = objednavka.DatumVraceni;
            IdZak = objednavka.IdZak;
            IdFilm = objednavka.IdFilm;
            IdVydejce = objednavka.IdVydejce;
        }

        public Objednavka ToDTO()
        {
            Objednavka objednavka = new Objednavka()
            {
                IdObj = IdObj,
                DatumObj = DatumObj,
                DobaPujceni = DobaPujceni,
                Vydano = Vydano,
                DatumVydani = DatumVydani,
                Vraceno = Vraceno,
                DatumVraceni = DatumVraceni,
                IdZak = IdZak,
                IdFilm = IdFilm,
                IdVydejce = IdVydejce
            };
            return objednavka;
        }
    }
}
