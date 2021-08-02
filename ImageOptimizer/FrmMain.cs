using Partikan.Framework.Core.Tools;
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

namespace ImageOptimizer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                txtFiles.Text = fileChooser.FileName;
            }
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            if (targetChooser.ShowDialog() == DialogResult.OK)
                txtTarget.Text = targetChooser.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (fileChooser.FileNames == null)
            {
                MessageBox.Show("Choose Files");
                return;
            }
            if (targetChooser.SelectedPath == null)
            {
                MessageBox.Show("Choose Target");
                return;
            }
            var imageEditor = new ImageEditor();
            foreach (var item in fileChooser.FileNames)
            {
                string fileName = GetFileName(item);
                if (item.EndsWith(".zip") | item.EndsWith(".rar") | item.EndsWith(".7z"))
                {
                    var files = imageEditor.UnZip(item, Path.Combine(targetChooser.SelectedPath, $"{fileName}-unzip"));
                    foreach (var file in files)
                    {

                        imageEditor.SaveOptimizeImage(file, Path.Combine(targetChooser.SelectedPath, GetFileNameWithExtension(file)), int.Parse(txtQuality.Text));
                    }
                }
                if (item.EndsWith(".jpg") | item.EndsWith(".jpeg"))
                {
                    imageEditor.SaveOptimizeImage(item, Path.Combine(targetChooser.SelectedPath, GetFileNameWithExtension(item)), int.Parse(txtQuality.Text));
                }
            }
            MessageBox.Show("Done!");
        }

        private string GetFileName(string item)
        {
            var itemSections = item.Split("\\");
            var fileNameWithextension = itemSections[itemSections.Length - 1];
            var fileName = fileNameWithextension.Substring(0, fileNameWithextension.IndexOf('.'));
            return fileName;
        }
        private string GetFileNameWithExtension(string item)
        {
            var itemSections = item.Split("\\");
            var fileNameWithextension = itemSections[itemSections.Length - 1];
            return fileNameWithextension;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
