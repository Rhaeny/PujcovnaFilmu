using System;

namespace DTO
{
    public class Recenze
    {
        public int IdZak { get; set; }
        public int IdFilm { get; set; }
        public DateTime Datum { get; set; }
        public int Cislo { get; set; }
        public string Text { get; set; }
    }
}
