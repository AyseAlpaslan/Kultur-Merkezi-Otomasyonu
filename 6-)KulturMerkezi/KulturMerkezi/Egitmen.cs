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
    public partial class Egitmen : Form
    {
        public Egitmen()
        {
            InitializeComponent();
        }
        CenterContainer con = new CenterContainer();
        public void Liste()
        {
            dataGridView1.DataSource = con.EgitmenlerSet.ToList();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Egitmen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Egitmenler save = new Egitmenler();
            save.EgitmenAdi = textBox4.Text;
            save.EgitmenSifre = textBox3.Text;
            save.EgitmenMail = textBox5.Text;
            save.EgitmenTelefon = maskedTextBox1.Text;
            save.EgitmenAlani = textBox1.Text;
            save.SubeNo =Convert.ToInt32(textBox2.Text);
            con.EgitmenlerSet.Add(save);
            con.SaveChanges();
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox4.Tag = satir.Cells["EgitmenNo"].Value.ToString();
            textBox4.Text = satir.Cells["EgitmenAdi"].Value.ToString();
            textBox3.Text = satir.Cells["EgitmenSifre"].Value.ToString();
            textBox5.Text = satir.Cells["EgitmenMail"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["EgitmenTelefon"].Value.ToString();
            textBox1.Text = satir.Cells["EgitmenAlani"].Value.ToString();
            textBox2.Text = satir.Cells["SubeNo"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int eno = Convert.ToInt32(textBox4.Tag);
            var sil = con.EgitmenlerSet.Where(x => x.EgitmenNo == eno).FirstOrDefault();
            con.EgitmenlerSet.Remove(sil);
            con.SaveChanges();
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int eno = Convert.ToInt32(textBox4.Tag);
            var yenile = con.EgitmenlerSet.Where(x => x.EgitmenNo == eno).FirstOrDefault();
            yenile.EgitmenAdi = textBox4.Text;
            yenile.EgitmenSifre = textBox3.Text;
            yenile.EgitmenMail = textBox5.Text;
            yenile.EgitmenTelefon = maskedTextBox1.Text;
            yenile.EgitmenAlani = textBox1.Text;
            yenile.SubeNo =Convert.ToInt32(textBox2.Text);
            con.SaveChanges();
            Liste();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ogrenci yeni = new Ogrenci();
            yeni.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Egitim yeni = new Egitim();
            yeni.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sube yeni = new Sube();
            yeni.Show();
            this.Hide();
        }
    }
}
