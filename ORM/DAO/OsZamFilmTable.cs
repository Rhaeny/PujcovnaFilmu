using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class OsZamFilmTable
    {
        public static string TableName = "OsZamFilm";

        public static string SqlSelect =
            "SELECT IdZam, IdFilm, IdOsoba " +
            "FROM OsZamFilm ";

        public static string SqlSelectBy =
            "SELECT IdZam, IdFilm, IdOsoba " +
            "FROM OsZamFilm ";

        public static string SqlDetail =
            "SELECT IdZam, IdFilm, IdOsoba " +
            "FROM OsZamFilm " +
            "WHERE IdZam = @IdZam AND IdFilm = @IdFilm AND IdOsoba = @IdOsoba ";

        public static string SqlInsert =
            "INSERT INTO OsZamFilm " +
            "VALUES(@IdZam, @IdFilm, @IdOsoba) ";

        public static string SqlDelete =
            "DELETE FROM OsZamFilm " +
            "WHERE IdZam = @IdZam AND IdFilm = @IdFilm AND IdOsoba = @IdOsoba ";

        #region Statické metody

        public static int Insert(OsZamFilm osZamFilm, Database pDb = null)
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
            PrepareCommand(command, osZamFilm);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<OsZamFilm> Select(Database pDb = null)
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

            Collection<OsZamFilm> osZamFilms = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return osZamFilms;
        }

        public static Collection<OsZamFilm> SelectBy(int? idZam = null, int? idFilm = null,
            int? idOsoba = null, Database pDb = null)
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

            if (idZam != null)
            {
                first = true;
                SqlSelectBy += "WHERE IdZam = @IdZam ";
            }
            if (idFilm != null)
            {
                if (first)
                    SqlSelectBy += "AND IdFilm = @IdFilm ";
                else
                {
                    first = true;
                    SqlSelectBy += "WHERE Zamestnani_IDzamestnani = @zamestnaniIDzamestnani ";
                }
            }
            if (idOsoba != null)
            {
                if (first)
                    SqlSelectBy += "AND IdOsoba = @IdOsoba ";
                else
                {
                    SqlSelectBy += "WHERE IdOsoba = @IdOsoba ";
                }
            }

            SqlCommand command = db.CreateCommand(SqlSelectBy);

            if (idZam != null)
                command.Parameters.AddWithValue("@IdZam", idZam);
            if (idFilm != null)
                command.Parameters.AddWithValue("@IdFilm", idFilm);
            if (idOsoba != null)
                command.Parameters.AddWithValue("@IdOsoba", idOsoba);

            SqlDataReader reader = db.Select(command);

            Collection<OsZamFilm> osZamFilms = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;

            if (pDb == null)
            {
                db.Close();
            }

            return osZamFilms;
        }

        public static OsZamFilm Detail(int idZam, int idFilm, int idOsoba, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdFilm", idFilm);
            command.Parameters.AddWithValue("@IdOsoba", idOsoba);
            SqlDataReader reader = db.Select(command);

            Collection<OsZamFilm> osZamFilms = Read(reader);
            OsZamFilm osZamFilm = null;
            if (osZamFilms.Count == 1)
            {
                osZamFilm = osZamFilms[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return osZamFilm;
        }

        public static int Delete(int idZam, int idFilm, int idOsoba, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdFilm", idFilm);
            command.Parameters.AddWithValue("@IdOsoba", idOsoba);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, OsZamFilm osZamFilm)
        {
            command.Parameters.AddWithValue("@IdZam", osZamFilm.IdZam);
            command.Parameters.AddWithValue("@IdFilm", osZamFilm.IdFilm);
            command.Parameters.AddWithValue("@IdOsoba", osZamFilm.IdOsoba);
        }

        private static Collection<OsZamFilm> Read(SqlDataReader reader)
        {
            Collection<OsZamFilm> osZamFilms = new Collection<OsZamFilm>();

            while (reader.Read())
            {
                OsZamFilm osZamFilm = new OsZamFilm();
                int i = -1;
                osZamFilm.IdZam = reader.GetInt32(++i);
                osZamFilm.IdFilm = reader.GetInt32(++i);
                osZamFilm.IdOsoba = reader.GetInt32(++i);
                osZamFilms.Add(osZamFilm);
            }
            return osZamFilms;
        }
    }
}
