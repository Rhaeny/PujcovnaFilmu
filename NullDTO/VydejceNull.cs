namespace NullDTO
{
    public class VydejceNull
    {
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Email { get; set; }

        public VydejceNull()
        {
            Jmeno = "";
            Prijmeni = "";
            Email = "";
        }
    }
}
