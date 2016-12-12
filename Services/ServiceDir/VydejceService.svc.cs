using System.Collections.ObjectModel;
using DTO;
using NullDTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class VydejceService : IVydejceService
    {
        public int Insert(Vydejce vydejce)
        {
            return VydejceGateway.Insert(vydejce);
        }

        public int Update(Vydejce vydejce)
        {
            return VydejceGateway.Update(vydejce);
        }

        public Collection<Vydejce> Select()
        {
            return VydejceGateway.Select();
        }

        public Collection<Vydejce> SelectBy(VydejceNull vydejceNull)
        {
            return VydejceGateway.SelectBy(vydejceNull.Jmeno, vydejceNull.Prijmeni, vydejceNull.Email);
        }

        public Vydejce Detail(int idVydejce)
        {
            return VydejceGateway.Detail(idVydejce);
        }

        public int Delete(int idVydejce)
        {
            return VydejceGateway.Delete(idVydejce);
        }
    }
}
