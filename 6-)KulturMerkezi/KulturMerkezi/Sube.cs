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
    public partial class Sube : Form
    {
        public Sube()
        {
            InitializeComponent();
        }
        CenterContainer con = new CenterContainer();

        public void Liste()
        {
            dataGridView1.DataSource = con.SubelerSet.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;     
            textBox4.Tag = satir.Cells["SubeNo"].Value.ToString();
            textBox4.Text = satir.Cells["SubeAdi"].Value.ToString();
            textBox1.Text = satir.Cells["SubeAdresi"].Value.ToString();
            textBox2.Text = satir.Cells["EgitmenSayisi"].Value.ToString();
            textBox3.Text = satir.Cells["ProgramSayisi"].Value.ToString();
      
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sno = Convert.ToInt32(textBox4.Tag);
            var sil = con.SubelerSet.Where(x => x.SubeNo == sno).FirstOrDefault();
            con.SubelerSet.Remove(sil);
            con.SaveChanges();
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sno = Convert.ToInt32(textBox4.Tag);
            var yenile = con.SubelerSet.Where(x => x.SubeNo == sno).FirstOrDefault();
            yenile.SubeAdi = textBox4.Text;
            yenile.SubeAdresi = textBox1.Text;
            yenile.EgitmenSayisi = Convert.ToInt32(textBox2.Text);
            yenile.ProgramSayisi = Convert.ToInt32(textBox3.Text);
            con.SaveChanges();
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subeler save = new Subeler();
            save.SubeAdi = textBox4.Text;
            save.SubeAdresi = textBox1.Text;
            save.EgitmenSayisi = Convert.ToInt32(textBox2.Text);
            save.ProgramSayisi = Convert.ToInt32(textBox3.Text);
            con.SubelerSet.Add(save);
            con.SaveChanges();
            Liste();
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
            Egitmen yeni = new Egitmen();
            yeni.Show();
            this.Hide();
        }
    }
}
