using System;
using ORM.DAO;

namespace ORMtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.Connect();
            var z = ZakaznikTable.Detail(1, db);
            Console.WriteLine(z.Jmeno + " " + z.Prijmeni);
            var list = z.GetObjednavky();
            foreach (var item in list)
            {
                Console.WriteLine("\t" + item.IdFilm + " " + item.DatumObj + " " + item.Vraceno);
            }
            ObjednavkaTable.ExportToXML("XMLdoc");
            db.Close();
        }
    }
}
