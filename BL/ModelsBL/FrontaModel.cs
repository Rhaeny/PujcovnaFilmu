using System;
using DTO;

namespace BL.ModelsBL
{
    public class FrontaModel
    {
        public int IdZak { get; set; }
        public int IdFilm { get; set; }
        public DateTime Datum { get; set; }
        public string Poznamka { get; set; }

        public FrontaModel(Fronta fronta)
        {
            IdZak = fronta.IdZak;
            IdFilm = fronta.IdFilm;
            Datum = fronta.Datum;
            Poznamka = fronta.Poznamka;
        }

        public Fronta ToDTO()
        {
            Fronta fronta = new Fronta()
            {
                IdZak = IdZak,
                IdFilm = IdFilm,
                Datum = Datum,
                Poznamka = Poznamka
            };
            return fronta;
        }
    }
}
