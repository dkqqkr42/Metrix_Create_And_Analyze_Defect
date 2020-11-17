namespace FinalProject_Profile.PopupForm
{
    partial class BarcodePopup_InspectionDTL
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
            this.ptb_Barcode = new System.Windows.Forms.PictureBox();
            this.lbl_Barcode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb_Barcode
            // 
            this.ptb_Barcode.Location = new System.Drawing.Point(248, 64);
            this.ptb_Barcode.Name = "ptb_Barcode";
            this.ptb_Barcode.Size = new System.Drawing.Size(296, 336);
            this.ptb_Barcode.TabIndex = 0;
            this.ptb_Barcode.TabStop = false;
            // 
            // lbl_Barcode
            // 
            this.lbl_Barcode.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_Barcode.Font = new System.Drawing.Font("Segoe UI", 19F);
            this.lbl_Barcode.Location = new System.Drawing.Point(304, 8);
            this.lbl_Barcode.Name = "lbl_Barcode";
            this.lbl_Barcode.Size = new System.Drawing.Size(192, 48);
            this.lbl_Barcode.TabIndex = 16;
            this.lbl_Barcode.Text = "바코드";
            this.lbl_Barcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BarcodePopup_InspectionDTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Barcode);
            this.Controls.Add(this.ptb_Barcode);
            this.Name = "BarcodePopup_InspectionDTL";
            this.Text = "바코드";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.BarcodePopup_InspectionDTL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Barcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_Barcode;
        private System.Windows.Forms.Label lbl_Barcode;
    }
}