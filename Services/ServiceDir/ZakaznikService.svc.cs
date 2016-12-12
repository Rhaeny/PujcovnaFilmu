using System.Collections.ObjectModel;
using DTO;
using NullDTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ZakaznikService : IZakaznikService
    {
        public int Insert(Zakaznik zakaznik)
        {
            return ZakaznikGateway.Insert(zakaznik);
        }

        public int Update(Zakaznik zakaznik)
        {
            return ZakaznikGateway.Update(zakaznik);
        }

        public Collection<Zakaznik> Select()
        {
            return ZakaznikGateway.Select();
        }

        public Collection<Zakaznik> SelectBy(ZakaznikNull zakaznikNull)
        {
            return ZakaznikGateway.SelectBy(zakaznikNull.Jmeno, zakaznikNull.Prijmeni, zakaznikNull.Email);
        }

        public Zakaznik Detail(int idZak)
        {
            return ZakaznikGateway.Detail(idZak);
        }

        public int Delete(int idZak)
        {
            return ZakaznikGateway.Delete(idZak);
        }
    }
}
