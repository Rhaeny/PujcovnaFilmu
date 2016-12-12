using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IObjednavkaService
    {
        [OperationContract]
        int Insert(Objednavka objednavka);

        [OperationContract]
        int Update(Objednavka objednavka);

        [OperationContract]
        Collection<Objednavka> Select();

        [OperationContract]
        Collection<Objednavka> SelectBy(ObjednavkaNull objednavkaNull);

        [OperationContract]
        Objednavka Detail(int idObj);

        [OperationContract]
        int Delete(int idObj);
    }
}
