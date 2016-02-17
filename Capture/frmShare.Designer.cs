namespace Capture
{
    partial class frmShare
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
            this.listSendTo = new System.Windows.Forms.ListBox();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listSendTo
            // 
            this.listSendTo.FormattingEnabled = true;
            this.listSendTo.Location = new System.Drawing.Point(12, 12);
            this.listSendTo.Name = "listSendTo";
            this.listSendTo.Size = new System.Drawing.Size(183, 186);
            this.listSendTo.TabIndex = 1;
            this.listSendTo.SelectedIndexChanged += new System.EventHandler(this.listSendTo_SelectedIndexChanged);
            // 
            // btnShare
            // 
            this.btnShare.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShare.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnShare.Enabled = false;
            this.btnShare.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShare.Location = new System.Drawing.Point(11, 204);
            this.btnShare.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(90, 29);
            this.btnShare.TabIndex = 6;
            this.btnShare.Text = "Share";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(105, 204);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmShare
            // 
            this.AcceptButton = this.btnShare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(207, 242);
            this.ControlBox = false;
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listSendTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShare";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Share";
            this.Load += new System.EventHandler(this.frmShare_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listSendTo;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnCancel;
    }
}