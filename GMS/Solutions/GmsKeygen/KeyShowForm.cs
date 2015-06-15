using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GmsKeygen
{
    public partial class KeyShowForm : Form
    {
        public KeyShowForm()
        {
            InitializeComponent();
        }

        public void SetSN(string strSn)
        {
            this.richTextBoxKey.Text = strSn;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {


        }

    }
}
