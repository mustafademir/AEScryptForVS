using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mustafa
{
    public partial class aes : Form
    {
        String a = cry.GenerateNewPassword(32);
        
        public aes()
        {
            InitializeComponent();
           
        }

        private void btnSifrele_Click(object sender, EventArgs e)
        {
            
            txtSifreli.Text = cry.SifreleAES(txtMetin.Text, a);
            txtSharedKey.Text = a;
        }

        private void btnSifreyiCoz_Click(object sender, EventArgs e)
        {
            txtDesifre.Text = cry.SifreyiCozAES(txtSifreli.Text, a);
        }

        private void txtSharedKey_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
