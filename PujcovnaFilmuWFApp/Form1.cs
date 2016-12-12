using System;
using System.Windows.Forms;
using BL.ClassesBL;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PujcovnaFilmuWFApp
{
    public partial class Form1 : MaterialForm
    {
        public FilmBL FilmDB;

        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            FilmDB = new FilmBL();

            ZobrazitFilmy();
        }

        public void ZobrazitFilmy()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = FilmDB.Select();

            var dataGridViewColumn1 = dataGridView1.Columns["IdFilm"];
            if (dataGridViewColumn1 != null)
            {
                dataGridViewColumn1.Visible = false;
            }

            var dataGridViewColumn2 = dataGridView1.Columns["Popis"];
            if (dataGridViewColumn2 != null)
            {
                dataGridViewColumn2.Visible = false;
            }

            var dataGridViewColumn3 = dataGridView1.Columns["Nazev"];
            if (dataGridViewColumn3 != null)
            {
                dataGridViewColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public void RefreshDataGridView()
        {
            dataGridView1.DataSource = FilmDB.Select();
            dataGridView1.Update();
        }

        private void materialFlatButton1_Click(object sender, System.EventArgs e)
        {
            DetailForm dForm = new DetailForm();
            dForm.SetDetail(dataGridView1.CurrentCell.RowIndex);
            dForm.ShowDialog();
        }

        private void materialFlatButton4_Click(object sender, System.EventArgs e)
        {
            InsertForm iForm = new InsertForm();
            iForm.ShowDialog();
        }

        private void materialFlatButton3_Click(object sender, System.EventArgs e)
        {
            FilmDB.Delete(FilmDB.Select()[dataGridView1.CurrentCell.RowIndex].IdFilm);
            RefreshDataGridView();
        }
    }
}
