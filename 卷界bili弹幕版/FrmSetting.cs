using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 卷界bili弹幕版
{
    public partial class FrmSetting : Form
    {
        public FrmMain frmMain;
        public FrmSetting(FrmMain frm)
        {
            InitializeComponent();
            frmMain = frm;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            frmMain.SaveGame();
            MessageBox.Show("保存成功");
        }

        private void FrmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void buttonload_Click(object sender, EventArgs e)
        {
            frmMain.LoadGame();
        }

        private void buttonopensave_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process exep = new System.Diagnostics.Process();
            exep.StartInfo.FileName = "notepad.exe";
            exep.StartInfo.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LBSoft\RWdm\gsave.rwd";
            exep.Start();

        }

        private void linkLabelHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.exlb.org/rollworlddm/");
        }

        private void linkLabelOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/LorisYounger/RollWorldDM");

        }

        private void linkLabelUpg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://download.exlb.org/?rootPath=./RollworldDM");

        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = frmMain.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                frmMain.TextBox1.Font = fontDialog1.Font;
                frmMain.TextBox1HP.SetRTF(frmMain.TextBox1);
            }
        }
    }
}
