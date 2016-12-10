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
            var list = VydejceTable.SelectBy(pDb: db);
            foreach (var item in list)
            {
                Console.WriteLine(item.Jmeno);
            }
            db.Close();
        }
    }
}
