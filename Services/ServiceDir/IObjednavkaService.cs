using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IObjednavkaService
    {
        [OperationContract]
        int Insert(Objednavka objednavka, Database pDb = null);
        int Update(Objednavka objednavka, Database pDb = null);
        Collection<Objednavka> Select(Database pDb = null);
        Collection<Objednavka> SelectBy(char? vydano = null, char? vraceno = null, int? idZak = null,
            int? idFilm = null, int? idVydejce = null, Database pDb = null);
        Objednavka Detail(int idObj, Database pDb = null);
        int Delete(int idObj, Database pDb = null);
    }
}
