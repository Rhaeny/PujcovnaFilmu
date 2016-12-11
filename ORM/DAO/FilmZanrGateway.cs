using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class FilmZanrGateway
    {
        public static string TableName = "FilmZanr";

        public static string SqlSelect =
            "SELECT IdZanr, IdFilm  " +
            "FROM FilmZanr ";

        public static string SqlSelectBy =
            "SELECT IdZanr, IdFilm " +
            "FROM FilmZanr ";

        public static string SqlInsert =
            "INSERT INTO FilmZanr " +
            "VALUES(@IdZanr, @IdFilm) ";

        public static string SqlDelete =
            "DELETE FROM FilmZanr " +
            "WHERE IdZanr = @IdZanr AND IdFilm = @IdFilm ";

        #region Statické metody

        public static int Insert(FilmZanr filmZanr)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlInsert);
            PrepareCommand(command, filmZanr);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static Collection<FilmZanr> Select()
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlSelect);
            SqlDataReader reader = db.Select(command);

            Collection<FilmZanr> filmZanry = Read(reader);
            reader.Close();
            
            db.Close();
            return filmZanry;
        }

        public static Collection<FilmZanr> SelectBy(int? idZanr = null, int? idFilm = null)
        {
            var db = new Database();
            db.Connect();

            bool first = false;

            if (idZanr != null)
            {
                first = true;
                SqlSelectBy += "WHERE IdZanr = @IdZanr ";
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

            if (idZanr != null)
                command.Parameters.AddWithValue("@IdZanr", idZanr);
            if (idFilm != null)
                command.Parameters.AddWithValue("@IdFilm", idFilm);

            SqlDataReader reader = db.Select(command);

            Collection<FilmZanr> filmZanry = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;
            
            db.Close();
            return filmZanry;
        }

        public static int Delete(int idFilm, int idZanr)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlDelete);
            command.Parameters.AddWithValue("@IdZanr", idFilm);
            command.Parameters.AddWithValue("@IdFilm", idZanr);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, FilmZanr filmZanr)
        {
            command.Parameters.AddWithValue("@IdZanr", filmZanr.IdFilm);
            command.Parameters.AddWithValue("@IdFilm", filmZanr.IdZanr);
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
