namespace CodeReader
{
    partial class MainForm
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
            System.Windows.Forms.Button buttOpenCatalog;
            this.tbCodes = new System.Windows.Forms.TextBox();
            this.buttReadCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPath = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabelFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            buttOpenCatalog = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttOpenCatalog
            // 
            buttOpenCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttOpenCatalog.Location = new System.Drawing.Point(680, 11);
            buttOpenCatalog.Margin = new System.Windows.Forms.Padding(4);
            buttOpenCatalog.Name = "buttOpenCatalog";
            buttOpenCatalog.Size = new System.Drawing.Size(175, 28);
            buttOpenCatalog.TabIndex = 6;
            buttOpenCatalog.Text = "Выбрать каталог";
            buttOpenCatalog.UseVisualStyleBackColor = true;
            buttOpenCatalog.Click += new System.EventHandler(this.OpenCatalog);
            // 
            // tbCodes
            // 
            this.tbCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCodes.Location = new System.Drawing.Point(13, 46);
            this.tbCodes.Margin = new System.Windows.Forms.Padding(4);
            this.tbCodes.Multiline = true;
            this.tbCodes.Name = "tbCodes";
            this.tbCodes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCodes.Size = new System.Drawing.Size(659, 443);
            this.tbCodes.TabIndex = 5;
            this.tbCodes.UseSystemPasswordChar = true;
            // 
            // buttReadCode
            // 
            this.buttReadCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttReadCode.Location = new System.Drawing.Point(680, 46);
            this.buttReadCode.Margin = new System.Windows.Forms.Padding(4);
            this.buttReadCode.Name = "buttReadCode";
            this.buttReadCode.Size = new System.Drawing.Size(175, 28);
            this.buttReadCode.TabIndex = 4;
            this.buttReadCode.Text = "Прочитать коды";
            this.buttReadCode.UseVisualStyleBackColor = true;
            this.buttReadCode.Click += new System.EventHandler(this.RunWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "КАТАЛОГ:";
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(89, 17);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(0, 16);
            this.lbPath.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.statusLabelFiles});
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(868, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 18);
            // 
            // statusLabelFiles
            // 
            this.statusLabelFiles.Name = "statusLabelFiles";
            this.statusLabelFiles.Size = new System.Drawing.Size(17, 20);
            this.statusLabelFiles.Text = "0";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackGroundWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Work_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Work_Completed);
            // 
            // folderDialog
            // 
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.DesktopDirectory;
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 573);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(buttOpenCatalog);
            this.Controls.Add(this.tbCodes);
            this.Controls.Add(this.buttReadCode);
            this.Name = "MainForm";
            this.Text = "QR Скан";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox tbCodes;
        private System.Windows.Forms.Button buttReadCode;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelFiles;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}