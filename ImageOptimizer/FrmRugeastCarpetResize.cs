using Partikan.Framework.Core.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImageOptimizer
{
    public partial class FrmRugeastCarpetResize : Form
    {
        public FrmRugeastCarpetResize()
        {
            InitializeComponent();
        }
        private void btnFiles_Click(object sender, EventArgs e)
        {
            if (fileUploader.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fileUploader.FileName;
            }
        }
        public string PatheBase { get => "D:/BidabadiPublish/wwwroot"; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var sheet = FileManager.GetSheet(fileUploader.FileName, 0);
            var imageEditor = new ImageEditor();
            foreach (var item in sheet.Columns[0].Rows)
            {
                lblResult.Text = item.DisplayText.ToString();
                var fileName = FileManager.GetFileName(item.DisplayText);
                var copyFileName = fileName.Split(".")[0] + " - Copy." + fileName.Split(".")[1];
                var path = PatheBase + item.DisplayText.ToString();
                if (File.Exists(PatheBase + item.DisplayText.Replace(fileName, copyFileName)))
                    path = path.Replace(fileName, copyFileName);
                else
                    copyFileName = fileName;

                imageEditor.Resize(new Bitmap(Image.FromFile(path)), 220, path.Replace(copyFileName,"")+ $"{fileName.Split(".")[0]}-1.jpg");
                lblResult.Text = null;
            }
            MessageBox.Show("Done!");
        }
    }
}
