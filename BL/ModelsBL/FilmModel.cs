﻿using System.Collections.ObjectModel;
using System.Linq;
using BL.FilmZanrReference;
using BL.FrontaReference;
using BL.OsobaReference;
using BL.OsZamServiceReference;
using BL.RecenzeReference;
using BL.ZanrReference;
using DTO;
using NullDTO;

namespace BL.ModelsBL
{
    public class FilmModel
    {
        public int IdFilm { get; set; }
        public string Nazev { get; set; }
        public int Rok { get; set; }
        public int Cena { get; set; }
        public int Kusu { get; set; }
        public string Typ { get; set; }
        public int? Delka { get; set; }
        public string Zeme { get; set; }
        public string Popis { get; set; }

        private Collection<ZanrModel> _zanry;
        private Collection<OsobaModel> _osoby;
        private Collection<RecenzeModel> _recenze;
        private Collection<FrontaModel> _fronta;
        private FilmZanrServiceClient _filmZanrAdapter;
        private ZanrServiceClient _zanrAdapter;
        private OsobaServiceClient _osobaAdapter;
        private OsZamFilmServiceClient _osZamFilmAdapter;
        private RecenzeServiceClient _recenzeAdapter;
        private FrontaServiceClient _frontaAdapter;

        protected FilmZanrServiceClient FilmZanrAdapter
        {
            get
            {
                if (_filmZanrAdapter == null)
                {
                    _filmZanrAdapter = new FilmZanrServiceClient();
                }
                return _filmZanrAdapter;
            }
        }

        protected ZanrServiceClient ZanrAdapter
        {
            get
            {
                if (_zanrAdapter == null)
                {
                    _zanrAdapter = new ZanrServiceClient();
                }
                return _zanrAdapter;
            }
        }

        protected OsobaServiceClient OsobaAdapter
        {
            get
            {
                if (_osobaAdapter == null)
                {
                    _osobaAdapter = new OsobaServiceClient();
                }
                return _osobaAdapter;
            }
        }

        protected OsZamFilmServiceClient OsZamFilmAdapter
        {
            get
            {
                if (_osZamFilmAdapter == null)
                {
                    _osZamFilmAdapter = new OsZamFilmServiceClient();
                }
                return _osZamFilmAdapter;
            }
        }

        protected RecenzeServiceClient RecenzeAdapter
        {
            get
            {
                if (_recenzeAdapter == null)
                {
                    _recenzeAdapter = new RecenzeServiceClient();
                }
                return _recenzeAdapter;
            }
        }

        protected FrontaServiceClient FrontaAdapter
        {
            get
            {
                if (_frontaAdapter == null)
                {
                    _frontaAdapter = new FrontaServiceClient();
                }
                return _frontaAdapter;
            }
        }

        public FilmModel()
        {
            
        }

        public FilmModel(Film film)
        {
            IdFilm = film.IdFilm;
            Nazev = film.Nazev;
            Rok = film.Rok;
            Cena = film.Cena;
            Kusu = film.Kusu;
            Typ = film.Typ;
            Delka = film.Delka;
            Zeme = film.Zeme;
            Popis = film.Popis;
        }

        public Film ToDTO()
        {
            Film film = new Film
            {
                IdFilm = IdFilm,
                Nazev = Nazev,
                Rok = Rok,
                Cena = Cena,
                Kusu = Kusu,
                Typ = Typ,
                Delka = Delka,
                Zeme = Zeme,
                Popis = Popis
            };
            return film;
        }

        public Collection<ZanrModel> GetZanry()
        {
            if (_zanry == null)
            {
                FilmZanrNull filmZanrNull = new FilmZanrNull {IdFilm = IdFilm};
                Collection<FilmZanr> filmZanry = FilmZanrAdapter.SelectBy(filmZanrNull);
                _zanry = new Collection<ZanrModel>();
                foreach (var filmZanr in filmZanry)
                {
                    ZanrModel zanrModel = new ZanrModel(ZanrAdapter.Detail(filmZanr.IdZanr));
                    _zanry.Add(zanrModel);
                }
            }
            return _zanry;
        }

        public Collection<OsobaModel> GetOsoby(int idZam)
        {
            if (_osoby == null)
            {
                _osoby = new Collection<OsobaModel>();
            }
            else
            {
                _osoby.Clear();
            }
            OsZamFilmNull osZamFilmNull = new OsZamFilmNull()
            {
                IdFilm = IdFilm,
                IdZam = idZam
            };
            Collection<OsZamFilm> osZamFilms = OsZamFilmAdapter.SelectBy(osZamFilmNull);
            foreach (var osZamFilm in osZamFilms)
            {
                OsobaModel osobaModel = new OsobaModel(OsobaAdapter.Detail(osZamFilm.IdOsoba));
                _osoby.Add(osobaModel);
            }
            return _osoby;
        }

        public Collection<RecenzeModel> GetRecenze()
        {
            if (_recenze == null)
            {
                RecenzeNull recenzeNull = new RecenzeNull()
                {
                    IdFilm = IdFilm
                };
                Collection<Recenze> recenzes = RecenzeAdapter.SelectBy(recenzeNull);
                _recenze = new Collection<RecenzeModel>();
                foreach (var recenze in recenzes)
                {
                    RecenzeModel recenzeModel = new RecenzeModel(RecenzeAdapter.Detail(recenze.IdZak, recenze.IdFilm));
                    _recenze.Add(recenzeModel);
                }
            }
            return _recenze;
        }

        public Collection<FrontaModel> GetFronta()
        {
            if (_fronta == null)
            {
                FrontaNull frontaNull = new FrontaNull()
                {
                    IdFilm = IdFilm
                };
                Collection<Fronta> fronta = FrontaAdapter.SelectBy(frontaNull);
                _fronta = new Collection<FrontaModel>();
                foreach (var frontaItem in fronta)
                {
                    FrontaModel frontaModel = new FrontaModel(FrontaAdapter.Detail(frontaItem.IdZak, frontaItem.IdFilm));
                    _fronta.Add(frontaModel);
                }
            }
            return _fronta;
        }

        public double GetPrumerneHodnoceni()
        {
            GetRecenze();
            int sum = _recenze.Sum(recenze => recenze.Cislo);
            return (double)sum/_recenze.Count;
        }
    }
}
