using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class OsobaTable
    {
        public static string TableName = "Osoba";

        public static string SqlSelect =
            "SELECT IdOsoba, Jmeno, Prijmeni, Biografie " +
            "FROM Osoba ";

        public static string SqlSelectBy =
            "SELECT IdOsoba, Jmeno, Prijmeni, Biografie " +
            "FROM Osoba ";

        public static string SqlDetail =
            "SELECT IdOsoba, Jmeno, Prijmeni, Biografie " +
            "FROM Osoba " +
            "WHERE IdOsoba = @IdOsoba ";

        public static string SqlInsert =
            "INSERT INTO Osoba " +
            "VALUES(@Jmeno, @Prijmeni, @Biografie) ";

        public static string SqlUpdate =
            "UPDATE Osoba " +
            "SET Jmeno = @Jmeno, Prijmeni = @Prijmeni, Biografie = @Biografie " +
            "WHERE IdOsoba = @IdOsoba ";

        public static string SqlDelete =
            "DELETE FROM Osoba " +
            "WHERE IdOsoba = @IdOsoba ";

        #region Statické metody

        public static int Insert(Osoba osoba, Database pDb = null)
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
            PrepareCommand(command, osoba);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Osoba osoba, Database pDb = null)
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
            PrepareCommand(command, osoba);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Osoba> Select(Database pDb = null)
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

            Collection<Osoba> osoby = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return osoby;
        }

        public static Collection<Osoba> SelectBy(string jmeno = "", string prijmeni = "", Database pDb = null)
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
                    SqlSelectBy += "WHERE Prijmeni = @Prijmeni ";
                }
            }

            SqlCommand command = db.CreateCommand(SqlSelectBy);

            if (jmeno != "")
                command.Parameters.AddWithValue("@Jmeno", jmeno);
            if (prijmeni != "")
                command.Parameters.AddWithValue("@Prijmeni", prijmeni);

            SqlDataReader reader = db.Select(command);

            Collection<Osoba> osoby = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;

            if (pDb == null)
            {
                db.Close();
            }

            return osoby;
        }

        public static Osoba Detail(int idOsoba, Database pDb = null)
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

            command.Parameters.AddWithValue("@IdOsoba", idOsoba);
            SqlDataReader reader = db.Select(command);

            Collection<Osoba> osoby = Read(reader);
            Osoba osoba = null;
            if (osoby.Count == 1)
            {
                osoba = osoby[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return osoba;
        }

        public static int Delete(int idOsoba, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdOsoba", idOsoba);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Osoba osoba)
        {
            command.Parameters.AddWithValue("@IdOsoba", osoba.IdOsoba);
            command.Parameters.AddWithValue("@Jmeno", osoba.Jmeno);
            command.Parameters.AddWithValue("@Prijmeni", osoba.Prijmeni);
            command.Parameters.AddWithValue("@Biografie",
                osoba.Biografie == null ? DBNull.Value : (object)osoba.Biografie);
        }

        private static Collection<Osoba> Read(SqlDataReader reader)
        {
            Collection<Osoba> osoby = new Collection<Osoba>();

            while (reader.Read())
            {
                Osoba osoba = new Osoba();
                int i = -1;
                osoba.IdOsoba = reader.GetInt32(++i);
                osoba.Jmeno = reader.GetString(++i);
                osoba.Prijmeni = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    osoba.Biografie = reader.GetString(i);
                }
                osoby.Add(osoba);
            }
            return osoby;
        }
    }
}
