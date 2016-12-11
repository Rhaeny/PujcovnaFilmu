using System;
using Services.ServiceDir;

namespace ORMtest
{
    class Program
    {
        static void Main(string[] args)
        {
            IFilmService fs = new FilmService();
            var z = fs.Detail(1);
            Console.WriteLine(z.IdFilm + " " + z.Nazev);
            //ObjednavkaTable.ExportToXML("XMLdoc");
        }
    }
}
