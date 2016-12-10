using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class ZakaznikTable
    {
        public static string TableName = "Zakaznik";

        public static string SqlSelect =
            "SELECT IdZak, Jmeno, Prijmeni, Email, Telefon " +
            "FROM Zakaznik ";

        public static string SqlSelectBy =
            "SELECT IdZak, Jmeno, Prijmeni, Email, Telefon " +
            "FROM Zakaznik ";

        public static string SqlDetail =
            "SELECT IdZak, Jmeno, Prijmeni, Email, Telefon " +
            "FROM Zakaznik " +
            "WHERE IdZak = @IdZak ";

        public static string SqlInsert =
            "INSERT INTO Zakaznik " +
            "VALUES(@Jmeno, @Prijmeni, @Email, @Telefon) ";

        public static string SqlUpdate =
            "UPDATE Zakaznik " +
            "SET Jmeno = @Jmeno, Prijmeni = @Prijmeni, Email = @Email, Telefon = @Telefon " +
            "WHERE IdZak = @IdZak ";

        public static string SqlDelete =
            "DELETE FROM Zakaznik " +
            "WHERE IdZak = @IdZak ";

        #region Statické metody

        public static int Insert(Zakaznik zakaznik, Database pDb = null)
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
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Zakaznik zakaznik, Database pDb = null)
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
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Zakaznik> Select(Database pDb = null)
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

            Collection<Zakaznik> zakaznici = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zakaznici;
        }

        public static Collection<Zakaznik> SelectBy(string jmeno = "", string prijmeni = "", string email = "", Database pDb = null)
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

            Collection<Zakaznik> zakaznici = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;

            if (pDb == null)
            {
                db.Close();
            }

            return zakaznici;
        }

        public static Zakaznik Detail(int idZak, Database pDb = null)
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

            command.Parameters.AddWithValue("@IdZak", idZak);
            SqlDataReader reader = db.Select(command);

            Collection<Zakaznik> zakaznici = Read(reader);
            Zakaznik zakaznik = null;
            if (zakaznici.Count == 1)
            {
                zakaznik = zakaznici[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zakaznik;
        }

        public static int Delete(int idZak, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdZak", idZak);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Zakaznik zakaznik)
        {
            command.Parameters.AddWithValue("@IdZak", zakaznik.IdZak);
            command.Parameters.AddWithValue("@Jmeno", zakaznik.Jmeno);
            command.Parameters.AddWithValue("@Prijmeni", zakaznik.Prijmeni);
            command.Parameters.AddWithValue("@Email", zakaznik.Email == null ? DBNull.Value : (object)zakaznik.Email);
            command.Parameters.AddWithValue("@Telefon", zakaznik.Telefon == null ? DBNull.Value : (object)zakaznik.Telefon);
        }

        private static Collection<Zakaznik> Read(SqlDataReader reader)
        {
            Collection<Zakaznik> zakaznici = new Collection<Zakaznik>();

            while (reader.Read())
            {
                Zakaznik zakaznik = new Zakaznik();
                int i = -1;
                zakaznik.IdZak = reader.GetInt32(++i);
                zakaznik.Jmeno = reader.GetString(++i);
                zakaznik.Prijmeni = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    zakaznik.Email = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    zakaznik.Telefon = reader.GetString(i);
                }
                zakaznici.Add(zakaznik);
            }
            return zakaznici;
        }
    }
}
