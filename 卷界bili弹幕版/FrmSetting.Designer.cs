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
            this.labelt1.Size = new System.Drawing.Size(89, 24);
            this.labelt1.TabIndex = 6;
            this.labelt1.Text = "Power By LB\r\n感谢您使用卷界";
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(209, 71);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(94, 23);
            this.buttonFont.TabIndex = 7;
            this.buttonFont.Text = "全局字体设置";
            this.buttonFont.UseVisualStyleBackColor = true;
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 103);
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
    }
}