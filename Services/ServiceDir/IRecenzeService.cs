using System.Collections.ObjectModel;
using System.ServiceModel;
using DTO;
using NullDTO;

namespace Services.ServiceDir
{
    [ServiceContract]
    public interface IRecenzeService
    {
        [OperationContract]
        int Insert(Recenze recenze);

        [OperationContract]
        int Update(Recenze recenze);

        [OperationContract]
        Collection<Recenze> Select();

        [OperationContract]
        Collection<Recenze> SelectBy(RecenzeNull recenzeNull);

        [OperationContract]
        Recenze Detail(int idZak, int idFilm);

        [OperationContract]
        int Delete(int idZak, int idFilm);
    }
}
