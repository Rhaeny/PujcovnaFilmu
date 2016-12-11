using System.Collections.ObjectModel;
using DTO;
using ORM.DAO;

namespace Services.ServiceDir
{
    public class ZamestnaniService : IZamestnaniService
    {
        public int Insert(Zamestnani zam)
        {
            return ZamestnaniGateway.Insert(zam);
        }

        public int Update(Zamestnani zam)
        {
            return ZamestnaniGateway.Update(zam);
        }

        public Collection<Zamestnani> Select()
        {
            return ZamestnaniGateway.Select();
        }

        public Zamestnani Detail(int idZam)
        {
            return ZamestnaniGateway.Detail(idZam);
        }

        public int Delete(int idZam)
        {
            return ZamestnaniGateway.Delete(idZam);
        }
    }
}
