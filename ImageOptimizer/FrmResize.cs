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
    public partial class FrmResize : Form
    {
        public FrmResize()
        {
            InitializeComponent();
        }

        private void btnSelectedFile_Click(object sender, EventArgs e)
        {
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = fileChooser.FileName;
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            if (folderDestination.ShowDialog() == DialogResult.OK)
            {
                txtDestination.Text = folderDestination.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var imageEditor = new ImageEditor();
            imageEditor.Resize(new Bitmap(Image.FromFile(fileChooser.FileName)), 220, Path.Combine( folderDestination.SelectedPath,"test.jpg"));
        }
    }
}
