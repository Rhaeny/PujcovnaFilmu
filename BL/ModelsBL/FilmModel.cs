using System.Collections.ObjectModel;
using DTO;
using Services.ServiceDir;

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
        private FilmZanrService _filmZanrAdapter;
        private ZanrService _zanrAdapter;
        private OsZamFilmService _osZamFilmAdapter;
        private OsobaService _osobaAdapter;
        private RecenzeService _recenzeAdapter;
        private FrontaService _frontaAdapter;

        protected FilmZanrService FilmZanrAdapter
        {
            get
            {
                if (_filmZanrAdapter == null)
                {
                    _filmZanrAdapter = new FilmZanrService();
                }
                return _filmZanrAdapter;
            }
        }

        protected ZanrService ZanrAdapter
        {
            get
            {
                if (_zanrAdapter == null)
                {
                    _zanrAdapter = new ZanrService();
                }
                return _zanrAdapter;
            }
        }

        protected OsobaService OsobaAdapter
        {
            get
            {
                if (_osobaAdapter == null)
                {
                    _osobaAdapter = new OsobaService();
                }
                return _osobaAdapter;
            }
        }

        protected OsZamFilmService OsZamFilmAdapter
        {
            get
            {
                if (_osZamFilmAdapter == null)
                {
                    _osZamFilmAdapter = new OsZamFilmService();
                }
                return _osZamFilmAdapter;
            }
        }

        protected RecenzeService RecenzeAdapter
        {
            get
            {
                if (_recenzeAdapter == null)
                {
                    _recenzeAdapter = new RecenzeService();
                }
                return _recenzeAdapter;
            }
        }

        protected FrontaService FrontaAdapter
        {
            get
            {
                if (_frontaAdapter == null)
                {
                    _frontaAdapter = new FrontaService();
                }
                return _frontaAdapter;
            }
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
                Collection<FilmZanr> filmZanry = FilmZanrAdapter.SelectBy(idFilm: IdFilm);
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
                Collection<OsZamFilm> osZamFilms = OsZamFilmAdapter.SelectBy(idFilm: IdFilm, idZam: idZam);
                _osoby = new Collection<OsobaModel>();
                foreach (var osZamFilm in osZamFilms)
                {
                    OsobaModel osobaModel = new OsobaModel(OsobaAdapter.Detail(osZamFilm.IdOsoba));
                    _osoby.Add(osobaModel);
                }
            }
            return _osoby;
        }

        public Collection<RecenzeModel> GetRecenze()
        {
            if (_recenze == null)
            {
                Collection<Recenze> recenzes = RecenzeAdapter.SelectBy(idFilm: IdFilm);
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
                Collection<Fronta> fronta = FrontaAdapter.SelectBy(idFilm: IdFilm);
                _fronta = new Collection<FrontaModel>();
                foreach (var frontaItem in fronta)
                {
                    FrontaModel frontaModel = new FrontaModel(FrontaAdapter.Detail(frontaItem.IdZak, frontaItem.IdFilm));
                    _fronta.Add(frontaModel);
                }
            }
            return _fronta;
        }
    }
}
