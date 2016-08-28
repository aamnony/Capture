namespace Capture
{
    partial class frmOptions
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOpenFolderDialog = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblImageFormat = new System.Windows.Forms.Label();
            this.cmbImageFormats = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkRunAtStartup = new System.Windows.Forms.CheckBox();
            this.chkOpenAfterSaving = new System.Windows.Forms.CheckBox();
            this.chkMinimizeAfterCapture = new System.Windows.Forms.CheckBox();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.cmbImageBorder = new System.Windows.Forms.ComboBox();
            this.lblFrame = new System.Windows.Forms.Label();
            this.grpBehaviour = new System.Windows.Forms.GroupBox();
            this.chkCopyToClipboard = new System.Windows.Forms.CheckBox();
            this.chkShowSize = new System.Windows.Forms.CheckBox();
            this.grpData.SuspendLayout();
            this.grpBehaviour.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(9, 25);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(90, 16);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "Save to folder:";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(105, 22);
            this.txtPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(173, 22);
            this.txtPath.TabIndex = 2;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnOpenFolderDialog
            // 
            this.btnOpenFolderDialog.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOpenFolderDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOpenFolderDialog.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFolderDialog.Location = new System.Drawing.Point(283, 20);
            this.btnOpenFolderDialog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOpenFolderDialog.Name = "btnOpenFolderDialog";
            this.btnOpenFolderDialog.Size = new System.Drawing.Size(28, 27);
            this.btnOpenFolderDialog.TabIndex = 3;
            this.btnOpenFolderDialog.Text = "...";
            this.btnOpenFolderDialog.UseVisualStyleBackColor = true;
            this.btnOpenFolderDialog.Click += new System.EventHandler(this.btnOpenFolderDialog_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(434, 173);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblImageFormat
            // 
            this.lblImageFormat.AutoSize = true;
            this.lblImageFormat.Location = new System.Drawing.Point(12, 58);
            this.lblImageFormat.Name = "lblImageFormat";
            this.lblImageFormat.Size = new System.Drawing.Size(87, 16);
            this.lblImageFormat.TabIndex = 10;
            this.lblImageFormat.Text = "Image format:";
            this.lblImageFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbImageFormats
            // 
            this.cmbImageFormats.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbImageFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageFormats.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbImageFormats.FormattingEnabled = true;
            this.cmbImageFormats.Items.AddRange(new object[] {
            "Bmp",
            "Emf",
            "Exif",
            "Gif",
            "Icon",
            "Jpeg",
            "Png",
            "Tiff",
            "Wmf"});
            this.cmbImageFormats.Location = new System.Drawing.Point(105, 55);
            this.cmbImageFormats.Name = "cmbImageFormats";
            this.cmbImageFormats.Size = new System.Drawing.Size(173, 24);
            this.cmbImageFormats.Sorted = true;
            this.cmbImageFormats.TabIndex = 11;
            // 
            // btnOk
            // 
            this.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(352, 173);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(78, 29);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStartMinimized.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkStartMinimized.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStartMinimized.Location = new System.Drawing.Point(9, 134);
            this.chkStartMinimized.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(124, 21);
            this.chkStartMinimized.TabIndex = 15;
            this.chkStartMinimized.Text = "Start minimized";
            this.chkStartMinimized.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            // 
            // chkRunAtStartup
            // 
            this.chkRunAtStartup.AutoSize = true;
            this.chkRunAtStartup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRunAtStartup.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkRunAtStartup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRunAtStartup.Location = new System.Drawing.Point(9, 107);
            this.chkRunAtStartup.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkRunAtStartup.Name = "chkRunAtStartup";
            this.chkRunAtStartup.Size = new System.Drawing.Size(115, 21);
            this.chkRunAtStartup.TabIndex = 16;
            this.chkRunAtStartup.Text = "Run at startup";
            this.chkRunAtStartup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRunAtStartup.UseVisualStyleBackColor = true;
            this.chkRunAtStartup.CheckedChanged += new System.EventHandler(this.chkRunAtStartup_CheckedChanged);
            // 
            // chkOpenAfterSaving
            // 
            this.chkOpenAfterSaving.AutoSize = true;
            this.chkOpenAfterSaving.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOpenAfterSaving.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkOpenAfterSaving.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOpenAfterSaving.Location = new System.Drawing.Point(9, 53);
            this.chkOpenAfterSaving.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkOpenAfterSaving.Name = "chkOpenAfterSaving";
            this.chkOpenAfterSaving.Size = new System.Drawing.Size(172, 21);
            this.chkOpenAfterSaving.TabIndex = 4;
            this.chkOpenAfterSaving.Text = "Open image after saving";
            this.chkOpenAfterSaving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkOpenAfterSaving.UseVisualStyleBackColor = true;
            // 
            // chkMinimizeAfterCapture
            // 
            this.chkMinimizeAfterCapture.AutoSize = true;
            this.chkMinimizeAfterCapture.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMinimizeAfterCapture.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkMinimizeAfterCapture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMinimizeAfterCapture.Location = new System.Drawing.Point(9, 26);
            this.chkMinimizeAfterCapture.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkMinimizeAfterCapture.Name = "chkMinimizeAfterCapture";
            this.chkMinimizeAfterCapture.Size = new System.Drawing.Size(161, 21);
            this.chkMinimizeAfterCapture.TabIndex = 13;
            this.chkMinimizeAfterCapture.Text = "Minimize after capture";
            this.chkMinimizeAfterCapture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkMinimizeAfterCapture.UseVisualStyleBackColor = true;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.cmbImageBorder);
            this.grpData.Controls.Add(this.lblFrame);
            this.grpData.Controls.Add(this.lblPath);
            this.grpData.Controls.Add(this.txtPath);
            this.grpData.Controls.Add(this.cmbImageFormats);
            this.grpData.Controls.Add(this.lblImageFormat);
            this.grpData.Controls.Add(this.btnOpenFolderDialog);
            this.grpData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpData.Location = new System.Drawing.Point(226, 8);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(323, 155);
            this.grpData.TabIndex = 17;
            this.grpData.TabStop = false;
            this.grpData.Text = "Data";
            // 
            // cmbImageBorder
            // 
            this.cmbImageBorder.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbImageBorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageBorder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbImageBorder.FormattingEnabled = true;
            this.cmbImageBorder.Location = new System.Drawing.Point(105, 88);
            this.cmbImageBorder.Name = "cmbImageBorder";
            this.cmbImageBorder.Size = new System.Drawing.Size(173, 24);
            this.cmbImageBorder.Sorted = true;
            this.cmbImageBorder.TabIndex = 13;
            // 
            // lblFrame
            // 
            this.lblFrame.AutoSize = true;
            this.lblFrame.Location = new System.Drawing.Point(12, 91);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(83, 16);
            this.lblFrame.TabIndex = 12;
            this.lblFrame.Text = "Image frame:";
            this.lblFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBehaviour
            // 
            this.grpBehaviour.Controls.Add(this.chkShowSize);
            this.grpBehaviour.Controls.Add(this.chkCopyToClipboard);
            this.grpBehaviour.Controls.Add(this.chkMinimizeAfterCapture);
            this.grpBehaviour.Controls.Add(this.chkOpenAfterSaving);
            this.grpBehaviour.Controls.Add(this.chkRunAtStartup);
            this.grpBehaviour.Controls.Add(this.chkStartMinimized);
            this.grpBehaviour.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBehaviour.Location = new System.Drawing.Point(8, 8);
            this.grpBehaviour.Name = "grpBehaviour";
            this.grpBehaviour.Size = new System.Drawing.Size(212, 194);
            this.grpBehaviour.TabIndex = 18;
            this.grpBehaviour.TabStop = false;
            this.grpBehaviour.Text = "Behaviour";
            // 
            // chkCopyToClipboard
            // 
            this.chkCopyToClipboard.AutoSize = true;
            this.chkCopyToClipboard.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCopyToClipboard.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkCopyToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkCopyToClipboard.Location = new System.Drawing.Point(9, 80);
            this.chkCopyToClipboard.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkCopyToClipboard.Name = "chkCopyToClipboard";
            this.chkCopyToClipboard.Size = new System.Drawing.Size(180, 21);
            this.chkCopyToClipboard.TabIndex = 17;
            this.chkCopyToClipboard.Text = "Copy images to clipboard";
            this.chkCopyToClipboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCopyToClipboard.UseVisualStyleBackColor = true;
            // 
            // chkShowSize
            // 
            this.chkShowSize.AutoSize = true;
            this.chkShowSize.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkShowSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShowSize.Location = new System.Drawing.Point(9, 161);
            this.chkShowSize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkShowSize.Name = "chkShowSize";
            this.chkShowSize.Size = new System.Drawing.Size(176, 21);
            this.chkShowSize.TabIndex = 18;
            this.chkShowSize.Text = "Show size measurments";
            this.chkShowSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowSize.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(558, 210);
            this.ControlBox = false;
            this.Controls.Add(this.grpBehaviour);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOptions";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Form_Load);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpBehaviour.ResumeLayout(false);
            this.grpBehaviour.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnOpenFolderDialog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkOpenAfterSaving;
        private System.Windows.Forms.Label lblImageFormat;
        private System.Windows.Forms.ComboBox cmbImageFormats;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkMinimizeAfterCapture;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.CheckBox chkRunAtStartup;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.GroupBox grpBehaviour;
        private System.Windows.Forms.CheckBox chkCopyToClipboard;
        private System.Windows.Forms.ComboBox cmbImageBorder;
        private System.Windows.Forms.Label lblFrame;
        private System.Windows.Forms.CheckBox chkShowSize;
    }
}