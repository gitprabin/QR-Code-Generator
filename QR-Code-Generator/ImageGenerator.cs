using System.Drawing;
using ZXing;
using ZXing.QrCode;

namespace QR_Code_Generator
{
    public static class ImageGenerator
    {
        static QrCodeEncodingOptions options = new QrCodeEncodingOptions();
        public static Bitmap GetQrCodeImage(string text)
        {
            var qr = new BarcodeWriter();
            qr.Options = options;
            qr.Format = BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(text.Trim()));
            return result;
        }
    }
}
