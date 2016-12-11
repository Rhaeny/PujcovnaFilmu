using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IOsobaService
    {
        [OperationContract]
        int Insert(Osoba osoba);
        int Update(Osoba osoba);
        Collection<Osoba> Select();
        Collection<Osoba> SelectBy(string jmeno = "", string prijmeni = "");
        Osoba Detail(int idOsoba);
        int Delete(int idOsoba);
    }
}
