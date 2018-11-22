namespace LHJ.NaverSTT
{
    partial class frmMain
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(401, 276);
            this.textBox1.TabIndex = 0;
            // 
            // btnStt
            // 
            this.btnStt.Location = new System.Drawing.Point(12, 12);
            this.btnStt.Name = "btnStt";
            this.btnStt.Size = new System.Drawing.Size(75, 23);
            this.btnStt.TabIndex = 1;
            this.btnStt.Text = "음성인식";
            this.btnStt.UseVisualStyleBackColor = true;
            this.btnStt.Click += new System.EventHandler(this.btnStt_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(425, 326);
            this.Controls.Add(this.btnStt);
            this.Controls.Add(this.textBox1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStt;
    }
}