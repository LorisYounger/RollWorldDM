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

        private void checkBoxNBg_CheckedChanged(object sender, EventArgs e)
        {
            frmMain.TransparencyKey = frmMain.TextBox1.BackColor;
        }

        private void buttonBacKColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = frmMain.TextBox1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                frmMain.TextBox1.BackColor = colorDialog1.Color;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRoll.Checked)
            {
                frmMain.TextBox1.ScrollBars = RichTextBoxScrollBars.Both;
            }
            else
            {
                frmMain.TextBox1.ScrollBars = RichTextBoxScrollBars.None;
            }
        }

        private void buttonAutoSave_Click(object sender, EventArgs e)
        {
            frmMain.timer1.Interval = Convert.ToInt32(numericUpDownAutoSafe.Value * 1000);
            MessageBox.Show("设置成功");
        }

        private void buttonSetOrderMax_Click(object sender, EventArgs e)
        {
            frmMain.CanUserOrderMax = Convert.ToInt32(numericUpDownODM.Value);
            MessageBox.Show("设置成功");
        }
    }
}
