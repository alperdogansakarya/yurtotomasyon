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
    public partial class FormBolum : Form
    {
        public FormBolum()
        {
            InitializeComponent();
        }

        private void bolumtablosuac()
        {

            try
            {
                SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select* from Bolumler order by Bolumid", baglanti);

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
        private void FormBolum_Load(object sender, EventArgs e)
        {
            bolumtablosuac();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Bolumler (BolumAd) values (@p1) ", baglanti);
                komut.Parameters.AddWithValue("@p1", txtbolumad.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ekleme İşlemi Gerçekleşi");
                bolumtablosuac();



            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Sorun Oluştu" + ex.ToString());
            }




        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Bolumler where Bolumid=@p1", baglanti);

                komut.Parameters.AddWithValue("@p1", txtbolumid.Text);

                MessageBox.Show("Silme İşlemi Gerçekleşti");
                bolumtablosuac();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Sorun Oluştu" + ex.ToString());
            }

        }

        //örnek olarak bölümler tablosunda bölümleri güncelleme işlemini denetlediğim kod parçası
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Bolumler set BolumAd=@p1 where Bolumid=@p2 ", baglanti);
                komut.Parameters.AddWithValue("@p1", txtbolumad.Text);
                komut.Parameters.AddWithValue("@p2", txtbolumid.Text);
                MessageBox.Show("Güncelleme İşlemi Gerçekleşti");

                komut.ExecuteNonQuery();
                bolumtablosuac();
                baglanti.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir Sorun Oluştu" + ex.ToString());
            }


        }



        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtbolumid.Text = id;
            txtbolumad.Text = bolumad;
        }
    }
}
