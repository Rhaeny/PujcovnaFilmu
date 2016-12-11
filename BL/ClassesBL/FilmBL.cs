using System.Collections.ObjectModel;
using BL.ModelsBL;
using DTO;
using Services.ServiceDir;

namespace BL.ClassesBL
{
    public class FilmBL
    {
        private FilmService _filmAdapter;
        protected FilmService Adapter
        {
            get
            {
                if (_filmAdapter == null)
                {
                    _filmAdapter = new FilmService();
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
            Collection<Film> films = Adapter.SelectBy(nazev, rok, cena, kusu, typ);
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
