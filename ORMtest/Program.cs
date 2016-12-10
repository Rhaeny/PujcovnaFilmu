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
            var list = OsZamFilmTable.SelectBy(pDb: db);
            foreach (var item in list)
            {
                Console.WriteLine(item.IdFilm);
            }
            db.Close();
        }
    }
}
