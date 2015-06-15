using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ReginfoRepository;

namespace GmsKeygen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var list = ReginfoRepository.Common.GetMachineCode();
            if (list != null && list.Count>0)
            {
                this.textBoxSn.Text = list[0];
            }
            
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (this.textBoxCompanyCode.Text.Length < 1)
            {
                MessageBox.Show("请输入单位编号！", "提示");
                return;
            }

            if (this.textBoxCompanyName.Text.Length < 1)
            {
                MessageBox.Show("请输入单位名称！", "提示");
                return;
            }

            if (this.textBoxSn.Text.Length < 1)
            {
                MessageBox.Show("请输入目标机序列号！", "提示");
                return;
            }

            string strCipher = ReginfoRepository.Common.MakeKey(new RegInfo()
            {
                CompanyCode = textBoxCompanyCode.Text,
                CompanyName = textBoxCompanyName.Text,

                PcSn = textBoxSn.Text,

                LifeStartTime = dtLifeStart.Value,
                LifeEndTime = dtLifeEnd.Value,

                ImportStartTime = dtImportStart.Value,
                ImportEndTime = dtImportEnd.Value
            });

            KeyShowForm fm = new KeyShowForm();

            fm.SetSN(strCipher);

            fm.ShowDialog();
        }

        private void dtImportEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtLifeStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtLifeEnd_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
