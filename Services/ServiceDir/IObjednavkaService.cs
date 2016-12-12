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
        int Update(Objednavka objednavka);
        Collection<Objednavka> Select();
        Collection<Objednavka> SelectBy(ObjednavkaNull objednavkaNull);
        Objednavka Detail(int idObj);
        int Delete(int idObj);
    }
}
