using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinOcr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            var ApiKey = "Sd5OH4BMmAqwKZvG6O56oqed";
            var SecretKey = "UX70FFACkOGb0at4q3ljzkYTaKC87vgG";
            var client = new Baidu.Aip.Ocr.Ocr(ApiKey, SecretKey);

            //   var tuPian = @"F:\Project\C#\百度通用文字识别\Baidu-OCR-API-master\Baidu-OCR-API-master\test images\chi-scan-300dpi - TOO LARGE.jpg";
            //   var image = File.ReadAllBytes(tuPian);

            var image = ImageToBase64(pictureBox.BackgroundImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            if (image == null)
            {
                MessageBox.Show("请先加载图片");
                return;
            }
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                { "language_type", "CHN_ENG"},
                { "detect_direction", "true"},
                { "detect_language", "true"},
                { "probability", "true"}
            };
            // 通用文字识别
            var result = client.GeneralBasic(image, options);

            OcrResult ocrResult = result.ToObject<OcrResult>();

            foreach (var item in ocrResult.words_result)
            {
                if (cbLine.Checked)
                    txtResult.AppendText(item.words + "\n");
                else
                    txtResult.AppendText(item.words);
            }
        }

        /// <summary>
        /// 身份证识别
        /// </summary>
        public void IdcardDemo()
        {
            var ApiKey = "Sd5OH4BMmAqwKZvG6O56oqed";
            var SecretKey = "UX70FFACkOGb0at4q3ljzkYTaKC87vgG";
            var client = new Baidu.Aip.Ocr.Ocr(ApiKey, SecretKey);

            var image = ImageToBase64(pictureBox.BackgroundImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            if (image == null)
            {
                MessageBox.Show("请先加载图片");
                return;
            }
            var idCardSide = "front";  //front 正面  back 背面

            // 调用身份证识别，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.Idcard(image, idCardSide);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                { "detect_direction", "true"},
                { "detect_risk", "false"}
            };
            // 带参数调用身份证识别
            result = client.Idcard(image, idCardSide, options);
            Console.WriteLine(result);
        }
        /// <summary>
        /// 车牌识别
        /// </summary>
        public void LicensePlateDemo()
        {
            var ApiKey = "Sd5OH4BMmAqwKZvG6O56oqed";
            var SecretKey = "UX70FFACkOGb0at4q3ljzkYTaKC87vgG";
            var client = new Baidu.Aip.Ocr.Ocr(ApiKey, SecretKey);

            var image = ImageToBase64(pictureBox.BackgroundImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            if (image == null)
            {
                MessageBox.Show("请先加载图片");
                return;
            }

            // 调用车牌识别，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.LicensePlate(image);
            Console.WriteLine(result);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                { "multi_detect", "true"}
            };
            // 带参数调用车牌识别
            result = client.LicensePlate(image, options);

            OcrResult ocrResult = result.ToObject<OcrResult>();
            if (ocrResult.words_result == null)
            {
                MessageBox.Show("未检测到车牌");
                return;
            }
            foreach (var item in ocrResult.words_result)
            {
                txtResult.AppendText(item.color +"牌"+item.number+ "\n");
            }
            //  Console.WriteLine(result);
        }


        private byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();
                    return imageBytes;
                }
            }
            catch
            {

                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "jpeg files|*.jpg;*.JPG";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(fileDlg.FileName);
                //if (fileInfo.Length > 300 * 1024)
                //{
                //    MessageBox.Show("jpeg file's size can not be larger than 300kb");
                //    return;
                //}
                pictureBox.BackgroundImage = Image.FromFile(fileDlg.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IdcardDemo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LicensePlateDemo();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var ApiKey = "Sd5OH4BMmAqwKZvG6O56oqed";
            var SecretKey = "UX70FFACkOGb0at4q3ljzkYTaKC87vgG";
            var client = new Baidu.Aip.Ocr.Ocr(ApiKey, SecretKey);

            //   var tuPian = @"F:\Project\C#\百度通用文字识别\Baidu-OCR-API-master\Baidu-OCR-API-master\test images\chi-scan-300dpi - TOO LARGE.jpg";
            //   var image = File.ReadAllBytes(tuPian);

            var image = ImageToBase64(pictureBox.BackgroundImage, System.Drawing.Imaging.ImageFormat.Jpeg);

            if (image == null)
            {
                MessageBox.Show("请先加载图片");
                return;
            }
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                { "language_type", "CHN_ENG"},
                { "detect_direction", "true"},
                { "detect_language", "true"},
                { "probability", "true"}
            };
            // 通用文字识别
            var result = client.AccurateBasic(image, options);

            OcrResult ocrResult = result.ToObject<OcrResult>();

            foreach (var item in ocrResult.words_result)
            {
                if(cbLine.Checked)
                 txtResult.AppendText(item.words + "\n");
                else
                   txtResult.AppendText(item.words);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           pictureBox.BackgroundImage= System.Windows.Forms.Clipboard.GetImage();
        }
    }
}
