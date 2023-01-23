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
    public partial class Ogrenci : Form
    {
        public Ogrenci()
        {
            InitializeComponent();
        }
        CenterContainer con = new CenterContainer();

        public void Liste()
        {
            dataGridView1.DataSource = con.OgrencilerSet.ToList();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Ogrenciler save = new Ogrenciler();
            save.OgrenciAdSoyad = textBox4.Text;
            save.OgrenciSifre = textBox3.Text;
            save.OgrenciMail = textBox5.Text;
            save.OgrenciTelefon = maskedTextBox1.Text;
            con.OgrencilerSet.Add(save);
            con.SaveChanges();
            Liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox4.Tag = satir.Cells["OgrenciNo"].Value.ToString();
            textBox4.Text = satir.Cells["OgrenciAdSoyad"].Value.ToString();
            textBox3.Text = satir.Cells["OgrenciSifre"].Value.ToString();
            textBox5.Text = satir.Cells["OgrenciMail"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["OgrenciTelefon"].Value.ToString();
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ono = Convert.ToInt32(textBox4.Tag);
            var sil = con.OgrencilerSet.Where(x => x.OgrenciNo == ono).FirstOrDefault();
            con.OgrencilerSet.Remove(sil);
            con.SaveChanges();
            Liste();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ono = Convert.ToInt32(textBox4.Tag);
            var yenile = con.OgrencilerSet.Where(x => x.OgrenciNo == ono).FirstOrDefault();
            yenile.OgrenciAdSoyad =textBox4.Text;
            yenile.OgrenciSifre = textBox3.Text;
            yenile.OgrenciMail = textBox5.Text;
            yenile.OgrenciTelefon =maskedTextBox1.Text;         
            con.SaveChanges();
            Liste();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Egitim go = new Egitim();
            go.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sube go = new Sube();
            go.Show();
            this.Hide();
        }
    }
}
