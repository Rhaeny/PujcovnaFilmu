using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class RecenzeService : IRecenzeService
    {
        public int Insert(Recenze recenze)
        {
            return RecenzeGateway.Insert(recenze);
        }

        public int Update(Recenze recenze)
        {
            return RecenzeGateway.Update(recenze);
        }

        public Collection<Recenze> Select()
        {
            return RecenzeGateway.Select();
        }

        public Collection<Recenze> SelectBy(int? idZak = null, int? idFilm = null, int? cislo = null)
        {
            return RecenzeGateway.SelectBy(idZak, idFilm, cislo);
        }

        public Recenze Detail(int idZak, int idFilm)
        {
            return RecenzeGateway.Detail(idZak, idFilm);
        }

        public int Delete(int idZak, int idFilm)
        {
            return RecenzeGateway.Delete(idZak, idFilm);
        }
    }
}
