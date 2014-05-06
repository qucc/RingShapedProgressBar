namespace WaitDialogDemo
{
    partial class WaitDialog
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
            this.progressControl1 = new WaitDialogDemo.RingProgressBar();
            this.SuspendLayout();
            // 
            // progressControl1
            // 
            this.progressControl1.Location = new System.Drawing.Point(22, 12);
            this.progressControl1.Name = "progressControl1";
            this.progressControl1.Size = new System.Drawing.Size(150, 131);
            this.progressControl1.TabIndex = 1;
            // 
            // WaitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.progressControl1);
            this.Name = "WaitDialog";
            this.Text = "WaitDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private RingProgressBar progressControl1;
    }
}