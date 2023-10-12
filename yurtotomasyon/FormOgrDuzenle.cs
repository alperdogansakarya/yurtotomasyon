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
using Microsoft.VisualBasic;
using System.Collections;

namespace yurtotomasyon
{
    public partial class FormOgrDuzenle : Form
    {
        public FormOgrDuzenle()
        {
            InitializeComponent();
        }
        public string id, ad, soyad, tc, telefon, dogum, bolum, mail, odano, veliad, velitel, adres;
        private void FormOgrDuzenle_Load(object sender, EventArgs e)
        {
            txtOgrId.Text = id;
            txtograd.Text = ad;
            txtogrsoyad.Text = soyad;
            msktc.Text = tc;
            msktel.Text = telefon;
            mskdogumt.Text = dogum;
            cmbogrbolum.Text = bolum;
            txtmail.Text = mail;
            cmbodano.Text = odano;
            txtveliadsoyad.Text = veliad;
            mskvelitel.Text = velitel;
            rtbadres.Text = adres;
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\\SQLEXPRESS;Initial Catalog=yurtveritabanı; integrated security=true;");
            //bölümleri listelediğim alan

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select BolumAd from Bolumler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbogrbolum.Items.Add(oku[0].ToString());   

            }
            baglanti.Close();

            // odaları listelediğim alan
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
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\\SQLEXPRESS;Initial Catalog=yurtveritabanı; integrated security=true;");
            baglanti.Open();
            try
            {
                SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2,OgrSoyad=@p3,OgrTC=@p4,OgrTelefon=@p5,OgrDogum=@p6,OgrBolum=@p7,OgrMail=@p8,OgrOdaNo=@p9,OgrVeliAdSoyad=@p10,OgrVeliTelefon=@p11,OgrVeliAdres=@p12 where Ogrid=@p1", baglanti);

                komut.Parameters.AddWithValue("@p1", txtOgrId.Text);
                komut.Parameters.AddWithValue("@p2", txtograd.Text);
                komut.Parameters.AddWithValue("@p3", txtogrsoyad.Text);
                komut.Parameters.AddWithValue("@p4", msktc.Text);
                komut.Parameters.AddWithValue("@p5", msktel.Text);
                komut.Parameters.AddWithValue("@p6", mskdogumt.Text);
                komut.Parameters.AddWithValue("@p7", cmbogrbolum.Text);
                komut.Parameters.AddWithValue("@p8", txtmail.Text);
                komut.Parameters.AddWithValue("@p9", cmbodano.Text);
                komut.Parameters.AddWithValue("@p10", txtveliadsoyad.Text);
                komut.Parameters.AddWithValue("@p11", mskvelitel.Text);
                komut.Parameters.AddWithValue("@p12", rtbadres.Text);
                komut.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Kayıt Güncellendi");


            }
            catch (Exception ex)
            {


                MessageBox.Show("Bir Sorun Oluştu" + ex.ToString());
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {


            SqlConnection baglanti = new SqlConnection(@"Data Source=.\\SQLEXPRESS;Initial Catalog=yurtveritabanı; integrated security=true;");
            baglanti.Open();
            try
            {
                SqlCommand komut = new SqlCommand("delete from Ogrenci where Ogrid=@ogrid1", baglanti);
                SqlCommand komut2 = new SqlCommand("delete from Borclar where Ogrid=@ogrid2", baglanti);
                komut.Parameters.AddWithValue("@ogrid1", txtOgrId.Text);
                komut2.Parameters.AddWithValue("@ogrid2", txtOgrId.Text);
                komut.ExecuteNonQuery();
                komut2.ExecuteNonQuery();
                MessageBox.Show("Silme İşlemi Başarılı");

              //odadan adam çıkarma
                SqlCommand komut3 = new SqlCommand("update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@n1", baglanti);
                komut3.Parameters.AddWithValue("@n1", cmbodano.Text);
                komut3.ExecuteNonQuery();
                baglanti.Close();

            }
            catch (Exception ex)
            {


                MessageBox.Show("Bir Sorun Oluştu" + ex.ToString());
            }

        }

     
    }
}
