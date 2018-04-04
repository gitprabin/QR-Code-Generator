using System;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Drawing;

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
                Width = 250,
                Height = 250,
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPlainText.Text) || String.IsNullOrEmpty(txtPlainText.Text))
            {
                pictureBox1.Image = null;
                MessageBox.Show("Text not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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
    }
}
