using Aspose.Page.EPS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Aspose.Page.EPS.Device;

namespace CodeReader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Свойства и переменные

        
        /// <summary>
        /// Создаем свойство для хранения занчения выбранного каталога (именно свойство а не переменную для того чтобы можно было обратиться из другого потока)
        /// </summary>
        private string SelectedPath { get; set; }

        /// <summary>
        /// тоже самое что выже но тут сохраняем количество найденых файлов для обработки 
        /// </summary>
        private int CountFlile { get; set; }

        private string QrCodePath { get; set; }

        #endregion

        #region Основные методы
        // Метод выполнения задачи в фоне
        private void BackGroundWork(object sender, DoWorkEventArgs e)
        {


        }

        // Событие изменения прогресса 
        private void Work_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        // Работа потока завершена (выполненна отменена или ошибка)
        private void Work_Completed(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        #endregion

        #region вспомогательные методы
        /// обработчик нажатия кнопки выбора каталога
        private void OpenCatalog(object sender, EventArgs e)
        {
            // Тут открываем FolderDialog для выбора нужной папки и если выбрали какую то то возвращается DialogResult.Ok
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                // Тогда присваиваем нашему свойству значение каталога
                SelectedPath = folderDialog.SelectedPath;
                // Просто показываем пользователю какой каталог выбрали
                lbPath.Text = SelectedPath;

                // создаем DirectoryInfo и считаем сколько файлов eps в выбраном каталоге и пишем в свойсто оно нам понадобится для proggresBar
                var di = new DirectoryInfo(SelectedPath);
                CountFlile = di.GetFiles("*.eps").Count();
                // отображаем на форме сколько нашли файлов на обработку
                statusLabelFiles.Text = @"Найдено : " + CountFlile + @" файлов";

                // Задаем каталог для QR Кодов в свойство QrCodePath 
                QrCodePath = SelectedPath + "\\Img\\";

                // ниже проверяем его существование если нет создаем
                var diQrCode = new DirectoryInfo(QrCodePath);
                if (!diQrCode.Exists)
                    Directory.CreateDirectory(QrCodePath);

            }
        }

        private void ConvertEpsToQRcode(FileInfo file)
        {
            // Specifies image format
            var imageFormat = ImageFormat.Jpeg;

            // Initialize PostScript input stream
            var document = new PsDocument(new FileStream(file.FullName, FileMode.Open, FileAccess.Read));

            // If you want to convert Postscript file despite of minor errors set this flag
            var suppressErrors = true;

            //Initialize options object with necessary parameters.
            var options = new ImageSaveOptions(suppressErrors);

            // If you want to add special folder where fonts are stored. Default fonts folder in OS is always included.
            //options.AdditionalFontsFolders = new string[] { @"{FONT_FOLDER}" };

            // Default image size is 595x842 and it is not mandatory to set it in ImageDevice
            var device = new ImageDevice(new Size(512,512),imageFormat);

            // But if you need to specify size use constructor with two parameters
            //ImageDevice device = new ImageDevice(new System.Drawing.Size(595, 842), imageFormat);

            try
            {
                document.Save(device, options);
            }
            finally
            {
                //psStream.Close();
            }

            byte[][] imagesBytes = device.ImagesBytes;

            int i = 0;

            foreach (byte[] imageBytes in imagesBytes)
            {
                string imagePath = Path.GetFullPath("out_image" + i.ToString() + "." + imageFormat.ToString().ToLower());
                using (FileStream fs = new FileStream(imagePath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(imageBytes, 0, imageBytes.Length);
                }
                i++;
            }

            //Review errors
            if (suppressErrors)
            {
                foreach (PsConverterException ex in options.Exceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string ReadQrCodeFile(string file)
        {
            throw new NotImplementedException();
        }

        // Это событие нажатия кнопки запуск в работу (работу зпаускаем если соблюдены все условия наличия того что требуется обработать)
        private void RunWork(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedPath) || CountFlile < 1)
                return;

            //if (!backgroundWorker1.IsBusy)
            //    backgroundWorker1.RunWorkerAsync();

            foreach (var file in new DirectoryInfo(SelectedPath).GetFiles("*.eps"))
            {
                //Console.WriteLine(file);
                ConvertEpsToQRcode(file);
            }
        }

        #endregion

    }
}