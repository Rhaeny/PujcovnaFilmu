using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ZanrService : IZanrService
    {
        public int Insert(Zanr zanr)
        {
            return ZanrGateway.Insert(zanr);
        }

        public int Update(Zanr zanr)
        {
            return ZanrGateway.Update(zanr);
        }

        public Collection<Zanr> Select()
        {
            return ZanrGateway.Select();
        }

        public Zanr Detail(int idZanr)
        {
            return ZanrGateway.Detail(idZanr);
        }

        public int Delete(int idZanr)
        {
            return ZanrGateway.Delete(idZanr);
        }
    }
}
