using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class FilmTable
    {
        public static string TableName = "Film";

        public static string SqlSelect =
            "SELECT IdFilm, Nazev, Rok, Cena, Kusu, Typ, Delka, Zeme, Popis " +
            "FROM Film ";

        public static string SqlSelectBy =
            "SELECT IdFilm, Nazev, Rok, Cena, Kusu, Typ, Delka, Zeme, Popis " +
            "FROM Film ";

        public static string SqlDetail =
            "SELECT IdFilm, Nazev, Rok, Cena, Kusu, Typ, Delka, Zeme, Popis " +
            "FROM Film " +
            "WHERE IdFilm = @IdFilm ";

        public static string SqlInsert =
            "INSERT INTO Film " +
            "VALUES(@Nazev, @Rok, @Cena, @Kusu, @Typ, @Delka, @Zeme, @Popis) ";

        public static string SqlUpdate =
            "UPDATE Film " +
            "SET Nazev = @Nazev, Rok = @Rok, Cena = @Cena, Kusu = @Kusu, Typ = @Typ, Delka = @Delka, Zeme = @Zeme, Popis = @Popis " +
            "WHERE IDfilm = @idFilm ";

        public static string SqlDelete =
            "DELETE FROM Film " +
            "WHERE IdFilm = @IdFilm ";

        #region Statické metody

        public static int Insert(Film film, Database pDb = null)
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
            PrepareCommand(command, film);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Film film, Database pDb = null)
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
            PrepareCommand(command, film);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Film> Select(Database pDb = null)
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

            Collection<Film> filmy = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return filmy;
        }

        public static Collection<Film> SelectBy(string nazev = "", int? rok = null, int? cena = null, int? kusu = null,
            string typ = "", Database pDb = null)
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

            if (nazev != "")
            {
                first = true;
                SqlSelectBy += "WHERE Nazev = @Nazev ";
            }
            if (rok != null)
            {
                if (first)
                    SqlSelectBy += "AND Rok = @Rok ";
                else
                {
                    first = true;
                    SqlSelectBy += "WHERE Rok = @Rok ";
                }
            }
            if (cena != null)
            {
                if (first)
                    SqlSelectBy += "AND Cena = @Cena ";
                else
                {
                    first = true;
                    SqlSelectBy += "WHERE Cena = @Cena ";
                }
            }
            if (kusu != null)
            {
                if (first)
                    SqlSelectBy += "AND Kusu = @Kusu ";
                else
                {
                    first = true;
                    SqlSelectBy += "WHERE Kusu = @Kusu ";
                }
            }
            if (typ != "")
            {
                if (first)
                    SqlSelectBy += "AND Typ = @Typ ";
                else
                {
                    SqlSelectBy += "WHERE Typ = @Typ ";
                }
            }

            SqlCommand command = db.CreateCommand(SqlSelectBy);

            if (nazev != "")
                command.Parameters.AddWithValue("@Nazev", nazev);
            if (rok != null)
                command.Parameters.AddWithValue("@Rok", rok);
            if (cena != null)
                command.Parameters.AddWithValue("@Cena", cena);
            if (kusu != null)
                command.Parameters.AddWithValue("@Kusu", kusu);
            if (typ != "")
                command.Parameters.AddWithValue("@Typ", typ);

            SqlDataReader reader = db.Select(command);

            Collection<Film> filmy = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;

            if (pDb == null)
            {
                db.Close();
            }

            return filmy;
        }

        public static Film Detail(int idFilm, Database pDb = null)
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

            command.Parameters.AddWithValue("@IdFilm", idFilm);
            SqlDataReader reader = db.Select(command);

            Collection<Film> filmy = Read(reader);
            Film film = null;
            if (filmy.Count == 1)
            {
                film = filmy[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return film;
        }

        public static int Delete(int idFilm, Database pDb = null)
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
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Film film)
        {
            command.Parameters.AddWithValue("@IdFIlm", film.IdFilm);
            command.Parameters.AddWithValue("@Nazev", film.Nazev);
            command.Parameters.AddWithValue("@Rok", film.Rok);
            command.Parameters.AddWithValue("@Cena", film.Cena);
            command.Parameters.AddWithValue("@Kusu", film.Kusu);
            command.Parameters.AddWithValue("@Typ", film.Typ == null ? DBNull.Value : (object)film.Typ);
            command.Parameters.AddWithValue("@Delka", film.Delka == null ? DBNull.Value : (object)film.Delka);
            command.Parameters.AddWithValue("@Zeme", film.Zeme == null ? DBNull.Value : (object)film.Zeme);
            command.Parameters.AddWithValue("@Popis", film.Popis == null ? DBNull.Value : (object)film.Popis);
        }

        private static Collection<Film> Read(SqlDataReader reader)
        {
            Collection<Film> filmy = new Collection<Film>();

            while (reader.Read())
            {
                Film film = new Film();
                int i = -1;
                film.IdFilm = reader.GetInt32(++i);
                film.Nazev = reader.GetString(++i);
                film.Rok = reader.GetInt32(++i);
                film.Cena = reader.GetInt32(++i);
                film.Kusu = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    film.Typ = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    film.Delka = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    film.Zeme = reader.GetString(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    film.Popis = reader.GetString(i);
                }
                filmy.Add(film);
            }
            return filmy;
        }
    }
}
