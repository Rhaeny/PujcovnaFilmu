using System.Collections.ObjectModel;
using System.Data.SqlClient;
using ORM.DTO;

namespace ORM.DAO
{
    public class FilmZanrTable
    {
        public static string TableName = "FilmZanr";

        public static string SqlSelect =
            "SELECT IdFilm, IdZanr " +
            "FROM FilmZanr ";

        public static string SqlSelectBy =
            "SELECT IdFilm, IdZanr " +
            "FROM FilmZanr ";

        public static string SqlInsert =
            "INSERT INTO FilmZanr " +
            "VALUES(@IdFilm, @IdZanr) ";

        public static string SqlDelete =
            "DELETE FROM FilmZanr " +
            "WHERE IdFilm = @IdFilm AND IdZanr = @IdZanr ";

        #region Statické metody

        public static int Insert(FilmZanr filmZanr, Database pDb = null)
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
            PrepareCommand(command, filmZanr);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<FilmZanr> Select(Database pDb = null)
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

            Collection<FilmZanr> filmZanry = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return filmZanry;
        }

        public static Collection<FilmZanr> SelectBy(int? idFilm = null, int? idZanr = null, Database pDb = null)
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

            if (idFilm != null)
            {
                first = true;
                SqlSelectBy += "WHERE IdFilm = @IdFilm ";
            }
            if (idZanr != null)
            {
                if (first)
                    SqlSelectBy += "AND IdZanr = @IdZanr ";
                else
                {
                    SqlSelectBy += "WHERE IdZanr = @IdZanr ";
                }
            }

            SqlCommand command = db.CreateCommand(SqlSelectBy);

            if (idFilm != null)
                command.Parameters.AddWithValue("@IdFilm", idFilm);
            if (idZanr != null)
                command.Parameters.AddWithValue("@IdZanr", idZanr);

            SqlDataReader reader = db.Select(command);

            Collection<FilmZanr> filmZanry = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;

            if (pDb == null)
            {
                db.Close();
            }

            return filmZanry;
        }

        public static int Delete(int idFilm, int idZanr, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdFilm", idFilm);
            command.Parameters.AddWithValue("@IdZanr", idZanr);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, FilmZanr filmZanr)
        {
            command.Parameters.AddWithValue("@IdFilm", filmZanr.IdFilm);
            command.Parameters.AddWithValue("@IdZanr", filmZanr.IdZanr);
        }

        private static Collection<FilmZanr> Read(SqlDataReader reader)
        {
            Collection<FilmZanr> filmZanry = new Collection<FilmZanr>();

            while (reader.Read())
            {
                FilmZanr filmZanr = new FilmZanr();
                int i = -1;
                filmZanr.IdZanr = reader.GetInt32(++i);
                filmZanr.IdFilm = reader.GetInt32(++i);
                filmZanry.Add(filmZanr);
            }
            return filmZanry;
        }
    }
}
