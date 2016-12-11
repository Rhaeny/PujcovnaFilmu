using System;
using DTO;

namespace BL.ModelsBL
{
    public class RecenzeModel
    {
        public int IdZak { get; set; }
        public int IdFilm { get; set; }
        public DateTime Datum { get; set; }
        public int Cislo { get; set; }
        public string Text { get; set; }

        public RecenzeModel(Recenze recenze)
        {
            IdZak = recenze.IdZak;
            IdFilm = recenze.IdFilm;
            Datum = recenze.Datum;
            Cislo = recenze.Cislo;
            Text = recenze.Text;
        }

        public Recenze ToDTO()
        {
            Recenze recenze = new Recenze()
            {
                IdZak = IdZak,
                IdFilm = IdFilm,
                Datum = Datum,
                Cislo = Cislo,
                Text = Text
            };
            return recenze;
        }
    }
}
