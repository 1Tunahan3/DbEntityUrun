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
    public partial class FormUyeGiris : Form
    {
        public FormUyeGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbEntityUrunEntities db = new DbEntityUrunEntities();
            var sorgu = from x in db.TBLGIRIS where x.Kullanıcı == textBox1.Text && x.Sifre == textBox2.Text select x;
            if (sorgu.Any())
            {
                FrmAnaGiris frm=new FrmAnaGiris();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATA");
            }
        }
    }
}
