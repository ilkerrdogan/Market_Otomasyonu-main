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

namespace Market
{
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-K9DFK8HV\MS;Initial Catalog=market_otomasyonu;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullanıcılar WHERE KullaniciAdi = '" + kullaniciAdi + "' AND Sifre = '" + sifre + "'";
            komut.ExecuteNonQuery();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                var m = new Form1();
                m.Show();
                this.Hide();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız. Tekrar Deneyiniz.");
            }
        }
        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {
            timer1.Interval = 10;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString();
        }
    }
}
