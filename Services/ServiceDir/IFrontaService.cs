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

        [OperationContract]
        int Update(Fronta fronta);

        [OperationContract]
        Collection<Fronta> Select();

        [OperationContract]
        Collection<Fronta> SelectBy(FrontaNull frontaNull);

        [OperationContract]
        Fronta Detail(int idZak, int idFilm);

        [OperationContract]
        int Delete(int idZak, int idFilm);
    }
}
