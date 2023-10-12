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
    public partial class FormPersonel : Form
    {
        public FormPersonel()
        {
            InitializeComponent();
        }

        private void personelgetir()
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Personel", baglanti);
            using (SqlDataAdapter adapter = new SqlDataAdapter(komut))
            {

                DataTable veritablosu = new DataTable();
                adapter.Fill(veritablosu);

                dataGridView1.DataSource = veritablosu;

            }
            komut.ExecuteNonQuery();
            baglanti.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşleminiz Başarıyla Gerçekleşti");
            personelgetir();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Personel WHERE Personelid=@k1", baglanti);
            komut.Parameters.AddWithValue("@k1", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşleminiz Başarıyla Gerçekleşti");
            personelgetir();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection(@"Data Source=.\\SQLEXPRESS;Initial Catalog=yurtveritabanı; integrated security=true;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Personel set PersonelAdSoyad=@m1,PersonelDepartman=@m2 where Personelid=@m3", baglanti);
            komut.Parameters.AddWithValue("@m1", textBox2.Text);
            komut.Parameters.AddWithValue("@m2", textBox3.Text);
            komut.Parameters.AddWithValue("@m3", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşleminiz Başarıyla Gerçekleşti");
            personelgetir();
        }

        private void FormPersonel_Load(object sender, EventArgs e)
        {
            personelgetir();
        }
    }
}
