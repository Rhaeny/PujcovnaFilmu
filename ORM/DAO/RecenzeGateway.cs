using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DTO;

namespace ORM.DAO
{
    public class RecenzeGateway
    {
        public static string TableName = "Recenze";

        public static string SqlSelect =
            "SELECT Datum, Cislo, Text, IdZak, IdFilm " +
            "FROM Recenze ";

        public static string SqlSelectBy =
            "SELECT Datum, Cislo, Text, IdZak, IdFilm " +
            "FROM Recenze ";

        public static string SqlDetail =
            "SELECT Datum, Cislo, Text, IdZak, IdFilm " +
            "FROM Recenze " +
            "WHERE IdZak = @IdZak AND IdFilm = @IdFilm ";

        public static string SqlInsert =
            "INSERT INTO Recenze " +
            "VALUES(@Datum, @Cislo, @Text, @IdZak, @IdFilm) ";

        public static string SqlUpdate =
            "UPDATE Recenze " +
            "SET Datum = @Datum, Cislo = @Cislo, Text = @Text " +
            "WHERE IdZak = @IdZak AND IdFilm = @IdFilm ";

        public static string SqlDelete =
            "DELETE FROM Recenze " +
            "WHERE IdZak = @IdZak AND IdFilm = @IdFilm ";

        #region Statické metody

        public static int Insert(Recenze recenze)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlInsert);
            PrepareCommand(command, recenze);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static int Update(Recenze recenze)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlUpdate);
            PrepareCommand(command, recenze);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static Collection<Recenze> Select()
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlSelect);
            SqlDataReader reader = db.Select(command);

            Collection<Recenze> recenzes = Read(reader);
            reader.Close();
            
            db.Close();
            return recenzes;
        }

        public static Collection<Recenze> SelectBy(int? idZak = null, int? idFilm = null, int? cislo = null)
        {
            var db = new Database();
            db.Connect();

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
            if (cislo != null)
            {
                if (first)
                    SqlSelectBy += "AND Cislo = @Cislo ";
                else
                {
                    SqlSelectBy += "WHERE Cislo = @Cislo ";
                }
            }

            SqlCommand command = db.CreateCommand(SqlSelectBy);

            if (idZak != null)
                command.Parameters.AddWithValue("@IdZak", idZak);
            if (idFilm != null)
                command.Parameters.AddWithValue("@IdFilm", idFilm);
            if (cislo != null)
                command.Parameters.AddWithValue("@Cislo", cislo);

            SqlDataReader reader = db.Select(command);

            Collection<Recenze> recenzes = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;
            
            db.Close();
            return recenzes;
        }

        public static Recenze Detail(int idZak, int idFilm)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlDetail);

            command.Parameters.AddWithValue("@IdZak", idZak);
            command.Parameters.AddWithValue("@IdFilm", idFilm);
            SqlDataReader reader = db.Select(command);

            Collection<Recenze> recenzes = Read(reader);
            Recenze recenze = null;
            if (recenzes.Count == 1)
            {
                recenze = recenzes[0];
            }
            reader.Close();
            
            db.Close();
            return recenze;
        }

        public static int Delete(int idZak, int idFilm)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlDelete);
            command.Parameters.AddWithValue("@IdZak", idZak);
            command.Parameters.AddWithValue("@IdFilm", idFilm);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Recenze recenze)
        {
            command.Parameters.AddWithValue("@Datum", recenze.Datum);
            command.Parameters.AddWithValue("@Cislo", recenze.Cislo);
            command.Parameters.AddWithValue("@Text", recenze.Text == null ? DBNull.Value : (object)recenze.Text);
            command.Parameters.AddWithValue("@IdZak", recenze.IdZak);
            command.Parameters.AddWithValue("@IdFilm", recenze.IdFilm);
        }

        private static Collection<Recenze> Read(SqlDataReader reader)
        {
            Collection<Recenze> recenzes = new Collection<Recenze>();

            while (reader.Read())
            {
                Recenze recenze = new Recenze();
                int i = -1;
                recenze.Datum = reader.GetDateTime(++i);
                recenze.Cislo = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    recenze.Text = reader.GetString(i);
                }
                recenze.IdZak = reader.GetInt32(++i);
                recenze.IdFilm = reader.GetInt32(++i);
                recenzes.Add(recenze);
            }
            return recenzes;
        }
    }
}
