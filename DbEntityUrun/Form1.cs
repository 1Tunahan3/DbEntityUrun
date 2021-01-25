using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbEntityUrun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db=new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TblKategori.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblKategori tbl=new TblKategori();
            tbl.AD = textBox2.Text;
            db.TblKategori.Add(tbl);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(textBox1.Text);
            var ktgr = db.TblKategori.Find(x);
            db.TblKategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(textBox1.Text);
            var ktgr = db.TblKategori.Find(x);
            ktgr.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncellendi");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
