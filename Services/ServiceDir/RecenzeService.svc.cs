using System.Collections.ObjectModel;
using ORM.DAO;
using ORM.DTO;

namespace Services.ServiceDir
{
    public class RecenzeService : IRecenzeService
    {
        public int Insert(Recenze recenze, Database pDb = null)
        {
            return RecenzeTable.Insert(recenze, pDb);
        }

        public int Update(Recenze recenze, Database pDb = null)
        {
            return RecenzeTable.Update(recenze, pDb);
        }

        public Collection<Recenze> Select(Database pDb = null)
        {
            return RecenzeTable.Select(pDb);
        }

        public Collection<Recenze> SelectBy(int? idZak = null, int? idFilm = null, int? cislo = null, Database pDb = null)
        {
            return RecenzeTable.SelectBy(idZak, idFilm, cislo, pDb);
        }

        public Recenze Detail(int idZak, int idFilm, Database pDb = null)
        {
            return RecenzeTable.Detail(idZak, idFilm, pDb);
        }

        public int Delete(int idZak, int idFilm, Database pDb = null)
        {
            return RecenzeTable.Delete(idZak, idFilm, pDb);
        }
    }
}
