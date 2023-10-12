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
    public partial class FormGiderGuncelle : Form
    {
        public FormGiderGuncelle()
        {
            InitializeComponent();
        }
        public string giderid, elektrik, su, dogalgaz, internet, gida, personel, diger;
        private void Form1GiderGuncelle_Load(object sender, EventArgs e)
        {
            txtgiderid.Text = giderid;
            txtelektrik.Text = elektrik;
            txtsu.Text = su;
            txtdogalgaz.Text = dogalgaz;
            txtinternet.Text = internet;
            txtgida.Text = gida;
            txtpersonel.Text = personel;
            txtdiger.Text = diger;




        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            try
            {
                SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p2,Su=@p3,Dogalgaz=@p4,Internet=@p5,Gıda=@p6,Personel=@p7,Diger=@p8 where Odemeid=@p1", baglanti);

                komut.Parameters.AddWithValue("@p1", txtgiderid.Text);
                komut.Parameters.AddWithValue("@p2", txtelektrik.Text);
                komut.Parameters.AddWithValue("@p3", txtsu.Text);
                komut.Parameters.AddWithValue("@p4", txtdogalgaz.Text);
                komut.Parameters.AddWithValue("@p5", txtinternet.Text);
                komut.Parameters.AddWithValue("@p6", txtgida.Text);
                komut.Parameters.AddWithValue("@p7", txtpersonel.Text);
                komut.Parameters.AddWithValue("@p8", txtdiger.Text);

                komut.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi");


            }
            catch (Exception ex)
            {


                MessageBox.Show("Bir Sorun Oluştu" + ex.ToString());
            }



        }
    }
}
