using System.Collections.ObjectModel;
using DTO;
using NullDTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class FrontaService : IFrontaService
    {
        public int Insert(Fronta fronta)
        {
            return FrontaGateway.Insert(fronta);
        }

        public int Update(Fronta fronta)
        {
            return FrontaGateway.Update(fronta);
        }

        public Collection<Fronta> Select()
        {
            return FrontaGateway.Select();
        }

        public Collection<Fronta> SelectBy(FrontaNull frontaNull)
        {
            return FrontaGateway.SelectBy(frontaNull.IdZak, frontaNull.IdFilm);
        }

        public Fronta Detail(int idZak, int idFilm)
        {
            return FrontaGateway.Detail(idZak, idFilm);
        }

        public int Delete(int idZak, int idFilm)
        {
            return FrontaGateway.Delete(idZak, idFilm);
        }
    }
}
