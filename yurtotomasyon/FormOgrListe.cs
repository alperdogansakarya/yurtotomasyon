using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace yurtotomasyon
{
    public partial class FormOgrListe : Form
    {
        public FormOgrListe()
        {
            InitializeComponent();
        }
        private void ogrlisteac()
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            try
            {

                SqlCommand komut = new SqlCommand("Select * From  Ogrenci", baglanti);
                using (SqlDataAdapter adapter = new SqlDataAdapter(komut))
                {

                    DataTable veritablosu = new DataTable();
                    adapter.Fill(veritablosu);

                    dataGridView1.DataSource = veritablosu;

                }
                komut.ExecuteNonQuery();
                baglanti.Close();


            }



            catch (Exception ex)
            {
                MessageBox.Show("Bir Sorun Oluştu" + ex.ToString());
            }

        }
        private void FormOgrListe_Load(object sender, EventArgs e)
        {
            ogrlisteac();

        }
        //secilen satırdaki hücrelere tıklandığı zaman ogrenci ekleme ve silme formuna geçirmek için yazdığım kod parçası
        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            FormOgrDuzenle fr=new FormOgrDuzenle();
            fr.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            fr.ad=dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            fr.soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            fr.tc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            fr.telefon = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            fr.dogum = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            fr.bolum = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            fr.mail = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            fr.odano = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            fr.veliad = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            fr.velitel = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            fr.adres = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            fr.Show();
        }
    }
}
