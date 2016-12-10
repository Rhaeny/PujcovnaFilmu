using System;
using ORM.DAO;
using Services.ServiceDir;

namespace ORMtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.Connect();
            IFilmService fs = new FilmService();
            var z = fs.Detail(1, db);
            Console.WriteLine(z.IdFilm + " " + z.Nazev);
            //ObjednavkaTable.ExportToXML("XMLdoc");
            db.Close();
        }
    }
}
