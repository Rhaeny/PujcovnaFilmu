using System;
using DTO;
using Services.ServiceDir;

namespace BL.ModelsBL
{
    public class RecenzeModel
    {
        public int IdZak { get; set; }
        public int IdFilm { get; set; }
        public DateTime Datum { get; set; }
        public int Cislo { get; set; }
        public string Text { get; set; }

        private ZakaznikModel _zakaznik;
        private ZakaznikService _zakaznikAdapter;

        protected ZakaznikService ZakaznikAdapter
        {
            get
            {
                if (_zakaznikAdapter == null)
                {
                    _zakaznikAdapter = new ZakaznikService();
                }
                return _zakaznikAdapter;
            }
        }

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

        public ZakaznikModel GetZakaznik()
        {
            if (_zakaznik == null)
            {
                _zakaznik = new ZakaznikModel(ZakaznikAdapter.Detail(IdZak));
            }
            return _zakaznik;
        }
    }
}
