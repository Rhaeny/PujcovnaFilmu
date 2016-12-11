using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IObjednavkaService
    {
        [OperationContract]
        int Insert(Objednavka objednavka);
        int Update(Objednavka objednavka);
        Collection<Objednavka> Select();
        Collection<Objednavka> SelectBy(char? vydano = null, char? vraceno = null, int? idZak = null, int? idFilm = null, int? idVydejce = null);
        Objednavka Detail(int idObj);
        int Delete(int idObj);
    }
}
