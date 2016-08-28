using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Capture
{
    public partial class frmMain : Form
    {
        private const int MINIMUM_SELECTION_HEIGHT = 5;
        private const int MINIMUM_SELECTION_WIDTH = 5;

        private static readonly Cursor sShareCursor = new Cursor(Properties.Resources.Share.Handle);

        private bool mLeftMouseButtonDown = false;
        private Point mSelectionBoxStart = new Point(0, 0);
        private string mUpdateURL;

        public frmMain()
        {
            InitializeComponent();
        }

        public void MaximizeForm()
        {
            Show();
            WindowState = FormWindowState.Maximized;
        }

        private static Bitmap CreateBitmap(Point start, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(start.X, start.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            return bmp;
        }

        /// <summary>
        /// Saves bitmap with current timestamp.
        /// </summary>
        /// <returns>Full path of saved file.</returns>
        private static string SaveBitmap(Bitmap bmp)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HHmmss.");
            ImageFormat imageFormat = StringToImageFormat(Properties.Settings.Default.ImageFormat);
            string path = Properties.Settings.Default.SavePath + timeStamp + imageFormat.ToString().ToLower();
            try
            {
                bmp.Save(path, imageFormat);
            }
            catch (Exception)
            {
                MessageBox.Show(frmOptions.ACCESS_ERROR);
            }

            return path;
        }

        private static ImageFormat StringToImageFormat(string s)
        {
            switch (s)
            {
                case "Bmp":
                    return ImageFormat.Bmp;
                case "Emf":
                    return ImageFormat.Emf;

                case "Exif":
                    return ImageFormat.Exif;

                case "Gif":
                    return ImageFormat.Gif;

                case "Icon":
                    return ImageFormat.Icon;

                case "Jpeg":
                    return ImageFormat.Jpeg;

                case "Png":
                    return ImageFormat.Png;

                case "Tiff":
                    return ImageFormat.Tiff;

                case "Wmf":
                    return ImageFormat.Wmf;

                default:
                    return ImageFormat.Bmp;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog(this);
        }

        private void CloseSelectionBox()
        {
            selectionBox.Size = new Size(0, 0);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            minMaxToolStripMenuItem.Text = Visible ? "Hide" : "Show";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) //esc
            {
                if (mLeftMouseButtonDown)
                {
                    mLeftMouseButtonDown = false;
                    CloseSelectionBox();
                }
                else
                {
                    MinimizeForm();
                }
            }
            else if (e.KeyChar == 's' || e.KeyChar == 'S' || e.KeyChar == 'ד')
            {
                Cursor = Cursor == Cursors.Cross ? sShareCursor : Cursors.Cross;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
            }

            Opacity = 0.4;
            if (Properties.Settings.Default.IsFirstTime)
            {
                Properties.Settings.Default.IsFirstTime = false;
                string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Capture\\";
                Directory.CreateDirectory(defaultPath);
                Properties.Settings.Default.SavePath = defaultPath;
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.StartMinimized)
            {
                MinimizeForm();
            }

            workerUpdateNotification.RunWorkerAsync();
        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (mLeftMouseButtonDown)
                {
                    mLeftMouseButtonDown = false;
                    CloseSelectionBox();
                }
                else
                {
                    contextMenuStrip1.Show(e.X, e.Y);
                }
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Properties.Settings.Default.ShowSize)
                {
                    lblSelectionSize.Visible = true;
                }
                selectionBox.BorderStyle = Properties.Settings.Default.ImageBorder;
                mLeftMouseButtonDown = true;
                mSelectionBoxStart.X = e.X;
                mSelectionBoxStart.Y = e.Y;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mLeftMouseButtonDown)
            {
                selectionBox.Location = new Point(Math.Min(e.X, mSelectionBoxStart.X), Math.Min(e.Y, mSelectionBoxStart.Y));
                selectionBox.Size = new Size(Math.Abs(e.X - mSelectionBoxStart.X), Math.Abs(e.Y - mSelectionBoxStart.Y));

                if (Properties.Settings.Default.ShowSize)
                {
                    lblSelectionSize.Location = new Point(selectionBox.Location.X, selectionBox.Location.Y - lblSelectionSize.Height);
                    lblSelectionSize.Text = selectionBox.Size.ToString();
                    lblSelectionSize.Visible = true;
                }
            }
            else
            {
                lblSelectionSize.Visible = false;
                CloseSelectionBox();
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            lblSelectionSize.Visible = false;
            if (mLeftMouseButtonDown && selectionBox.Width > MINIMUM_SELECTION_WIDTH && selectionBox.Height > MINIMUM_SELECTION_HEIGHT)
            {
                var currentCurser = Cursor;
                Cursor = Cursors.WaitCursor;

                Bitmap bmp = CreateBitmap(selectionBox.Location, selectionBox.Size);
                string path = SaveBitmap(bmp);

                if (currentCurser == sShareCursor)
                {
                    new frmShare(path).ShowDialog(this);
                    MinimizeForm();
                }
                else
                {
                    if (Properties.Settings.Default.CopyToClipboard)
                    {
                        Clipboard.SetImage(bmp);
                    }
                    if (Properties.Settings.Default.OpenAfterSaving)
                    {
                        Process.Start(path);
                    }
                    if (Properties.Settings.Default.MinimizeAfterCapture)
                    {
                        MinimizeForm();
                    }
                    toolTip1.Show("Captured screen", this, e.X, e.Y, 600);
                }
                Cursor = currentCurser;
            }
            mLeftMouseButtonDown = false;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                ShowInTaskbar = true;
            }
        }

        private void MinimizeForm()
        {
            CloseSelectionBox();
            WindowState = FormWindowState.Minimized;
        }

        private void minMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visible)
            {
                MinimizeForm();
            }
            else
            {
                MaximizeForm();
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Process.Start(mUpdateURL);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MaximizeForm();
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.SavePath);
            MinimizeForm();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmOptions().ShowDialog(this);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(mUpdateURL);
        }

        private void workerUpdateNotification_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var un = new UpdateNotificationLibrary.UpdateNotification("amnonya", "Capture");
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            try
            {
                if (!un.IsLatestVersion(fvi.FileVersion))
                {
                    e.Result = un.Url;
                }
            }
            catch
            {
                // Failed to decide version.
                // No need to alert the user.
            }
        }

        private void workerUpdateNotification_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            string result = (string)e.Result;

            if (!String.IsNullOrEmpty(result))
            {
                updateToolStripMenuItem.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                mUpdateURL = result;
            }
        }

        private void selectionBox_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            e.Graphics.DrawRectangle(new Pen(Brushes.White), c.Location.X, c.Location.Y, c.Width, c.Height);
            
            e.Graphics.DrawString(c.Size.ToString(), Font, Brushes.Black, c.Location);
        }
    }
}