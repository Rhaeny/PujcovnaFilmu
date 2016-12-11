using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class ZamestnaniGateway
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

        public static int Insert(Zamestnani zam)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlInsert);
            PrepareCommand(command, zam);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static int Update(Zamestnani zam)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlUpdate);
            PrepareCommand(command, zam);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static Collection<Zamestnani> Select()
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlSelect);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnani> zams = Read(reader);
            reader.Close();
            
            db.Close();
            return zams;
        }

        public static Zamestnani Detail(int idZam)
        {
            var db = new Database();
            db.Connect();

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
            
            db.Close();
            return zam;
        }

        public static int Delete(int idZam)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlDelete);
            command.Parameters.AddWithValue("@IdZam", idZam);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
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
