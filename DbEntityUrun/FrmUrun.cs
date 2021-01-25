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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                    select new
                    {
                        x.URUNID,
                        x.URUNAD,
                        x.FIYAT,
                        x.STOK,
                        x.TblKategori.AD,
                        x.MARKA,
                        x.DURUM
                    }
                ).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = txtAd.Text;
            t.MARKA = txtMarka.Text;
            t.STOK = short.Parse(txtStok.Text);
            t.DURUM = true;
            t.FIYAT = decimal.Parse(txtFiyat.Text);
            t.KATEGORI = int.Parse(cmbKategori.SelectedValue.ToString());
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(txtid.Text);
            var urun = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(txtid.Text);
            var urun = db.TBLURUN.Find(x);
            urun.URUNAD = txtAd.Text;
            urun.STOK = short.Parse(txtStok.Text);
            urun.MARKA = txtMarka.Text;
            db.SaveChanges();
            MessageBox.Show("güncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TblKategori
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }
                ).ToList();
            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember = "AD";
            cmbKategori.DataSource = kategoriler;

        }
    }
}
