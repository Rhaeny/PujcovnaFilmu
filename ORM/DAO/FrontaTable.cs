using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class FrontaTable
    {
        public static string TableName = "Fronta";

        public static string SqlSelect =
            "SELECT Datum, Poznamka, IdZak, IdFilm " +
            "FROM Fronta ";

        public static string SqlSelectBy =
            "SELECT Datum, Poznamka, IdZak, IdFilm " +
            "FROM Fronta ";

        public static string SqlDetail =
            "SELECT Datum, Poznamka, IdZak, IdFilm " +
            "FROM Fronta " +
            "WHERE IdZak = @IdZak AND IdFilm = @IdFilm ";

        public static string SqlInsert =
            "INSERT INTO Fronta " +
            "VALUES(@Datum, @Poznamka, @IdZak, @IdFilm) ";

        public static string SqlUpdate =
            "UPDATE Fronta " +
            "SET Datum = @Datum, Poznamka = @Poznamka " +
            "WHERE IdZak = @IdZak AND IdFilm = @IdFilm ";

        public static string SqlDelete =
            "DELETE FROM Fronta " +
            "WHERE IdZak = @IdZak AND IdFilm = @IdFilm ";

        #region Statické metody

        public static int Insert(Fronta fronta, Database pDb = null)
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
            PrepareCommand(command, fronta);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Fronta fronta, Database pDb = null)
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
            PrepareCommand(command, fronta);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Fronta> Select(Database pDb = null)
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

            Collection<Fronta> fronty = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return fronty;
        }

        public static Collection<Fronta> SelectBy(int? idZak = null, int? idFilm = null, Database pDb = null)
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

            if (idZak != null)
            {
                first = true;
                SqlSelectBy += "WHERE IdZak = @IdZak ";
            }
            if (idFilm != null)
            {
                if (first)
                    SqlSelectBy += "AND IdFilm = @IdFilm ";
                else
                {
                    SqlSelectBy += "WHERE IdFilm = @IdFilm ";
                }
            }

            SqlCommand command = db.CreateCommand(SqlSelectBy);

            if (idZak != null)
                command.Parameters.AddWithValue("@IdZak", idZak);
            if (idFilm != null)
                command.Parameters.AddWithValue("@IdFilm", idFilm);

            SqlDataReader reader = db.Select(command);

            Collection<Fronta> fronty = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;

            if (pDb == null)
            {
                db.Close();
            }

            return fronty;
        }

        public static Fronta Detail(int idZak, int idFilm, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdFilm", idFilm);
            SqlDataReader reader = db.Select(command);

            Collection<Fronta> fronty = Read(reader);
            Fronta fronta = null;
            if (fronty.Count == 1)
            {
                fronta = fronty[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return fronta;
        }

        public static int Delete(int idZak, int idFilm, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdFilm", idFilm);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Fronta fronta)
        {
            command.Parameters.AddWithValue("@Datum", fronta.Datum);
            command.Parameters.AddWithValue("@Poznamka", fronta.Poznamka == null ? DBNull.Value : (object)fronta.Poznamka);
            command.Parameters.AddWithValue("@IdZak", fronta.IdZak);
            command.Parameters.AddWithValue("@IdFilm", fronta.IdFilm);
        }

        private static Collection<Fronta> Read(SqlDataReader reader)
        {
            Collection<Fronta> fronty = new Collection<Fronta>();

            while (reader.Read())
            {
                Fronta fronta = new Fronta();
                int i = -1;
                fronta.Datum = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    fronta.Poznamka = reader.GetString(i);
                }
                fronta.IdZak = reader.GetInt32(++i);
                fronta.IdFilm = reader.GetInt32(++i);
                fronty.Add(fronta);
            }
            return fronty;
        }
    }
}
