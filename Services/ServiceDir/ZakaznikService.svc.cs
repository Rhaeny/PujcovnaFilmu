using System.Collections.ObjectModel;
using DTO;
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

        public Collection<Zakaznik> SelectBy(string jmeno = "", string prijmeni = "", string email = "")
        {
            return ZakaznikGateway.SelectBy(jmeno, prijmeni, email);
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
