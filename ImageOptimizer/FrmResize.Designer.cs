namespace ImageOptimizer
{
    partial class FrmResize
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnSelectedFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileChooser = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnDestination = new System.Windows.Forms.Button();
            this.folderDestination = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Files:";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(79, 22);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(229, 23);
            this.txtFile.TabIndex = 0;
            // 
            // btnSelectedFile
            // 
            this.btnSelectedFile.Location = new System.Drawing.Point(320, 21);
            this.btnSelectedFile.Name = "btnSelectedFile";
            this.btnSelectedFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectedFile.TabIndex = 1;
            this.btnSelectedFile.Text = "Brows";
            this.btnSelectedFile.UseVisualStyleBackColor = true;
            this.btnSelectedFile.Click += new System.EventHandler(this.btnSelectedFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFile);
            this.groupBox1.Controls.Add(this.btnSelectedFile);
            this.groupBox1.Location = new System.Drawing.Point(47, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // fileChooser
            // 
            this.fileChooser.FileName = "openFileDialog1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(184, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDestination);
            this.groupBox2.Controls.Add(this.btnDestination);
            this.groupBox2.Location = new System.Drawing.Point(47, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 68);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination:";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(79, 22);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(229, 23);
            this.txtDestination.TabIndex = 0;
            // 
            // btnDestination
            // 
            this.btnDestination.Location = new System.Drawing.Point(320, 21);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(75, 23);
            this.btnDestination.TabIndex = 1;
            this.btnDestination.Text = "Brows";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // FrmResize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 331);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmResize";
            this.Text = "FrmResize";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnSelectedFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog fileChooser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.FolderBrowserDialog folderDestination;
    }
}