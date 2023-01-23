using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KulturMerkezi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CenterContainer con = new CenterContainer();
        private bool GirisYap(string ad, string sifre)
        {
            var sorgu = from p in con.KullanicilarSet
                        where p.KullaniciAdi == ad && p.KullaniciSifre == sifre
                        select p;
            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
            textBox1.Clear();
            textBox2.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanicilar save = new Kullanicilar();
            save.KullaniciAdi = textBox4.Text;
            save.KullaniciSifre = textBox3.Text;
            save.KullaniciMail = textBox5.Text;
            save.KullaniciTelefon = maskedTextBox1.Text;
            con.KullanicilarSet.Add(save);
            con.SaveChanges();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OgrenciGiris go = new OgrenciGiris();
            go.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GirisYap(textBox1.Text, textBox2.Text))
            {
                Egitmen go = new Egitmen();
                go.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }
        }
    }
}
