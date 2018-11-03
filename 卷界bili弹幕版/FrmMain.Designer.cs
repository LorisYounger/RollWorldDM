namespace 卷界bili弹幕版
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelphb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.BackColor = System.Drawing.Color.Ivory;
            this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox1.Font = new System.Drawing.Font("宋体", 24F);
            this.TextBox1.Location = new System.Drawing.Point(0, 0);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.TextBox1.Size = new System.Drawing.Size(809, 508);
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 360000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelphb
            // 
            this.labelphb.AutoSize = true;
            this.labelphb.BackColor = System.Drawing.Color.Ivory;
            this.labelphb.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelphb.Location = new System.Drawing.Point(609, 0);
            this.labelphb.Name = "labelphb";
            this.labelphb.Size = new System.Drawing.Size(200, 48);
            this.labelphb.TabIndex = 1;
            this.labelphb.Text = "战力排行榜  (每小时刷新)\r\n\r\n金币排行榜  (每小时刷新)";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 508);
            this.Controls.Add(this.labelphb);
            this.Controls.Add(this.TextBox1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "卷界 弹幕版";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.RichTextBox TextBox1;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label labelphb;
    }
}