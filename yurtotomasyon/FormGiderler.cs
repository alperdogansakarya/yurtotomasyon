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
    public partial class FormGiderler : Form
    {
        public FormGiderler()
        {
            InitializeComponent();
        }
        //gider tablosuna kullanıcının giderlerini eklemesini sağlayan kısım
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into giderler (Elektrik,Su,Dogalgaz,Internet,Gıda,Personel,Diger)" +
                    " values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtelektrik.Text);
                komut.Parameters.AddWithValue("@p2", txtsu.Text);
                komut.Parameters.AddWithValue("@p3", txtdogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", txtinternet.Text);
                komut.Parameters.AddWithValue("@p5", txtgida.Text);
                komut.Parameters.AddWithValue("@p6", txtpersonel.Text);
                komut.Parameters.AddWithValue("@p7", txtdiger.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıtlar Başarılı Bir Şeklilde Eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Sorun Oluştu " + ex.ToString());
            }
        }
    }
}
