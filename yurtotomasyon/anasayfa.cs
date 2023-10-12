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
    public partial class anasayfa : Form
    {
            
        public anasayfa()
        {
            InitializeComponent();
        }
        //anasayfada kullanıcının öğrencilerin listesini gormesi adına sqlden çektiğim tablonun kodu
        private void anasayfa_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Server=.\\SQLEXPRESS;Database=yurtveritabanı;User Id=sa;Password=123456;Connect Timeout=30;");
            baglanti.Open();
            try
            {
                SqlCommand komut = new SqlCommand("select Ogrid ,OgrAd,OgrSoyad,OgrOdaNo from Ogrenci", baglanti);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable veritablosu = new DataTable();
                adapter.Fill(veritablosu);
                dataGridView1.DataSource = veritablosu;
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Sorun Oluştu" + ex.ToString());
            }

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOgrKayit fr = new FormOgrKayit();
            fr.Show();
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOgrListe fr = new FormOgrListe();
            fr.Show();

        }

        //menustrip'deki sekmelerin baglanmasına bir örnek
        private void öğrenciGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOgrDuzenle fr = new FormOgrDuzenle();
            fr.Show();

        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBolum fr = new FormBolum();
            fr.Show();
        }

        private void bölümDüzenlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBolum fr = new FormBolum();
            fr.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOdemeler fr = new FormOdemeler();
            fr.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGiderler fr = new FormGiderler();
            fr.Show();
        }

        private void giderListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGiderListesi fr = new FormGiderListesi();
            fr.Show();
        }

        private void gelirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGeliristatistik fr = new FormGeliristatistik();
            fr.Show();
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormYoneticiislemleri fr = new FormYoneticiislemleri();
            fr.Show();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonel fr = new FormPersonel();
            fr.Show();
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNotEkle fr = new FormNotEkle();
            fr.Show();
        }
    }
}
