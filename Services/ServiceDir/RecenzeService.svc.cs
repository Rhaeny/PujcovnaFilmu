using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class RecenzeService : IRecenzeService
    {
        public int Insert(Recenze recenze, Database pDb = null)
        {
            return RecenzeGateway.Insert(recenze, pDb);
        }

        public int Update(Recenze recenze, Database pDb = null)
        {
            return RecenzeGateway.Update(recenze, pDb);
        }

        public Collection<Recenze> Select(Database pDb = null)
        {
            return RecenzeGateway.Select(pDb);
        }

        public Collection<Recenze> SelectBy(int? idZak = null, int? idFilm = null, int? cislo = null, Database pDb = null)
        {
            return RecenzeGateway.SelectBy(idZak, idFilm, cislo, pDb);
        }

        public Recenze Detail(int idZak, int idFilm, Database pDb = null)
        {
            return RecenzeGateway.Detail(idZak, idFilm, pDb);
        }

        public int Delete(int idZak, int idFilm, Database pDb = null)
        {
            return RecenzeGateway.Delete(idZak, idFilm, pDb);
        }
    }
}
