namespace NullDTO
{
    public class RecenzeNull
    {
        public int? IdZak { get; set; }
        public int? IdFilm { get; set; }
        public int? Cislo { get; set; }

        public RecenzeNull()
        {
            IdZak = null;
            IdFilm = null;
            Cislo = null;
        }
    }
}
