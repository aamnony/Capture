using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capture
{
    public partial class frmShare : Form
    {
        private string mPath;
        private List<string> mShareApps;

        public frmShare(string path)
        {
            InitializeComponent();
            mPath = path;
        }

        public frmShare()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            try
            {
                if (listSendTo.SelectedIndex == 0)
                {
                    MAPI mapi = new MAPI();
                    mapi.AddAttachment(mPath);
                    mapi.SendMailPopup(Path.GetFileName(mPath), String.Empty);
                }
                else
                {
                    System.Diagnostics.Process.Start(mShareApps[listSendTo.SelectedIndex], mPath);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(listSendTo.SelectedItem.ToString() + " is not currently supported by Capture." + Environment.NewLine + "Sorry about that...");
            }
        }

        private void frmShare_Load(object sender, EventArgs e)
        {
            mShareApps = new List<string>();
            mShareApps.Add("Email");
            mShareApps.AddRange(Directory.GetFiles(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\SendTo"), "*.lnk"));

            listSendTo.Items.AddRange(mShareApps.Select(Path.GetFileNameWithoutExtension).ToArray());
        }

        private void listSendTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnShare.Enabled = listSendTo.SelectedIndex >= 0;
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiFileDesc
    {
        public int reserved;
        public int flags;
        public int position;
        public string path;
        public string name;
        public IntPtr type;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiMessage
    {
        public int reserved;
        public string subject;
        public string noteText;
        public string messageType;
        public string dateReceived;
        public string conversationID;
        public int flags;
        public IntPtr originator;
        public int recipCount;
        public IntPtr recips;
        public int fileCount;
        public IntPtr files;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class MapiRecipDesc
    {
        public int reserved;
        public int recipClass;
        public string name;
        public string address;
        public int eIDSize;
        public IntPtr entryID;
    }

    internal class MAPI
    {
        private const int MAPI_DIALOG = 0x00000008;

        private const int MAPI_LOGON_UI = 0x00000001;

        private const int maxAttachments = 20;

        private readonly string[] errors = new string[] {
        "OK [0]", "User abort [1]", "General MAPI failure [2]",
                "MAPI login failure [3]", "Disk full [4]",
                "Insufficient memory [5]", "Access denied [6]",
                "-unknown- [7]", "Too many sessions [8]",
                "Too many files were specified [9]",
                "Too many recipients were specified [10]",
                "A specified attachment was not found [11]",
        "Attachment open failure [12]",
                "Attachment write failure [13]", "Unknown recipient [14]",
                "Bad recipient type [15]", "No messages [16]",
                "Invalid message [17]", "Text too large [18]",
                "Invalid session [19]", "Type not supported [20]",
                "A recipient was specified ambiguously [21]",
                "Message in use [22]", "Network failure [23]",
        "Invalid edit fields [24]", "Invalid recipients [25]",
                "Not supported [26]"
        };

        private List<string> m_attachments = new List<string>();

        private int m_lastError = 0;

        private List<MapiRecipDesc> m_recipients = new
                List<MapiRecipDesc>();

        private enum HowTo
        { MAPI_ORIG = 0, MAPI_TO, MAPI_CC, MAPI_BCC };

        public void AddAttachment(string strAttachmentFileName)
        {
            m_attachments.Add(strAttachmentFileName);
        }

        public bool AddRecipientBCC(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        public bool AddRecipientCC(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        public bool AddRecipientTo(string email)
        {
            return AddRecipient(email, HowTo.MAPI_TO);
        }

        public string GetLastError()
        {
            if (m_lastError <= 26)
                return errors[m_lastError];
            return "MAPI error [" + m_lastError.ToString() + "]";
        }

        public int SendMailDirect(string strSubject, string strBody)
        {
            return SendMail(strSubject, strBody, MAPI_LOGON_UI);
        }

        public int SendMailPopup(string strSubject, string strBody)
        {
            return SendMail(strSubject, strBody, MAPI_LOGON_UI | MAPI_DIALOG);
        }

        [DllImport("MAPI32.DLL")]
        private static extern int MAPISendMail(IntPtr sess, IntPtr hwnd,
            MapiMessage message, int flg, int rsv);

        private bool AddRecipient(string email, HowTo howTo)
        {
            MapiRecipDesc recipient = new MapiRecipDesc();

            recipient.recipClass = (int)howTo;
            recipient.name = email;
            m_recipients.Add(recipient);

            return true;
        }

        private void Cleanup(ref MapiMessage msg)
        {
            int size = Marshal.SizeOf(typeof(MapiRecipDesc));
            int ptr = 0;

            if (msg.recips != IntPtr.Zero)
            {
                ptr = (int)msg.recips;
                for (int i = 0; i < msg.recipCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr)ptr,
                        typeof(MapiRecipDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(msg.recips);
            }

            if (msg.files != IntPtr.Zero)
            {
                size = Marshal.SizeOf(typeof(MapiFileDesc));

                ptr = (int)msg.files;
                for (int i = 0; i < msg.fileCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr)ptr,
                        typeof(MapiFileDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(msg.files);
            }

            m_recipients.Clear();
            m_attachments.Clear();
            m_lastError = 0;
        }

        private IntPtr GetAttachments(out int fileCount)
        {
            fileCount = 0;
            if (m_attachments == null)
                return IntPtr.Zero;

            if ((m_attachments.Count <= 0) || (m_attachments.Count >
                maxAttachments))
                return IntPtr.Zero;

            int size = Marshal.SizeOf(typeof(MapiFileDesc));
            IntPtr intPtr = Marshal.AllocHGlobal(m_attachments.Count * size);

            MapiFileDesc mapiFileDesc = new MapiFileDesc();
            mapiFileDesc.position = -1;
            int ptr = (int)intPtr;

            foreach (string strAttachment in m_attachments)
            {
                mapiFileDesc.name = Path.GetFileName(strAttachment);
                mapiFileDesc.path = strAttachment;
                Marshal.StructureToPtr(mapiFileDesc, (IntPtr)ptr, false);
                ptr += size;
            }

            fileCount = m_attachments.Count;
            return intPtr;
        }

        private IntPtr GetRecipients(out int recipCount)
        {
            recipCount = 0;
            if (m_recipients.Count == 0)
                return IntPtr.Zero;

            int size = Marshal.SizeOf(typeof(MapiRecipDesc));
            IntPtr intPtr = Marshal.AllocHGlobal(m_recipients.Count * size);

            int ptr = (int)intPtr;
            foreach (MapiRecipDesc mapiDesc in m_recipients)
            {
                Marshal.StructureToPtr(mapiDesc, (IntPtr)ptr, false);
                ptr += size;
            }

            recipCount = m_recipients.Count;
            return intPtr;
        }

        private int SendMail(string strSubject, string strBody, int how)
        {
            MapiMessage msg = new MapiMessage();
            msg.subject = strSubject;
            msg.noteText = strBody;

            msg.recips = GetRecipients(out msg.recipCount);
            msg.files = GetAttachments(out msg.fileCount);

            m_lastError = MAPISendMail(new IntPtr(0), new IntPtr(0), msg, how,
                0);
            if (m_lastError > 1)
                MessageBox.Show("MAPISendMail failed! " + GetLastError(),
                    "MAPISendMail");

            Cleanup(ref msg);
            return m_lastError;
        }
    }
}