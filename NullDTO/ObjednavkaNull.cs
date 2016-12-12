namespace NullDTO
{
    public class ObjednavkaNull
    {
        public bool? Vydano { get; set; }
        public bool? Vraceno { get; set; }
        public int? IdZak { get; set; }
        public int? IdFilm { get; set; }
        public int? IdVydejce { get; set; }

        public ObjednavkaNull()
        {
            Vydano = null;
            Vraceno = null;
            IdZak = null;
            IdFilm = null;
            IdVydejce = null;
        }
    }
}
