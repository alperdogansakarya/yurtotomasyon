using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yurtotomasyon
{
    public partial class FormGiderListesi : Form
    {
        public FormGiderListesi()
        {
            InitializeComponent();
        }
        private void giderlistele()
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from Giderler", baglanti);
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
                MessageBox.Show("Bir Sorun Oluştu " + ex.ToString());
            }

        }
        private void FormGiderListesi_Load(object sender, EventArgs e)
        {
            giderlistele();
        }
        int secilen;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FormGiderGuncelle frg = new FormGiderGuncelle();
            secilen = dataGridView1.SelectedCells[0].RowIndex;
           
            frg.giderid = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            frg.elektrik = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            frg.su = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            frg.dogalgaz = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            frg.internet = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            frg.gida = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            frg.personel= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            frg.diger = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            frg.Show();

        }
    }
}
