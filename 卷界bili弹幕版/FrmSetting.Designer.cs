namespace 卷界bili弹幕版
{
    partial class FrmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonopensave = new System.Windows.Forms.Button();
            this.buttonload = new System.Windows.Forms.Button();
            this.linkLabelHelp = new System.Windows.Forms.LinkLabel();
            this.linkLabelOpen = new System.Windows.Forms.LinkLabel();
            this.linkLabelUpg = new System.Windows.Forms.LinkLabel();
            this.labelt1 = new System.Windows.Forms.Label();
            this.buttonFont = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.checkBoxNBg = new System.Windows.Forms.CheckBox();
            this.checkBoxRoll = new System.Windows.Forms.CheckBox();
            this.buttonBacKColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.numericUpDownAutoSafe = new System.Windows.Forms.NumericUpDown();
            this.buttonAutoSave = new System.Windows.Forms.Button();
            this.numericUpDownODM = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonSetOrderMax = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoSafe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownODM)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "保存游戏";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonopensave
            // 
            this.buttonopensave.Location = new System.Drawing.Point(12, 41);
            this.buttonopensave.Name = "buttonopensave";
            this.buttonopensave.Size = new System.Drawing.Size(96, 23);
            this.buttonopensave.TabIndex = 1;
            this.buttonopensave.Text = "打开保存文件";
            this.buttonopensave.UseVisualStyleBackColor = true;
            this.buttonopensave.Click += new System.EventHandler(this.buttonopensave_Click);
            // 
            // buttonload
            // 
            this.buttonload.Location = new System.Drawing.Point(12, 70);
            this.buttonload.Name = "buttonload";
            this.buttonload.Size = new System.Drawing.Size(96, 23);
            this.buttonload.TabIndex = 2;
            this.buttonload.Text = "加载游戏";
            this.buttonload.UseVisualStyleBackColor = true;
            this.buttonload.Click += new System.EventHandler(this.buttonload_Click);
            // 
            // linkLabelHelp
            // 
            this.linkLabelHelp.AutoSize = true;
            this.linkLabelHelp.Location = new System.Drawing.Point(114, 17);
            this.linkLabelHelp.Name = "linkLabelHelp";
            this.linkLabelHelp.Size = new System.Drawing.Size(209, 12);
            this.linkLabelHelp.TabIndex = 3;
            this.linkLabelHelp.TabStop = true;
            this.linkLabelHelp.Text = "使用帮助 www.exlb.org/rollworlddm/";
            this.linkLabelHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHelp_LinkClicked);
            // 
            // linkLabelOpen
            // 
            this.linkLabelOpen.AutoSize = true;
            this.linkLabelOpen.Location = new System.Drawing.Point(114, 31);
            this.linkLabelOpen.Name = "linkLabelOpen";
            this.linkLabelOpen.Size = new System.Drawing.Size(269, 12);
            this.linkLabelOpen.TabIndex = 4;
            this.linkLabelOpen.TabStop = true;
            this.linkLabelOpen.Text = "开源地址 github.com/LorisYounger/RollWorldDM";
            this.linkLabelOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpen_LinkClicked);
            // 
            // linkLabelUpg
            // 
            this.linkLabelUpg.AutoSize = true;
            this.linkLabelUpg.Location = new System.Drawing.Point(114, 45);
            this.linkLabelUpg.Name = "linkLabelUpg";
            this.linkLabelUpg.Size = new System.Drawing.Size(305, 12);
            this.linkLabelUpg.TabIndex = 5;
            this.linkLabelUpg.TabStop = true;
            this.linkLabelUpg.Text = "软件更新 download.exlb.org/?rootPath=./RollworldDM";
            this.linkLabelUpg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUpg_LinkClicked);
            // 
            // labelt1
            // 
            this.labelt1.AutoSize = true;
            this.labelt1.Location = new System.Drawing.Point(114, 70);
            this.labelt1.Name = "labelt1";
            this.labelt1.Size = new System.Drawing.Size(137, 72);
            this.labelt1.TabIndex = 6;
            this.labelt1.Text = "Power By LB\r\n感谢您使用卷界\r\n\r\n自动保存            秒\r\n\r\n指令上限         次/天";
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(12, 99);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(94, 23);
            this.buttonFont.TabIndex = 7;
            this.buttonFont.Text = "全局字体设置";
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // checkBoxNBg
            // 
            this.checkBoxNBg.AutoSize = true;
            this.checkBoxNBg.Location = new System.Drawing.Point(240, 82);
            this.checkBoxNBg.Name = "checkBoxNBg";
            this.checkBoxNBg.Size = new System.Drawing.Size(72, 16);
            this.checkBoxNBg.TabIndex = 8;
            this.checkBoxNBg.Text = "背景透明";
            this.checkBoxNBg.UseVisualStyleBackColor = true;
            this.checkBoxNBg.CheckedChanged += new System.EventHandler(this.checkBoxNBg_CheckedChanged);
            // 
            // checkBoxRoll
            // 
            this.checkBoxRoll.AutoSize = true;
            this.checkBoxRoll.Location = new System.Drawing.Point(240, 64);
            this.checkBoxRoll.Name = "checkBoxRoll";
            this.checkBoxRoll.Size = new System.Drawing.Size(48, 16);
            this.checkBoxRoll.TabIndex = 9;
            this.checkBoxRoll.Text = "滚轮";
            this.checkBoxRoll.UseVisualStyleBackColor = true;
            this.checkBoxRoll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // buttonBacKColor
            // 
            this.buttonBacKColor.Location = new System.Drawing.Point(12, 128);
            this.buttonBacKColor.Name = "buttonBacKColor";
            this.buttonBacKColor.Size = new System.Drawing.Size(94, 23);
            this.buttonBacKColor.TabIndex = 10;
            this.buttonBacKColor.Text = "背景颜色设置";
            this.buttonBacKColor.UseVisualStyleBackColor = true;
            this.buttonBacKColor.Click += new System.EventHandler(this.buttonBacKColor_Click);
            // 
            // numericUpDownAutoSafe
            // 
            this.numericUpDownAutoSafe.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownAutoSafe.Location = new System.Drawing.Point(170, 102);
            this.numericUpDownAutoSafe.Maximum = new decimal(new int[] {
            6000000,
            0,
            0,
            0});
            this.numericUpDownAutoSafe.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownAutoSafe.Name = "numericUpDownAutoSafe";
            this.numericUpDownAutoSafe.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownAutoSafe.TabIndex = 11;
            this.numericUpDownAutoSafe.Value = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            // 
            // buttonAutoSave
            // 
            this.buttonAutoSave.Location = new System.Drawing.Point(254, 102);
            this.buttonAutoSave.Name = "buttonAutoSave";
            this.buttonAutoSave.Size = new System.Drawing.Size(93, 20);
            this.buttonAutoSave.TabIndex = 12;
            this.buttonAutoSave.Text = "设置自动保存";
            this.buttonAutoSave.UseVisualStyleBackColor = true;
            this.buttonAutoSave.Click += new System.EventHandler(this.buttonAutoSave_Click);
            // 
            // numericUpDownODM
            // 
            this.numericUpDownODM.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownODM.Location = new System.Drawing.Point(170, 127);
            this.numericUpDownODM.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownODM.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownODM.Name = "numericUpDownODM";
            this.numericUpDownODM.Size = new System.Drawing.Size(45, 21);
            this.numericUpDownODM.TabIndex = 13;
            this.numericUpDownODM.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(318, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 28);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "收集输出信息\r\n用于游戏平衡性";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonSetOrderMax
            // 
            this.buttonSetOrderMax.Location = new System.Drawing.Point(254, 125);
            this.buttonSetOrderMax.Name = "buttonSetOrderMax";
            this.buttonSetOrderMax.Size = new System.Drawing.Size(93, 20);
            this.buttonSetOrderMax.TabIndex = 15;
            this.buttonSetOrderMax.Text = "设置指令上限";
            this.buttonSetOrderMax.UseVisualStyleBackColor = true;
            this.buttonSetOrderMax.Click += new System.EventHandler(this.buttonSetOrderMax_Click);
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 160);
            this.Controls.Add(this.buttonSetOrderMax);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDownODM);
            this.Controls.Add(this.buttonAutoSave);
            this.Controls.Add(this.numericUpDownAutoSafe);
            this.Controls.Add(this.buttonBacKColor);
            this.Controls.Add(this.checkBoxRoll);
            this.Controls.Add(this.checkBoxNBg);
            this.Controls.Add(this.buttonFont);
            this.Controls.Add(this.labelt1);
            this.Controls.Add(this.linkLabelUpg);
            this.Controls.Add(this.linkLabelOpen);
            this.Controls.Add(this.linkLabelHelp);
            this.Controls.Add(this.buttonload);
            this.Controls.Add(this.buttonopensave);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSetting";
            this.Text = "卷界 控制台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSetting_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoSafe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownODM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonopensave;
        private System.Windows.Forms.Button buttonload;
        private System.Windows.Forms.LinkLabel linkLabelHelp;
        private System.Windows.Forms.LinkLabel linkLabelOpen;
        private System.Windows.Forms.LinkLabel linkLabelUpg;
        private System.Windows.Forms.Label labelt1;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.CheckBox checkBoxNBg;
        private System.Windows.Forms.CheckBox checkBoxRoll;
        private System.Windows.Forms.Button buttonBacKColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDownAutoSafe;
        private System.Windows.Forms.Button buttonAutoSave;
        private System.Windows.Forms.NumericUpDown numericUpDownODM;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonSetOrderMax;
    }
}