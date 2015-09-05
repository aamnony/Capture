using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Capture
{
    public partial class frmMain : Form
    {
        private const int MINIMUM_SELECTION_WIDTH = 5;
        private const int MINIMUM_SELECTION_HEIGHT = 5;
        private bool mLeftMouseButtonDown = false;
        private Point mSelectionBoxStart = new Point(0, 0);

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.4;
            if (Properties.Settings.Default.IsFirstTime)
            {
                Properties.Settings.Default.IsFirstTime = false;
                string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Capture\\";
                Directory.CreateDirectory(defaultPath);
                Properties.Settings.Default.SavePath = defaultPath;
                Properties.Settings.Default.Save();
                return;
            }
            if (Properties.Settings.Default.StartMinimized)
            {
                minimizeForm();
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
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
            }
            else
            {
                closeSelectionBox();
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (mLeftMouseButtonDown && selectionBox.Width > MINIMUM_SELECTION_WIDTH && selectionBox.Height > MINIMUM_SELECTION_HEIGHT)
            {
                Cursor = Cursors.WaitCursor;
                Bitmap bmp = CreateBitmap(selectionBox.Location, selectionBox.Size);
                
                if (Properties.Settings.Default.CopyToClipboard)
                {
                    Clipboard.SetImage(bmp);
                }
                
                string timeStamp = DateTime.Now.ToString("dd-MM-yy_HHmmss.");
                ImageFormat imageFormat = StringToImageFormat(Properties.Settings.Default.ImageFormat);
                string path = Properties.Settings.Default.SavePath + timeStamp + imageFormat.ToString().ToLower();
                try
                {
                    bmp.Save(path, imageFormat);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(frmOptions.ACCESS_ERROR);
                }

                if (Properties.Settings.Default.OpenAfterSaving)
                {
                    System.Diagnostics.Process.Start(path);
                }
                if (Properties.Settings.Default.MinimizeAfterCapture)
                {
                    minimizeForm();
                }
                toolTip1.Show("Captured screen", this, e.X, e.Y, 600);
                Cursor = Cursors.Cross;
            }
            mLeftMouseButtonDown = false;
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) //esc
            {
                if (mLeftMouseButtonDown)
                {
                    mLeftMouseButtonDown = false;
                    closeSelectionBox();
                }
                else
                {
                    minimizeForm();
                }
            }
        }

        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (mLeftMouseButtonDown)
                {
                    mLeftMouseButtonDown = false;
                    closeSelectionBox();
                }
                else
                {
                    contextMenuStrip1.Show(e.X, e.Y);
                }
            }
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }

            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.ShowInTaskbar = true;
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            minMaxToolStripMenuItem.Text = this.Visible ? "Minimize" : "Maximize";
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.SavePath);
            minimizeForm();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmOptions().ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                minimizeForm();
            }
            else
            {
                maximizeForm();
            }
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog(this);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                maximizeForm();
            }
        }

        private void minimizeForm()
        {
            closeSelectionBox();
            this.WindowState = FormWindowState.Minimized;
        }

        public void maximizeForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private void closeSelectionBox()
        {
            selectionBox.Size = new Size(0, 0);
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

        private static Bitmap CreateBitmap(Point start, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(start.X, start.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            return bmp;
        }
    }
}
