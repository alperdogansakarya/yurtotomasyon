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
    public partial class FormGeliristatistik : Form
    {
        public FormGeliristatistik()
        {
            InitializeComponent();
        }

        private void FormGeliristatistik_Load(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktar) from Kasa", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label2.Text = oku[0].ToString() + " TL";
            }
            baglanti.Close();


            //tekrarsız olarak ayları listeleme

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select distinct (OdemeAy) from Kasa", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox1.Items.Add(oku2[0].ToString());
            }
            baglanti.Close();


            // aylık kazanç manuel
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select OdemeAy,sum(OdemeMiktar) from Kasa group by OdemeAy", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(oku3[0], oku3[1]);
            }
            baglanti.Close() ;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum (OdemeMiktar) from kasa where OdemeAy=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label4.Text = oku[0].ToString();

            }
            baglanti.Close();

        }
    }
}
