using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IRecenzeService
    {
        [OperationContract]
        int Insert(Recenze recenze);
        int Update(Recenze recenze);
        Collection<Recenze> Select();
        Collection<Recenze> SelectBy(int? idZak = null, int? idFilm = null, int? cislo = null);
        Recenze Detail(int idZak, int idFilm);
        int Delete(int idZak, int idFilm);
    }
}
