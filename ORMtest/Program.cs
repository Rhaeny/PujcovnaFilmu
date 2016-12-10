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

            var zanry = ZanrTable.Select(db);
            foreach (var zanr in zanry)
            {
                Console.WriteLine(zanr.Nazev);
            }
            db.Close();
        }
    }
}
