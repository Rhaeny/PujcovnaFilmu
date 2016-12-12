using System.Collections.ObjectModel;
using BL.FilmReference;
using BL.ModelsBL;
using DTO;
using NullDTO;

namespace BL.ClassesBL
{
    public class FilmBL
    {
        private FilmServiceClient _filmAdapter;
        protected FilmServiceClient Adapter
        {
            get
            {
                if (_filmAdapter == null)
                {
                    _filmAdapter = new FilmServiceClient();
                }
                return _filmAdapter;
            }
        }

        public int Insert(FilmModel film)
        {
            return Adapter.Insert(film.ToDTO());
        }

        public int Update(FilmModel film)
        {
            return Adapter.Update(film.ToDTO());
        }

        public Collection<FilmModel> Select()
        {
            Collection<Film> films = Adapter.Select();
            Collection<FilmModel> ret = new Collection<FilmModel>();
            foreach (var film in films)
            {
                ret.Add(new FilmModel(film));
            }
            return ret;
        }

        public Collection<FilmModel> SelectBy(string nazev = "", int? rok = null, int? cena = null, int? kusu = null, string typ = "")
        {
            FilmNull filmNull = new FilmNull()
            {
                Cena = cena,
                Kusu = kusu,
                Nazev = nazev,
                Rok = rok,
                Typ = typ
            };
            Collection<Film> films = Adapter.SelectBy(filmNull);
            Collection<FilmModel> ret = new Collection<FilmModel>();
            foreach (var film in films)
            {
                ret.Add(new FilmModel(film));
            }
            return ret;
        }

        public FilmModel Detail(int idFilm)
        {
            return new FilmModel(Adapter.Detail(idFilm));
        }

        public int Delete(int idFilm)
        {
            return Adapter.Delete(idFilm);
        }
    }
}
