namespace NullDTO
{
    public class ZakaznikNull
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Email { get; set; }

        public ZakaznikNull()
        {
            Jmeno = "";
            Prijmeni = "";
            Email = "";
        }
    }
}
