using BL.ClassesBL;
using BL.ModelsBL;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PujcovnaFilmuWFApp
{
    public partial class DetailForm : MaterialForm
    {
        public FilmBL FilmDB;

        public FilmModel FilmModel { get; set; }

        public DetailForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            FilmDB = new FilmBL();
            FilmModel = new FilmModel();
        }

        public void SetDetail(int row)
        {
            FilmModel = FilmDB.Detail(FilmDB.Select()[row].IdFilm);
            string title = FilmModel.Nazev + " (" + FilmModel.Rok + ")";
            Text = title;
            string cena = "Cena:      " + FilmModel.Cena + " Kč";
            materialLabel3.Text = cena;
            string kusu = "Kusu:      " + FilmModel.Kusu + " Ks";
            materialLabel4.Text = kusu;
            string typ =  "Typ:        " + FilmModel.Typ;
            materialLabel5.Text = typ;
            string delka = "Delka:    " + FilmModel.Delka;
            materialLabel6.Text = delka;
            string zeme = "Zeme:    " + FilmModel.Zeme;
            materialLabel7.Text = zeme;
            string popis = FilmModel.Popis;
            materialLabel8.Text = popis;
            string hodnoceni = FilmModel.GetPrumerneHodnoceni() + "/10";
            label1.Text = hodnoceni;
        }
    }
}
