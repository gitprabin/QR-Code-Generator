/*
*@created By : Prabin Siwakoti
*@created On : 2018-04-12
*@email : developer.prabin@gmail.com
*/
using System;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace QR_Code_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        QrCodeEncodingOptions options = new QrCodeEncodingOptions();

        private void Form1_Load(object sender, EventArgs e)
        {
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 100,
                Height = 100,
                Margin = 1
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPlainText.Text) || String.IsNullOrEmpty(txtPlainText.Text))
            {
                MessageBox.Show("Text not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pictureBox1.Image = null;
                var qr = new BarcodeWriter();
                qr.Options = options;
                qr.Format = BarcodeFormat.QR_CODE;
                var result = new Bitmap(qr.Write(txtPlainText.Text.Trim()));
                pictureBox1.Image = result;
                txtPlainText.Clear();
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryInverted = true };
                Result result = reader.Decode(bitmap);
                string decoded = result.ToString().Trim();
                txtPlainText.Text = decoded;
            }
            catch (Exception)
            {
                MessageBox.Show("Image not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                var qr = new BarcodeWriter();
                qr.Options = options;
                qr.Format = BarcodeFormat.QR_CODE;
                pictureBox1.ImageLocation = open.FileName;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Image not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.CreatePrompt = true;
                save.OverwritePrompt = true;
                save.FileName = "QR";
                save.Filter = "PNG|*.png|JPEG|*.jpg|BMP|*.bmp|GIF|*.gif";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(save.FileName);
                    save.InitialDirectory = Environment.GetFolderPath
                                (Environment.SpecialFolder.Desktop);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            btnExcel.Text = "Please Wait...";
            btnExcel.Enabled = false;

            try
            {
                if (String.IsNullOrWhiteSpace(txtSavePath.Text))
                {
                    MessageBox.Show("Please Enter Path To Save QR Codes.");
                    btnBrowser.Focus();
                    btnExcel.Enabled = true; btnExcel.Text = "Generate";
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtExcelPath.Text))
                {
                    MessageBox.Show("Please Select Excel File.");
                    btnExcelBrowse.Focus();
                    btnExcel.Text = "Generate && Save";
                    btnExcel.Enabled = true;
                    return;
                }

                string path = txtExcelPath.Text;

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlWorkBook = xlApp.Workbooks.Open(path);

                Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

                Range xlRange = xlWorkSheet.UsedRange;

                int totalRows = xlRange.Rows.Count;

                int totalColumns = xlRange.Columns.Count;

                string photoId, name, school, contact, qrString;

                int i = 0;

                for (int rowCount = 2; rowCount <= totalRows; rowCount++)
                {
                    photoId = Convert.ToString((xlRange.Cells[rowCount, 1] as Range).Text);

                    name = Convert.ToString((xlRange.Cells[rowCount, 2] as Range).Text);

                    school = Convert.ToString((xlRange.Cells[rowCount, 3] as Range).Text);

                    contact = Convert.ToString((xlRange.Cells[rowCount, 4] as Range).Text);

                    qrString = name + "," + school + "," + contact;

                    if (String.IsNullOrWhiteSpace(qrString))
                        continue;

                    //crate qr bitmap
                    var qr = new BarcodeWriter();
                    qr.Options = options;
                    qr.Format = BarcodeFormat.QR_CODE;
                    var result = new Bitmap(qr.Write((qrString).Trim()));

                    result.Save(txtSavePath.Text.Trim() + "\\" + photoId + ".png", ImageFormat.Png);
                    i++;
                }

                xlWorkBook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

                MessageBox.Show("Total " + i + " QR Codes Are Generated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Generate QR Code, Please try again later, Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnExcel.Text = "Generate && Save";
            btnExcel.Enabled = true;

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSavePath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnExcelBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            string path = txtExcelPath.Text;

            if (open.ShowDialog() == DialogResult.OK)
            {
                txtExcelPath.Text = open.FileName;
            }
        }
    }
}
