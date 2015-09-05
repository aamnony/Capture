using System;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Security.AccessControl;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Capture
{
    public partial class frmOptions : Form
    {
        public const string ACCESS_ERROR = "This app does not have permission to access the folder!\nTry starting this app again as administrator, or provide a different folder.";
        private const string INVALID_PATH_ERROR = "Folder path is invalid!\nPlease provide a valid folder";
        private bool mStartMinimized;

        public frmOptions()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            txtPath.Text = Properties.Settings.Default.SavePath;

            cmbImageFormats.SelectedItem = Properties.Settings.Default.ImageFormat;
            if (cmbImageFormats.SelectedItem == null)
            {
                cmbImageFormats.SelectedIndex = 0;
            }

            FillImageBorderComboBox();
            cmbImageBorder.SelectedItem = Properties.Settings.Default.ImageBorder;
            if (cmbImageBorder.SelectedItem == null)
            {
                cmbImageBorder.SelectedIndex = 2;
            }

            chkOpenAfterSaving.Checked = Properties.Settings.Default.OpenAfterSaving;
            chkMinimizeAfterCapture.Checked = Properties.Settings.Default.MinimizeAfterCapture;
            mStartMinimized = chkStartMinimized.Checked = Properties.Settings.Default.StartMinimized;
            chkRunAtStartup.Checked = Properties.Settings.Default.RunAtStartup;
            chkCopyToClipboard.Checked = Properties.Settings.Default.CopyToClipboard;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text))
            {
                if (CanAccessFolder(txtPath.Text))
                {
                    Properties.Settings.Default.SavePath = CleanPath(txtPath.Text);
                    Properties.Settings.Default.ImageFormat = cmbImageFormats.SelectedItem.ToString();
                    Properties.Settings.Default.ImageBorder = (BorderStyle)cmbImageBorder.SelectedItem;
                    Properties.Settings.Default.OpenAfterSaving = chkOpenAfterSaving.Checked;
                    Properties.Settings.Default.MinimizeAfterCapture = chkMinimizeAfterCapture.Checked;
                    Properties.Settings.Default.StartMinimized = chkStartMinimized.Checked;
                    Properties.Settings.Default.RunAtStartup = chkRunAtStartup.Checked;
                    Properties.Settings.Default.CopyToClipboard = chkCopyToClipboard.Checked;
                    Properties.Settings.Default.Save();

                    AddRemoveStartupLink(chkRunAtStartup.Checked);
                    this.Close();
                }
                else  MessageBox.Show(ACCESS_ERROR, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show(INVALID_PATH_ERROR, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnOpenFolderDialog_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(this);
            txtPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtPath.Text;
        }

        private void chkRunAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRunAtStartup.Checked)
            {
                mStartMinimized = chkStartMinimized.Checked;
                chkStartMinimized.Checked = true;
                chkStartMinimized.Enabled = false;
            }
            else
            {
                chkStartMinimized.Enabled = true;
                chkStartMinimized.Checked = mStartMinimized;
            }
        }

        private void FillImageBorderComboBox()
        {
            cmbImageBorder.Items.Add(BorderStyle.None);
            cmbImageBorder.Items.Add(BorderStyle.FixedSingle);
            cmbImageBorder.Items.Add(BorderStyle.Fixed3D);
        }


        private static string CleanPath(string path)
        {
            char[] trim = { '\\','/' };
            return path.TrimEnd(trim) + '\\';
        }

        // Add = true, Remove = false
        private static void AddRemoveStartupLink(bool add)
        {
            if (add)
            {
                // Create the link file
                Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
                dynamic shell = Activator.CreateInstance(t);
                try
                {
                    var link = shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Capture.lnk");
                    try
                    {
                        link.TargetPath = Assembly.GetExecutingAssembly().Location;
                        link.IconLocation = link.TargetPath + " ,0";
                        link.Save();
                    }
                    finally { Marshal.FinalReleaseComObject(link); }
                }
                finally { Marshal.FinalReleaseComObject(shell); }
            }
            else
            {
                try { File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Capture.lnk"); }
                catch { } //nada
            }

        }

        private static bool CanAccessFolder(string path)
        {
            string fileName = path + "access_test.capture";
            try
            {
                File.Create(fileName).Dispose();
            }
            catch (UnauthorizedAccessException uae)
            {
                return false;
            }
            File.Delete(fileName);
            return true;
        }
    }
}
