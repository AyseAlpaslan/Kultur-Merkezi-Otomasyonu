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
    public partial class Egitim : Form
    {
        public Egitim()
        {
            InitializeComponent();
        }

        CenterContainer con = new CenterContainer();

        public void Liste()
        {
            dataGridView1.DataSource = con.EgitimlerSet.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Egitimler save = new Egitimler();
            save.EgitimAdi = textBox4.Text;
            save.EgitimSaati =Convert.ToInt32(textBox1.Text);
            save.EgitimTuru = textBox2.Text;
            save.EgitimUcreti = Convert.ToDecimal(textBox3.Text);
            save.EgitimGunu = textBox5.Text;
            save.SubeNo = Convert.ToInt32(textBox6.Text);
            con.EgitimlerSet.Add(save);
            con.SaveChanges();
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int eno = Convert.ToInt32(textBox4.Tag);
            var sil = con.EgitimlerSet.Where(x => x.EgitimNo == eno).FirstOrDefault();
            con.EgitimlerSet.Remove(sil);
            con.SaveChanges();
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int eno = Convert.ToInt32(textBox4.Tag);
            var yenile = con.EgitimlerSet.Where(x => x.EgitimNo == eno).FirstOrDefault();
            yenile.EgitimAdi = textBox4.Text;
            yenile.EgitimSaati = Convert.ToInt32(textBox1.Text);
            yenile.EgitimTuru = textBox2.Text;
            yenile.EgitimUcreti = Convert.ToDecimal(textBox3.Text);
            yenile.EgitimGunu = textBox5.Text;
            yenile.SubeNo = Convert.ToInt32(textBox6.Text);
            con.EgitimlerSet.Add(yenile);
            con.SaveChanges();
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox4.Tag = satir.Cells["EgitimNo"].Value.ToString();
            textBox4.Text = satir.Cells["EgitimAdi"].Value.ToString();
            textBox1.Text = satir.Cells["EgitimSaati"].Value.ToString();
            textBox2.Text = satir.Cells["EgitimTuru"].Value.ToString();
            textBox3.Text = satir.Cells["EgitimUcreti"].Value.ToString();
            textBox5.Text = satir.Cells["EgitimGunu"].Value.ToString();
            textBox6.Text = satir.Cells["ŞubeNo"].Value.ToString();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ogrenci yeni = new Ogrenci();
            yeni.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sube go = new Sube();
            go.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Egitmen yeni = new Egitmen();
            yeni.Show();
            this.Hide();
        }
    }
}
