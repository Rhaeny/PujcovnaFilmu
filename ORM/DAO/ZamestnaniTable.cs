using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ORM.DTO;

namespace ORM.DAO
{
    public class ZamestnaniTable
    {
        public static string TableName = "Zamestnani";

        public static string SqlSelect =
            "SELECT IdZam, Nazev " +
            "FROM Zamestnani ";

        public static string SqlDetail =
            "SELECT IdZam, Nazev " +
            "FROM Zamestnani " +
            "WHERE IdZam = @IdZam ";

        public static string SqlInsert =
            "INSERT INTO Zamestnani " +
            "VALUES(@Nazev) ";

        public static string SqlUpdate =
            "UPDATE Zamestnani " +
            "SET Nazev = @Nazev " +
            "WHERE IdZam = @IdZam ";

        public static string SqlDelete =
            "DELETE FROM Zamestnani " +
            "WHERE IdZam = @IdZam ";

        #region Statické metody

        public static int Insert(Zamestnani zam, Database pDb = null)
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
            PrepareCommand(command, zam);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Zamestnani zam, Database pDb = null)
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
            PrepareCommand(command, zam);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Zamestnani> Select(Database pDb = null)
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

            Collection<Zamestnani> zams = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zams;
        }

        public static Zamestnani Detail(int idZam, Database pDb = null)
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

            command.Parameters.AddWithValue("@IdZam", idZam);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnani> zams = Read(reader);
            Zamestnani zam = null;
            if (zams.Count == 1)
            {
                zam = zams[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zam;
        }

        public static int Delete(int idZam, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdZam", idZam);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Zamestnani zam)
        {
            command.Parameters.AddWithValue("@IdZam", zam.IdZam);
            command.Parameters.AddWithValue("@Nazev", zam.Nazev);
        }

        private static Collection<Zamestnani> Read(SqlDataReader reader)
        {
            Collection<Zamestnani> zams = new Collection<Zamestnani>();
            while (reader.Read())
            {
                Zamestnani zam = new Zamestnani();
                int i = -1;
                zam.IdZam = reader.GetInt32(++i);
                zam.Nazev = reader.GetString(++i);
                zams.Add(zam);
            }
            return zams;
        }
    }
}
