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
    public partial class OgrenciGiris : Form
    {
        public OgrenciGiris()
        {
            InitializeComponent();
        }
        CenterContainer con = new CenterContainer();
        private bool GirisYap(string ad, string sifre)
        {
            var sorgu = from p in con.OgrencilerSet
                        where p.OgrenciAdSoyad == ad && p.OgrenciSifre == sifre
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

        private void OgrenciGiris_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ogrenciler save = new Ogrenciler();
            save.OgrenciAdSoyad= textBox4.Text;
            save.OgrenciSifre = textBox3.Text;
            save.OgrenciMail = textBox5.Text;
            save.OgrenciTelefon = maskedTextBox1.Text;
            con.OgrencilerSet.Add(save);
            con.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GirisYap(textBox1.Text, textBox2.Text))
            {
                Ogrenci go = new Ogrenci();
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
