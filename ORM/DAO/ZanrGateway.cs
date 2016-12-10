using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class ZanrGateway
    {
        public static string TableName = "Zanr";

        public static string SqlSelect =
            "SELECT IdZanr, Nazev " +
            "FROM Zanr ";

        public static string SqlDetail =
            "SELECT IdZanr, Nazev " +
            "FROM Zanr " +
            "WHERE IdZanr = @IdZanr ";

        public static string SqlInsert =
            "INSERT INTO Zanr " +
            "VALUES(@Nazev) ";

        public static string SqlUpdate =
            "UPDATE Zanr " +
            "SET Nazev = @Nazev " +
            "WHERE IdZanr = @IdZanr ";

        public static string SqlDelete =
            "DELETE FROM Zanr " +
            "WHERE IdZanr = @IdZanr ";

        #region Statické metody

        public static int Insert(Zanr zanr, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SqlInsert);
            PrepareCommand(command, zanr);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Zanr zanr, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SqlUpdate);
            PrepareCommand(command, zanr);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Zanr> Select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SqlSelect);
            SqlDataReader reader = db.Select(command);

            Collection<Zanr> zanry = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zanry;
        }

        public static Zanr Detail(int idZanr, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SqlDetail);

            command.Parameters.AddWithValue("@IdZanr", idZanr);
            SqlDataReader reader = db.Select(command);

            Collection<Zanr> zanry = Read(reader);
            Zanr zanr = null;
            if (zanry.Count == 1)
            {
                zanr = zanry[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zanr;
        }

        public static int Delete(int idZanr, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SqlDelete);
            command.Parameters.AddWithValue("@IdZanr", idZanr);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Zanr zanr)
        {
            command.Parameters.AddWithValue("@IdZanr", zanr.IdZanr);
            command.Parameters.AddWithValue("@Nazev", zanr.Nazev);
        }

        private static Collection<Zanr> Read(SqlDataReader reader)
        {
            Collection<Zanr> zanry = new Collection<Zanr>();

            while (reader.Read())
            {
                Zanr zanr = new Zanr();
                int i = -1;
                zanr.IdZanr = reader.GetInt32(++i);
                zanr.Nazev = reader.GetString(++i);
                zanry.Add(zanr);
            }
            return zanry;
        }
    }
}
