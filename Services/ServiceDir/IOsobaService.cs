using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IOsobaService
    {
        [OperationContract]
        int Insert(Osoba osoba);

        [OperationContract]
        int Update(Osoba osoba);

        [OperationContract]
        Collection<Osoba> Select();

        [OperationContract]
        Collection<Osoba> SelectBy(OsobaNull osobaNull);

        [OperationContract]
        Osoba Detail(int idOsoba);

        [OperationContract]
        int Delete(int idOsoba);
    }
}
