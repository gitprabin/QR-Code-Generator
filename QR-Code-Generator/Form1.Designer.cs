namespace QR_Code_Generator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlainText = new System.Windows.Forms.RichTextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lblExcelPath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Text";
            // 
            // txtPlainText
            // 
            this.txtPlainText.Location = new System.Drawing.Point(24, 49);
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.Size = new System.Drawing.Size(207, 174);
            this.txtPlainText.TabIndex = 1;
            this.txtPlainText.Text = "";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(24, 244);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(207, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate QR Code";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(24, 273);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(207, 23);
            this.btnDecode.TabIndex = 2;
            this.btnDecode.Text = "Decode QR Code";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(25, 302);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(207, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse a Local Image";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(264, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(264, 244);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(185, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(264, 273);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(185, 23);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Generate From Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lblExcelPath
            // 
            this.lblExcelPath.AutoSize = true;
            this.lblExcelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcelPath.ForeColor = System.Drawing.Color.Red;
            this.lblExcelPath.Location = new System.Drawing.Point(261, 302);
            this.lblExcelPath.Name = "lblExcelPath";
            this.lblExcelPath.Size = new System.Drawing.Size(35, 13);
            this.lblExcelPath.TabIndex = 5;
            this.lblExcelPath.Text = "label2";
            this.lblExcelPath.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 333);
            this.Controls.Add(this.lblExcelPath);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtPlainText);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QR-Code-Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtPlainText;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblExcelPath;
    }
}

