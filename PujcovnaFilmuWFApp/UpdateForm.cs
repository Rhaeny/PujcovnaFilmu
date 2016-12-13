using System.Drawing;
using BL.ClassesBL;
using BL.ModelsBL;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PujcovnaFilmuWFApp
{
    public partial class UpdateForm : MaterialForm
    {
        public FilmBL FilmDB { get; set; }
        public FilmModel FilmModel { get; set; }
        public Form1 Form1 { get; set; }

        public UpdateForm(Form1 form1)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            Form1 = form1;

            FilmDB = new FilmBL();
            FilmModel = new FilmModel();
        }

        public void SetUpdate(int row)
        {
            FilmModel = FilmDB.Detail(FilmDB.Select()[row].IdFilm);
            materialSingleLineTextField1.Text = FilmModel.Nazev;
            materialSingleLineTextField2.Text = FilmModel.Rok.ToString();
            materialSingleLineTextField3.Text = FilmModel.Cena.ToString();
            materialSingleLineTextField4.Text = FilmModel.Kusu.ToString();
            materialSingleLineTextField5.Text = FilmModel.Typ;
            materialSingleLineTextField6.Text = FilmModel.Delka.ToString();
            materialSingleLineTextField7.Text = FilmModel.Zeme;
            materialSingleLineTextField8.Text = FilmModel.Popis;
        }

        private void materialSingleLineTextField1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (materialSingleLineTextField1.Text == "")
            {
                materialSingleLineTextField1.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
        }

        private void materialSingleLineTextField1_Validated(object sender, System.EventArgs e)
        {
            if (materialSingleLineTextField1.Text != "")
            {
                materialSingleLineTextField1.BackColor = Color.White;
            }
        }

        private void materialSingleLineTextField2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(materialSingleLineTextField2.Text, out i))
            {
                materialSingleLineTextField2.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
        }

        private void materialSingleLineTextField2_Validated(object sender, System.EventArgs e)
        {
            int i;
            if (int.TryParse(materialSingleLineTextField2.Text, out i))
            {
                materialSingleLineTextField2.BackColor = Color.White;
            }
        }

        private void materialSingleLineTextField3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(materialSingleLineTextField3.Text, out i))
            {
                materialSingleLineTextField3.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
        }

        private void materialSingleLineTextField3_Validated(object sender, System.EventArgs e)
        {
            int i;
            if (int.TryParse(materialSingleLineTextField3.Text, out i))
            {
                materialSingleLineTextField3.BackColor = Color.White;
            }
        }

        private void materialSingleLineTextField4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(materialSingleLineTextField4.Text, out i))
            {
                materialSingleLineTextField4.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
        }

        private void materialSingleLineTextField4_Validated(object sender, System.EventArgs e)
        {
            int i;
            if (int.TryParse(materialSingleLineTextField4.Text, out i))
            {
                materialSingleLineTextField4.BackColor = Color.White;
            }
        }

        private void materialSingleLineTextField6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(materialSingleLineTextField6.Text, out i))
            {
                materialSingleLineTextField6.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
        }

        private void materialSingleLineTextField6_Validated(object sender, System.EventArgs e)
        {
            int i;
            if (int.TryParse(materialSingleLineTextField6.Text, out i))
            {
                materialSingleLineTextField6.BackColor = Color.White;
            }
        }

        private void materialFlatButton2_Click(object sender, System.EventArgs e)
        {
            int i;
            if (materialSingleLineTextField1.Text != ""
                && int.TryParse(materialSingleLineTextField2.Text, out i)
                && int.TryParse(materialSingleLineTextField3.Text, out i)
                && int.TryParse(materialSingleLineTextField4.Text, out i)
                && int.TryParse(materialSingleLineTextField6.Text, out i))
            {
                FilmModel.Nazev = materialSingleLineTextField1.Text;
                FilmModel.Rok = int.Parse(materialSingleLineTextField2.Text);
                FilmModel.Cena = int.Parse(materialSingleLineTextField3.Text);
                FilmModel.Kusu = int.Parse(materialSingleLineTextField4.Text);
                FilmModel.Typ = materialSingleLineTextField5.Text;
                FilmModel.Delka = int.Parse(materialSingleLineTextField6.Text);
                FilmModel.Zeme = materialSingleLineTextField7.Text;
                FilmModel.Popis = materialSingleLineTextField8.Text;
                FilmDB.Update(FilmModel);
                Form1.RefreshDataGridView();
                Close();
            }
        }

        private void materialFlatButton1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
