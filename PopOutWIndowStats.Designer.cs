namespace GIAC
{
    partial class PopOutWIndowStats
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
            this.groupBoxAtt = new System.Windows.Forms.GroupBox();
            this.tbxTickRate = new System.Windows.Forms.TextBox();
            this.groupBoxAtt.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAtt
            // 
            this.groupBoxAtt.Controls.Add(this.tbxTickRate);
            this.groupBoxAtt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxAtt.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAtt.Name = "groupBoxAtt";
            this.groupBoxAtt.Size = new System.Drawing.Size(250, 473);
            this.groupBoxAtt.TabIndex = 0;
            this.groupBoxAtt.TabStop = false;
            // 
            // tbxTickRate
            // 
            this.tbxTickRate.Location = new System.Drawing.Point(144, 19);
            this.tbxTickRate.Name = "tbxTickRate";
            this.tbxTickRate.Size = new System.Drawing.Size(100, 20);
            this.tbxTickRate.TabIndex = 0;
            this.tbxTickRate.WordWrap = false;
            this.tbxTickRate.TextChanged += new System.EventHandler(this.tbxTickRate_TextChanged);
            // 
            // PopOutWIndowStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.groupBoxAtt);
            this.Name = "PopOutWIndowStats";
            this.Text = "PopOutWIndowStats";
            this.Load += new System.EventHandler(this.PopOutWIndowStats_Load);
            this.groupBoxAtt.ResumeLayout(false);
            this.groupBoxAtt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAtt;
        private System.Windows.Forms.TextBox tbxTickRate;

    }
}