namespace GIAC
{
    partial class ImageWindow
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
            this.aniTimer = new System.Windows.Forms.Timer(this.components);
            this._Field = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // aniTimer
            // 
            this.aniTimer.Interval = 50;
            this.aniTimer.Tick += new System.EventHandler(this.aniTimer_Tick);
            // 
            // _Field
            // 
            this._Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Field.Location = new System.Drawing.Point(0, 0);
            this._Field.MinimumSize = new System.Drawing.Size(20, 20);
            this._Field.Name = "_Field";
            this._Field.ScrollBarsEnabled = false;
            this._Field.Size = new System.Drawing.Size(589, 524);
            this._Field.TabIndex = 0;
            // 
            // ImageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 524);
            this.ControlBox = false;
            this.Controls.Add(this._Field);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageWindow";
            this.Text = "ImageWindow";
            this.Load += new System.EventHandler(this.ImageWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer aniTimer;
        private System.Windows.Forms.WebBrowser _Field;
    }
}