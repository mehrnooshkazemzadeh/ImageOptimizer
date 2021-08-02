namespace ImageOptimizer
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFiles = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnFiles = new System.Windows.Forms.Button();
            this.btnTarget = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fileChooser = new System.Windows.Forms.OpenFileDialog();
            this.targetChooser = new System.Windows.Forms.FolderBrowserDialog();
            this.txtQuality = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiles
            // 
            this.txtFiles.Location = new System.Drawing.Point(79, 22);
            this.txtFiles.Name = "txtFiles";
            this.txtFiles.Size = new System.Drawing.Size(229, 23);
            this.txtFiles.TabIndex = 0;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(79, 32);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(229, 23);
            this.txtTarget.TabIndex = 0;
            // 
            // btnFiles
            // 
            this.btnFiles.Location = new System.Drawing.Point(320, 21);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(75, 23);
            this.btnFiles.TabIndex = 1;
            this.btnFiles.Text = "Brows";
            this.btnFiles.UseVisualStyleBackColor = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnTarget
            // 
            this.btnTarget.Location = new System.Drawing.Point(314, 32);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(75, 23);
            this.btnTarget.TabIndex = 1;
            this.btnTarget.Text = "Brows";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(70, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(241, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFiles);
            this.groupBox1.Controls.Add(this.btnFiles);
            this.groupBox1.Location = new System.Drawing.Point(12, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTarget);
            this.groupBox2.Controls.Add(this.btnTarget);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 80);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Target:";
            // 
            // fileChooser
            // 
            this.fileChooser.AddExtension = false;
            this.fileChooser.DefaultExt = "zip";
            this.fileChooser.Multiselect = true;
            // 
            // txtQuality
            // 
            this.txtQuality.Location = new System.Drawing.Point(135, 176);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(100, 23);
            this.txtQuality.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quality:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = ">0 and <100";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 300);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuality);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmMain";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiles;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog fileChooser;
        private System.Windows.Forms.FolderBrowserDialog targetChooser;
        private System.Windows.Forms.TextBox txtQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

