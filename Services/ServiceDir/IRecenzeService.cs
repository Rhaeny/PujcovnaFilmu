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
        int Update(Recenze recenze);
        Collection<Recenze> Select();
        Collection<Recenze> SelectBy(RecenzeNull recenzeNull);
        Recenze Detail(int idZak, int idFilm);
        int Delete(int idZak, int idFilm);
    }
}
