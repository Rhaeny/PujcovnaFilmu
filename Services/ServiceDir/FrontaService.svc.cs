using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FrontaService : IFrontaService
    {
        public int Insert(Fronta fronta, Database pDb = null)
        {
            return FrontaGateway.Insert(fronta, pDb);
        }

        public int Update(Fronta fronta, Database pDb = null)
        {
            return FrontaGateway.Update(fronta, pDb);
        }

        public Collection<Fronta> Select(Database pDb = null)
        {
            return FrontaGateway.Select(pDb);
        }

        public Collection<Fronta> SelectBy(int? idZak = null, int? idFilm = null, Database pDb = null)
        {
            return FrontaGateway.SelectBy(idZak, idFilm, pDb);
        }

        public Fronta Detail(int idZak, int idFilm, Database pDb = null)
        {
            return FrontaGateway.Detail(idZak, idFilm, pDb);
        }

        public int Delete(int idZak, int idFilm, Database pDb = null)
        {
            return FrontaGateway.Delete(idZak, idFilm, pDb);
        }
    }
}
