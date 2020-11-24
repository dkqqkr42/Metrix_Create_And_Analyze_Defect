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
            this.lbl_Barcode = new System.Windows.Forms.Label();
            this.lbl_BAR_NO = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ptb_Barcode = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Close = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Barcode)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Barcode
            // 
            this.lbl_Barcode.BackColor = System.Drawing.Color.PowderBlue;
            this.lbl_Barcode.Font = new System.Drawing.Font("Segoe UI", 19F);
            this.lbl_Barcode.Location = new System.Drawing.Point(136, 8);
            this.lbl_Barcode.Name = "lbl_Barcode";
            this.lbl_Barcode.Size = new System.Drawing.Size(192, 48);
            this.lbl_Barcode.TabIndex = 16;
            this.lbl_Barcode.Text = "바코드";
            this.lbl_Barcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_BAR_NO
            // 
            this.lbl_BAR_NO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_BAR_NO.AutoSize = true;
            this.lbl_BAR_NO.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_BAR_NO.Location = new System.Drawing.Point(3, 10);
            this.lbl_BAR_NO.Name = "lbl_BAR_NO";
            this.lbl_BAR_NO.Size = new System.Drawing.Size(99, 23);
            this.lbl_BAR_NO.TabIndex = 17;
            this.lbl_BAR_NO.Text = "lbl_BAR_NO";
            this.lbl_BAR_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ptb_Barcode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.27586F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.448276F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(423, 473);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // ptb_Barcode
            // 
            this.ptb_Barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptb_Barcode.Location = new System.Drawing.Point(4, 4);
            this.ptb_Barcode.Name = "ptb_Barcode";
            this.ptb_Barcode.Size = new System.Drawing.Size(415, 415);
            this.ptb_Barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_Barcode.TabIndex = 0;
            this.ptb_Barcode.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.86747F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.13253F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_BAR_NO, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Close, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 426);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(415, 43);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.BackgroundImage = global::FinalProject_Profile.Properties.Resources.닫기5;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Close.Location = new System.Drawing.Point(318, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(97, 43);
            this.btn_Close.TabIndex = 18;
            this.btn_Close.UseSelectable = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Close_MouseDown);
            this.btn_Close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Close_MouseUp);
            // 
            // BarcodePopup_InspectionDTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 553);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbl_Barcode);
            this.Name = "BarcodePopup_InspectionDTL";
            this.Text = "바코드";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.BarcodePopup_InspectionDTL_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Barcode)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_Barcode;
        private System.Windows.Forms.Label lbl_Barcode;
        private System.Windows.Forms.Label lbl_BAR_NO;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton btn_Close;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}