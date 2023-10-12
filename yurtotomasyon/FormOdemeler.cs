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
using System.Security.Cryptography;

namespace yurtotomasyon
{
    public partial class FormOdemeler : Form
    {
        public FormOdemeler()
        {
            InitializeComponent();
        }

        private void baslangıctablo()
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select Ogrid, OgrAd,OgrSoyad, OgrkalanBorc From Borclar", baglanti);
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


        private void FormOdemeler_Load(object sender, EventArgs e)
        {
            baslangıctablo();
        }

       //  odeme alma tablosu için borç değişkenlerini tanımladığım ve odeme yapan ogrencilerin borcundan 
       //  düşmesini sağladığım ve yurt kasasına da eklediğim kod parçası 
        private void button1_Click(object sender, EventArgs e)
        { 
            decimal odenen, kalan, yeniborc;
            odenen = decimal.Parse(textBox4.Text) / 10000;
            kalan = decimal.Parse(textBox5.Text) / 10000;
            yeniborc = kalan - odenen;
            textBox5.Text = yeniborc.ToString();
            SqlConnection baglanti = new SqlConnection("Server=DESKTOP-4L5TKI2\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1 where Ogrid=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox5.Text);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baslangıctablo();

            // kasa tablosuna ekleme yapma 
            baglanti.Open();
            SqlCommand komutkasa = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktar) values (@k1,@k2)", baglanti);
            komutkasa.Parameters.AddWithValue("@k1", textBox6.Text);
            komutkasa.Parameters.AddWithValue("@k2", textBox4.Text);
            komutkasa.ExecuteNonQuery();
            baglanti.Close();


        }
        int secilen;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, ad, soyad, kalanborc;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalanborc = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox1.Text = id;
            textBox2.Text = ad;
            textBox3.Text = soyad;
            textBox5.Text = kalanborc;
        }
    }
}
