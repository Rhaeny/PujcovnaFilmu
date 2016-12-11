using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFrontaService
    {
        [OperationContract]
        int Insert(Fronta fronta);
        int Update(Fronta fronta);
        Collection<Fronta> Select();
        Collection<Fronta> SelectBy(int? idZak = null, int? idFilm = null);
        Fronta Detail(int idZak, int idFilm);
        int Delete(int idZak, int idFilm);
    }
}
