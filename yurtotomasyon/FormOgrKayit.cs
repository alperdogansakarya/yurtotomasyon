using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
using System.Drawing.Text;





namespace yurtotomasyon
{

    public partial class FormOgrKayit : Form
    {


        public FormOgrKayit()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabaný;User Id=sa;Password=123456;Connect Timeout=30;");
            //bölümleri listelediðim alan
                
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select BolumAd from Bolumler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbogrbolum.Items.Add(oku[0].ToString());

            }
            baglanti.Close();

            // odalarý listelediðim alan
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select Odano  from Odalar where OdaKapasite != OdaAktif", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbodano.Items.Add(oku2[0].ToString());
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabaný;User Id=sa;Password=123456;Connect Timeout=30;");
                baglanti.Open();
                //ogrenci tablosuna textboxlardan girilen deðerleri kaydettiðim alan
                SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci(OgrAd,OgrSoyad,OgrTC,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad," +
                    "OgrVeliTelefon,OgrVeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", baglanti);

                komutkaydet.Parameters.AddWithValue("@p1", txtograd.Text);
                komutkaydet.Parameters.AddWithValue("@p2", txtogrsoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p3", msktc.Text);
                komutkaydet.Parameters.AddWithValue("@p4", msktel.Text);
                komutkaydet.Parameters.AddWithValue("@p5", mskdogumt.Text);
                komutkaydet.Parameters.AddWithValue("@p6", cmbogrbolum.Text);
                komutkaydet.Parameters.AddWithValue("@p7", txtmail.Text);
                komutkaydet.Parameters.AddWithValue("@p8", cmbodano.Text);
                komutkaydet.Parameters.AddWithValue("@p9", txtveliadsoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p10", mskvelitel.Text);
                komutkaydet.Parameters.AddWithValue("@p11", rtbadres.Text);
                komutkaydet.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayýt Baþarýlý Bir Þeklilde Gerçekleþti");

                //ogrenci id yi labela çekme 
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("select Ogrid from Ogrenci", baglanti);
                SqlDataReader oku = komut2.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();
                }

                baglanti.Close();

                // borclar kýsmýna kayýt aldýðým kýsým
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3)", baglanti);
                komut1.Parameters.AddWithValue("@b1", label12.Text);
                komut1.Parameters.AddWithValue("@b2", txtograd.Text);
                komut1.Parameters.AddWithValue("@b3", txtogrsoyad.Text);
                komut1.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayýt Gerçekleþirken Bir Sorun Oluþtu" + ex.ToString());

            }
            //ogrenci oda kontenjan arttýrma
            SqlConnection baglanti1 = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabaný;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti1.Open();
            SqlCommand komut3 = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@n1", baglanti1);
            komut3.Parameters.AddWithValue("@n1", cmbodano.Text);
            komut3.ExecuteNonQuery();
            baglanti1.Close();
            // textboxlarý temizlediðim alan
            txtograd.Clear();
            txtogrsoyad.Clear();
            msktc.Clear();
            msktel.Clear();
            mskdogumt.Clear();
            txtmail.Clear();
            txtveliadsoyad.Clear();
            mskvelitel.Clear();
            rtbadres.Clear();
        }
    }
}