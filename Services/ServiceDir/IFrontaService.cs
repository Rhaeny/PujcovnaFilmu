using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IFrontaService
    {
        [OperationContract]
        int Insert(Fronta fronta);
        int Update(Fronta fronta);
        Collection<Fronta> Select();
        Collection<Fronta> SelectBy(FrontaNull frontaNull);
        Fronta Detail(int idZak, int idFilm);
        int Delete(int idZak, int idFilm);
    }
}
