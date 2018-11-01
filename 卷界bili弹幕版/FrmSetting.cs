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
        //TODO:收集输出信息用于游戏平衡性
        public FrmMain frmMain;
        public FrmSetting(FrmMain frm)
        {
            InitializeComponent();
            frmMain = frm;

            numericUpDownODM.Value = Properties.Settings.Default.CanUserOrderMax;
            numericUpDownAutoSafe.Value = Properties.Settings.Default.AutoSaveInterval;
            numericUpDowntxt.Value = Properties.Settings.Default.TxtLine;
            numericUpDowntxtwide.Value = Properties.Settings.Default.Txtwide;
            checkBoxtxt.Checked = Properties.Settings.Default.IsTXTOut;
            checkBoxNBg.Checked = Properties.Settings.Default.IsTranspare;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            frmMain.SaveGame();
            MessageBox.Show("保存成功");
        }

        private void FrmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
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
            fontDialog1.Font = Properties.Settings.Default.MainFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.MainFont = fontDialog1.Font;
                frmMain.TextBox1.Font = Properties.Settings.Default.MainFont;
                frmMain.TextBox1HP.SetRTF(frmMain.TextBox1);
            }
        }

        private void checkBoxNBg_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNBg.Checked)
            {
                frmMain.TransparencyKey = frmMain.TextBox1.BackColor;
            }
            else
            {
                frmMain.TransparencyKey = TransparencyKey;
            }
            Properties.Settings.Default.IsTranspare = checkBoxNBg.Checked;
        }

        private void buttonBacKColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Properties.Settings.Default.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.BackColor = colorDialog1.Color;
                frmMain.TextBox1.BackColor = Properties.Settings.Default.BackColor;
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
            Properties.Settings.Default.AutoSaveInterval = Convert.ToInt32(numericUpDownAutoSafe.Value);
            frmMain.timer1.Interval = Properties.Settings.Default.AutoSaveInterval * 1000;
            MessageBox.Show("设置成功");
        }

        private void buttonSetOrderMax_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CanUserOrderMax = Convert.ToInt32(numericUpDownODM.Value);
            MessageBox.Show("设置成功");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsTXTOut = checkBoxtxt.Checked;
        }

        private void checkBoxhidect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxhidect.Checked)
            {
                frmMain.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                frmMain.FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void buttontxtpath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LBSoft\RWdm");
        }

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            frmMain.TopMost = checkBoxTopMost.Checked;
        }

        private void buttontxt_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TxtLine = Convert.ToInt32(numericUpDowntxt.Value);
            Properties.Settings.Default.Txtwide = Convert.ToInt32(numericUpDowntxtwide.Value);
            MessageBox.Show("设置成功");
        }
    }
}
