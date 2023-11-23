using LinqTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class Form1 : Form
    {
        private delegate bool EnumDesktopProc(string lpszDesktop, IntPtr lParam);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = GetLogonSid.getLogonSid();
        }
    }

    public class GetLogonSid
    {
        private const int UOI_USER_SID = 4;

        [DllImport("user32.dll")]
        static extern bool GetUserObjectInformation(IntPtr hObj, int nIndex, [MarshalAs(UnmanagedType.LPArray)] byte[] pvInfo, int nLength, out uint lpnLengthNeeded);

        [DllImport("user32.dll")]
        private static extern IntPtr GetThreadDesktop(int dwThreadId);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool ConvertSidToStringSid(
            [MarshalAs(UnmanagedType.LPArray)] byte[] pSID,
            out IntPtr ptrSid);

        public static string getLogonSid()
        {
            string sidString = "";
            IntPtr hdesk = GetThreadDesktop(GetCurrentThreadId());
            byte[] buf = new byte[100];
            uint lengthNeeded;
            GetUserObjectInformation(hdesk, UOI_USER_SID, buf, 100, out lengthNeeded);
            IntPtr ptrSid;
            if (!ConvertSidToStringSid(buf, out ptrSid))
                throw new Win32Exception();
            try
            {
                sidString = Marshal.PtrToStringAuto(ptrSid);
            }
            catch
            {
            }
            return sidString;
        }

    }
}
