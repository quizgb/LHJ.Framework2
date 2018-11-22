using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHJ.NaverTTS
{
    public partial class frmMain : Form
    {
        #region 1.Variable

        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public frmMain()
        {
            InitializeComponent();

            this.SetInitialize();
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {

        }
        #endregion 5.Set Initialize


        #region 6.Method
        private void Test1()
        {
            string FilePath = @"C:\프로필음성_이명제.wma";
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            byte[] fileData = new byte[fs.Length];
            fs.Read(fileData, 0, fileData.Length);
            fs.Close();

            string lang = "Kor";    // 언어 코드 ( Kor, Jpn, Eng, Chn )
            string url = $"https://naveropenapi.apigw.ntruss.com/recog/v1/stt?lang={lang}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-NCP-APIGW-API-KEY-ID", "4t577s67vd");
            request.Headers.Add("X-NCP-APIGW-API-KEY", "sAY1PNjhtkwU4grbCJbEgrzBgvAzZZKaBv5ObUHR");
            request.Method = "POST";
            request.ContentType = "application/octet-stream";
            request.ContentLength = fileData.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileData, 0, fileData.Length);
                requestStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            string text = reader.ReadToEnd();

            stream.Close();
            response.Close();
            reader.Close();

            this.textBox1.Text = text;
        }

        private void Test2()
        {
            string FilePath = @"C:\tts.mp3";
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            byte[] fileData = new byte[fs.Length];
            fs.Read(fileData, 0, fileData.Length);
            fs.Close();

            string lang = "Kor";    // 언어 코드 ( Kor, Jpn, Eng, Chn )
            string url = $"https://naveropenapi.apigw.ntruss.com/recog/v1/stt?lang={lang}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-NCP-APIGW-API-KEY-ID", "4t577s67vd");
            request.Headers.Add("X-NCP-APIGW-API-KEY", "sAY1PNjhtkwU4grbCJbEgrzBgvAzZZKaBv5ObUHR");
            request.Method = "POST";
            request.ContentType = "application/octet-stream";
            request.ContentLength = fileData.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileData, 0, fileData.Length);
                requestStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            string text = reader.ReadToEnd();

            stream.Close();
            response.Close();
            reader.Close();

            this.textBox1.Text = text;
        }


        #endregion 6.Method

        #region 7.Event

        #endregion 7.Event

        private void button1_Click(object sender, EventArgs e)
        {
            this.Test1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Test2();
        }
    }
}
