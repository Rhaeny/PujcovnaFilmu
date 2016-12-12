namespace NullDTO
{
    public class FilmNull
    {
        public string Nazev { get; set; }
        public int? Rok { get; set; }
        public int? Cena { get; set; }
        public int? Kusu { get; set; }
        public string Typ { get; set; }

        public FilmNull()
        {
            Nazev = "";
            Rok = null;
            Cena = null;
            Kusu = null;
            Typ = "";
        }
    }
}
