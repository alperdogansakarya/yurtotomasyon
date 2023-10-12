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
    public partial class FormYoneticiislemleri : Form
    {
        public FormYoneticiislemleri()
        {
            InitializeComponent();
        }
        private void admingetir()
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Admin", baglanti);
            using (SqlDataAdapter adapter = new SqlDataAdapter(komut))
            {

                DataTable veritablosu = new DataTable();
                adapter.Fill(veritablosu);

                dataGridView1.DataSource = veritablosu;

            }
            komut.ExecuteNonQuery();
            baglanti.Close();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            admingetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti =  new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Admin (YoneticiAd,YoneticiSifre) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.ExecuteNonQuery();
            baglanti.Close() ;
            MessageBox.Show("Kayıt İşleminiz Başarıyla Gerçekleşti");
            admingetir();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Admin WHERE Yoneticiid=@k1", baglanti);
            komut.Parameters.AddWithValue("@k1", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşleminiz Başarıyla Gerçekleşti");
            admingetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Admin set YoneticiAd=@m1,YoneticiSifre=@m2 where Yoneticiid=@m3", baglanti);
            komut.Parameters.AddWithValue("@m1", textBox2.Text);
            komut.Parameters.AddWithValue("@m2", textBox3.Text);
            komut.Parameters.AddWithValue("@m3", textBox1.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşleminiz Başarıyla Gerçekleşti");
            admingetir();
        }
    }
}
