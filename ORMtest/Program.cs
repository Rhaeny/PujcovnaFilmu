using System;
using ORM.DAO;
using ORM.DTO;

namespace ORMtest
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.Connect();
            var list = FrontaTable.Select();
            foreach (var item in list)
            {
                Console.WriteLine(item.IdFilm + " " + item.Datum + " " + item.Poznamka);
            }
            db.Close();
        }
    }
}
