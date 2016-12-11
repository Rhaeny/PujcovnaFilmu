using System;
using BL.ClassesBL;

namespace ORMtest
{
    class Program
    {
        static void Main(string[] args)
        {
            FilmBL fs = new FilmBL();
            var items = fs.Select();
            foreach (var item in items)
            {
                Console.WriteLine(item.IdFilm + " " + item.Nazev);
                var zanry = item.GetFronta();
                foreach (var zanr in zanry)
                {
                    Console.WriteLine("\t" + zanr.Poznamka);
                }
            }
            //ObjednavkaTable.ExportToXML("XMLdoc");
        }
    }
}
