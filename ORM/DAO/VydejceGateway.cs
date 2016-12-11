using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class VydejceGateway
    {
        public static string TableName = "Vydejce";

        public static string SqlSelect =
            "SELECT IdVydejce, Jmeno, Prijmeni, Email, Telefon " +
            "FROM Vydejce ";

        public static string SqlSelectBy =
            "SELECT IdVydejce, Jmeno, Prijmeni, Email, Telefon " +
            "FROM Vydejce ";

        public static string SqlDetail =
            "SELECT IdVydejce, Jmeno, Prijmeni, Email, Telefon " +
            "FROM Vydejce " +
            "WHERE IdVydejce = @IdVydejce ";

        public static string SqlInsert =
            "INSERT INTO Vydejce " +
            "VALUES(@Jmeno, @Prijmeni, @Email, @Telefon) ";

        public static string SqlUpdate =
            "UPDATE Vydejce " +
            "SET Jmeno = @Jmeno, Prijmeni = @Prijmeni, Email = @Email, Telefon = @Telefon " +
            "WHERE IdVydejce = @IdVydejce ";

        public static string SqlDelete =
            "DELETE FROM Vydejce " +
            "WHERE IdVydejce = @IdVydejce ";

        #region Statické metody

        public static int Insert(Vydejce vydejce)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlInsert);
            PrepareCommand(command, vydejce);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static int Update(Vydejce vydejce)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlUpdate);
            PrepareCommand(command, vydejce);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static Collection<Vydejce> Select()
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlSelect);
            SqlDataReader reader = db.Select(command);

            Collection<Vydejce> vydejci = Read(reader);
            reader.Close();
            
            db.Close();
            return vydejci;
        }

        public static Collection<Vydejce> SelectBy(string jmeno = "", string prijmeni = "", string email = "")
        {
            var db = new Database();
            db.Connect();

            bool first = false;

            if (jmeno != "")
            {
                first = true;
                SqlSelectBy += "WHERE Jmeno = @Jmeno ";
            }
            if (prijmeni != "")
            {
                if (first)
                    SqlSelectBy += "AND Prijmeni = @Prijmeni ";
                else
                {
                    first = true;
                    SqlSelectBy += "WHERE Prijmeni = @Prijmeni ";
                }
            }
            if (email != "")
            {
                if (first)
                    SqlSelectBy += "AND Email = @Email ";
                else
                {
                    SqlSelectBy += "WHERE Email = @Email ";
                }
            }

            SqlCommand command = db.CreateCommand(SqlSelectBy);

            if (jmeno != "")
                command.Parameters.AddWithValue("@Jmeno", jmeno);
            if (prijmeni != "")
                command.Parameters.AddWithValue("@Prijmeni", prijmeni);
            if (email != "")
                command.Parameters.AddWithValue("@Email", email);

            SqlDataReader reader = db.Select(command);

            Collection<Vydejce> vydejci = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;
            
            db.Close();
            return vydejci;
        }

        public static Vydejce Detail(int idVydejce)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlDetail);

            command.Parameters.AddWithValue("@IdVydejce", idVydejce);
            SqlDataReader reader = db.Select(command);

            Collection<Vydejce> vydejci = Read(reader);
            Vydejce vydejce = null;
            if (vydejci.Count == 1)
            {
                vydejce = vydejci[0];
            }
            reader.Close();
            
            db.Close();
            return vydejce;
        }

        public static int Delete(int idVydejce)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlDelete);
            command.Parameters.AddWithValue("@IdVydejce", idVydejce);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Vydejce vydejce)
        {
            command.Parameters.AddWithValue("@IdVydejce", vydejce.IdVydejce);
            command.Parameters.AddWithValue("@Jmeno", vydejce.Jmeno);
            command.Parameters.AddWithValue("@Prijmeni", vydejce.Prijmeni);
            command.Parameters.AddWithValue("@Email", vydejce.Email);
            command.Parameters.AddWithValue("@Telefon", vydejce.Telefon);
        }

        private static Collection<Vydejce> Read(SqlDataReader reader)
        {
            Collection<Vydejce> vydejci = new Collection<Vydejce>();

            while (reader.Read())
            {
                Vydejce vydejce = new Vydejce();
                int i = -1;
                vydejce.IdVydejce = reader.GetInt32(++i);
                vydejce.Jmeno = reader.GetString(++i);
                vydejce.Prijmeni = reader.GetString(++i);
                vydejce.Email = reader.GetString(++i);
                vydejce.Telefon = reader.GetString(++i);
                vydejci.Add(vydejce);
            }
            return vydejci;
        }
    }
}
