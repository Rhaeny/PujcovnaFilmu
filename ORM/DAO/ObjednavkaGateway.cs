using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using DTO;

namespace ORM.DAO
{
    public class ObjednavkaGateway
    {
        public static string TableName = "Objednavka";

        public static string SqlSelect =
            "SELECT IdObj, DatumObj, DobaPujceni, Vydano, DatumVydani, Vraceno, DatumVraceni, IdZak, IdFilm, IdVydejce " +
            "FROM Objednavka ";

        public static string SqlSelectBy =
            "SELECT IdObj, DatumObj, DobaPujceni, Vydano, DatumVydani, Vraceno, DatumVraceni, IdZak, IdFilm, IdVydejce " +
            "FROM Objednavka ";

        public static string SqlDetail =
            "SELECT IdObj, DatumObj, DobaPujceni, Vydano, DatumVydani, Vraceno, DatumVraceni, IdZak, IdFilm, IdVydejce " +
            "FROM Objednavka " +
            "WHERE IdObj = @IdObj ";

        public static string SqlInsert =
            "INSERT INTO Objednavka " +
            "VALUES(@DatumObj, @DobaPujceni, @Vydano, @DatumVydani, @Vraceno, @DatumVraceni, @IdZak, @IdFilm, @IdVydejce) ";

        public static string SqlUpdate =
            "UPDATE Objednavka " +
            "SET DatumObj = @DatumObj, DobaPujceni = @DobaPujceni, Vydano = @Vydano, DatumVydani = @DatumVydani, Vraceno = @Vraceno, DatumVraceni = @DatumVraceni " +
            "WHERE IdObj = @IdObj ";

        public static string SqlDelete =
            "DELETE FROM Objednavka " +
            "WHERE IdObj = @IdObj ";

        #region Statické metody

        public static int Insert(Objednavka objednavka)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlInsert);
            PrepareCommand(command, objednavka);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static int Update(Objednavka objednavka)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlUpdate);
            PrepareCommand(command, objednavka);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        public static Collection<Objednavka> Select()
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlSelect);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objednavky = Read(reader);
            reader.Close();
            
            db.Close();
            return objednavky;
        }

        public static Collection<Objednavka> SelectBy(bool? vydano = null, bool? vraceno = null,
            int? idZak = null, int? idFilm = null, int? idVydejce = null)
        {
            var db = new Database();
            db.Connect();

            bool first = false;

            if (vydano != null)
            {
                first = true;
                SqlSelectBy += "WHERE Vydano = @Vydano ";
            }
            if (vraceno != null)
            {
                if (first)
                    SqlSelectBy += "AND Vraceno = @Vraceno ";
                else
                {
                    first = true;
                    SqlSelectBy += "WHERE Vraceno = @Vraceno ";
                }
            }
            if (idZak != null)
            {
                if (first)
                    SqlSelectBy += "AND IdZak = @IdZak ";
                else
                {
                    first = true;
                    SqlSelectBy += "WHERE IdZak = @IdZak ";
                }
            }
            if (idFilm != null)
            {
                if (first)
                    SqlSelectBy += "AND IdFilm = @IdFilm ";
                else
                {
                    first = true;
                    SqlSelectBy += "WHERE IdFilm = @IdFilm ";
                }
            }
            if (idVydejce != null)
            {
                if (first)
                    SqlSelectBy += "AND IdVydejce = @IdVydejce ";
                else
                {
                    SqlSelectBy += "WHERE IdVydejce = @IdVydejce ";
                }
            }

            SqlCommand command = db.CreateCommand(SqlSelectBy);
            
            if (vydano != null)
                command.Parameters.AddWithValue("@Vydano", vydano);
            if (vraceno != null)
                command.Parameters.AddWithValue("@Vraceno", vraceno);
            if (idZak != null)
                command.Parameters.AddWithValue("@IdZak", idZak);
            if (idFilm != null)
                command.Parameters.AddWithValue("@IdFilm", idFilm);
            if (idVydejce != null)
                command.Parameters.AddWithValue("@IdVydejce", idVydejce);

            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objednavky = Read(reader);
            reader.Close();

            SqlSelectBy = SqlSelect;
            
            db.Close();
            return objednavky;
        }

        public static Objednavka Detail(int idObj)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlDetail);

            command.Parameters.AddWithValue("@IdObj", idObj);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> objednavky = Read(reader);
            Objednavka objednavka = null;
            if (objednavky.Count == 1)
            {
                objednavka = objednavky[0];
            }
            reader.Close();
            
            db.Close();
            return objednavka;
        }

        public static int Delete(int idObj)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SqlDelete);
            command.Parameters.AddWithValue("@IdObj", idObj);
            int ret = db.ExecuteNonQuery(command);
            
            db.Close();
            return ret;
        }

        #endregion

        private static void PrepareCommand(SqlCommand command, Objednavka objednavka)
        {
            command.Parameters.AddWithValue("@IdObj", objednavka.IdObj);
            command.Parameters.AddWithValue("@DatumObj", objednavka.DatumObj);
            command.Parameters.AddWithValue("@DobaPujceni", objednavka.DobaPujceni);
            command.Parameters.AddWithValue("@Vydano", objednavka.Vydano);
            command.Parameters.AddWithValue("@DatumVydani", objednavka.DatumVydani == null ? DBNull.Value : (object)objednavka.DatumVydani);
            command.Parameters.AddWithValue("@Vraceno", objednavka.Vraceno);
            command.Parameters.AddWithValue("@DatumVraceni", objednavka.DatumVraceni == null ? DBNull.Value : (object)objednavka.DatumVraceni);
            command.Parameters.AddWithValue("@IdZak", objednavka.IdZak);
            command.Parameters.AddWithValue("@IdFilm", objednavka.IdFilm);
            command.Parameters.AddWithValue("@IdVydejce", objednavka.IdVydejce);
        }

        private static Collection<Objednavka> Read(SqlDataReader reader)
        {
            Collection<Objednavka> objednavky = new Collection<Objednavka>();

            while (reader.Read())
            {
                Objednavka objednavka = new Objednavka();
                int i = -1;
                objednavka.IdObj = reader.GetInt32(++i);
                objednavka.DatumObj = reader.GetDateTime(++i);
                objednavka.DobaPujceni = reader.GetInt32(++i);
                objednavka.Vydano = reader.GetBoolean(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.DatumVydani = reader.GetDateTime(i);
                }
                objednavka.Vraceno = reader.GetBoolean(++i);
                if (!reader.IsDBNull(++i))
                {
                    objednavka.DatumVraceni = reader.GetDateTime(i);
                }
                objednavka.IdZak = reader.GetInt32(++i);
                objednavka.IdFilm = reader.GetInt32(++i);
                objednavka.IdVydejce = reader.GetInt32(++i);
                objednavky.Add(objednavka);
            }
            return objednavky;
        }

        public static void ExportToXML(string fileName)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                Collection<Objednavka> objednavky = Select();
                foreach (var objednavka in objednavky)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Objednavka));
                    xmlSerializer.Serialize(stringWriter, objednavka);
                }
                File.WriteAllText(fileName + ".xml", stringWriter.ToString());
            }
        }
    }
}
