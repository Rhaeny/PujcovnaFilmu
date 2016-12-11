using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IZakaznikService
    {
        [OperationContract]
        int Insert(Zakaznik zakaznik);
        int Update(Zakaznik zakaznik);
        Collection<Zakaznik> Select();
        Collection<Zakaznik> SelectBy(string jmeno = "", string prijmeni = "", string email = "");
        Zakaznik Detail(int idZak);
        int Delete(int idZak);
    }
}
