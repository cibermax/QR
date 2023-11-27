using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using DataMatrix.net;

namespace QR
{
    public partial class Form1 : Form
    {
        string PatchFolder = "";
        string PatchFolderImg = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SdelatBLIA(string path)
        {
                string fileName = Path.GetFileName(path);
                fileName = fileName.Substring(0, fileName.Length - 4);
                FileStream psStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                PsDocument document = new PsDocument(psStream);
                bool suppressErrors = true;
                ImageSaveOptions options = new ImageSaveOptions(suppressErrors);
                ImageFormat imageFormat = ImageFormat.Jpeg;
                ImageDevice device = new ImageDevice(new Size(512, 512), imageFormat);
                try
                {
                    document.Save(device, options);
                }
                finally
                {
                    psStream.Close();
                }


                //############################################
                byte[][] imagesBytes = device.ImagesBytes;
                int i = 0;
                string imagePath = PatchFolderImg + fileName + ".Jpeg";
                foreach (byte[] imageBytes in imagesBytes)
                {

                    using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(imageBytes, 0, imageBytes.Length);
                    }
                    i++;
                }
                //####################################################################################
                DmtxImageDecoder decoder = new DmtxImageDecoder();
            Bitmap oBitmap = new Bitmap(imagePath);
                List<string> oList = decoder.DecodeImage(oBitmap);

                StringBuilder sb = new StringBuilder();
                sb.Length = 0;
                foreach (string s in oList)
                {
                    sb.Append(s);
                }
                
                textBox1.Text = textBox1.Text + sb.ToString() + " \n";
                


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PatchFolderImg == "")
            {
                return;
            }
            string[] file_list = Directory.GetFiles(PatchFolder, "*.eps");
            textBox1.Text = DateTime.Now.ToString() + " \n";
            foreach (string path in file_list)
            {
                SdelatBLIA(path);
            }
            textBox1.Text = textBox1.Text + DateTime.Now.ToString() + " \n";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                PatchFolder = FBD.SelectedPath;
                PatchFolderImg = PatchFolder + "\\Img\\";
                if (Directory.Exists(PatchFolderImg) == false)
                {
                    Directory.CreateDirectory(PatchFolderImg);
                }
            }

        }
    }
}
