using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FrontaService : IFrontaService
    {
        public int Insert(Fronta fronta, Database pDb = null)
        {
            return FrontaTable.Insert(fronta, pDb);
        }

        public int Update(Fronta fronta, Database pDb = null)
        {
            return FrontaTable.Update(fronta, pDb);
        }

        public Collection<Fronta> Select(Database pDb = null)
        {
            return FrontaTable.Select(pDb);
        }

        public Collection<Fronta> SelectBy(int? idZak = null, int? idFilm = null, Database pDb = null)
        {
            return FrontaTable.SelectBy(idZak, idFilm, pDb);
        }

        public Fronta Detail(int idZak, int idFilm, Database pDb = null)
        {
            return FrontaTable.Detail(idZak, idFilm, pDb);
        }

        public int Delete(int idZak, int idFilm, Database pDb = null)
        {
            return FrontaTable.Delete(idZak, idFilm, pDb);
        }
    }
}
