using System;

namespace ORM.DTO
{
    public class Objednavka
    {
        public int IdObj { get; set; }
        public DateTime DatumObj { get; set; }
        public int DobaPujceni { get; set; }
        public char Vydano { get; set; }
        public DateTime? DatumVydani { get; set; }
        public char Vraceno { get; set; }
        public DateTime? DatumVraceni { get; set; }
        public int IdZak { get; set; }
        public int IdFilm { get; set; }
        public int IdVydejce { get; set; }
    }
}
