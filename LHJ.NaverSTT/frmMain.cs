using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LHJ.NaverSTT
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
        private void SpeechToText()
        {
            string filePath = @"C:\tts.mp3";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("먼저 네이버 TTS번역기에서 음성파일을 생성하세요.");
                return;
            }

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] fileData = new byte[fs.Length];
            fs.Read(fileData, 0, fileData.Length);
            fs.Close();

            string lang = "Kor";    // 언어 코드 ( Kor, Jpn, Eng, Chn )
            string url = $"https://naveropenapi.apigw.ntruss.com/recog/v1/stt?lang={lang}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-NCP-APIGW-API-KEY-ID", Definition.ConstValue.ConstValue.NaverCloudClintInfo.ID);
            request.Headers.Add("X-NCP-APIGW-API-KEY", Definition.ConstValue.ConstValue.NaverCloudClintInfo.PASS);
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
        private void btnStt_Click(object sender, EventArgs e)
        {
            this.SpeechToText();
        }
        #endregion 7.Event
    }
}
