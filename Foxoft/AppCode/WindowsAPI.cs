using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Foxoft.AppCode
{

    internal class WindowsAPI
    {
        private const uint WM_CLOSE = 0x0010;
        private const int GWL_STYLE = -16;
        private const uint WS_CHILD = 0x56CF0000;
        private const uint WM_GETTAG = 0x0400 + 1; // Custom message ID
        private const int PROCESS_VM_READ = 0x0010;
        private const int PROCESS_QUERY_INFORMATION = 0x0400;

        public static List<WindowInfo> GetMDIChildWindowsOfProcess(Process process)
        {
            List<WindowInfo> childWindows = new List<WindowInfo>();
            IntPtr mainWindowHandle = process.MainWindowHandle;

            NativeMethods.EnumChildWindows(mainWindowHandle, (hWnd, lParam) =>
            {
                uint style = NativeMethods.GetWindowLong(hWnd, GWL_STYLE);
                if ((style & WS_CHILD) == WS_CHILD && NativeMethods.IsWindowVisible(hWnd))
                {
                    int length = NativeMethods.GetWindowTextLength(hWnd);
                    StringBuilder titleBuilder = new StringBuilder(length + 1);
                    NativeMethods.GetWindowText(hWnd, titleBuilder, titleBuilder.Capacity);

                    IntPtr tagPointer = NativeMethods.SendMessage(hWnd, WM_GETTAG, IntPtr.Zero, IntPtr.Zero);
                    string tag = ReadStringFromPointer(process.Handle, tagPointer);
                    Marshal.FreeHGlobal(tagPointer); // Free the allocated memory in the target application

                    childWindows.Add(new WindowInfo
                    {
                        Handle = hWnd,
                        Title = titleBuilder.ToString(),
                        Tag = tag
                    });
                }
                return true; // Continue enumeration
            }, IntPtr.Zero);

            return childWindows;
        }

        private static string ReadStringFromPointer(IntPtr processHandle, IntPtr pointer)
        {
            byte[] buffer = new byte[256]; // Adjust the buffer size as needed
            IntPtr bytesRead;
            if (NativeMethods.ReadProcessMemory(processHandle, pointer, buffer, buffer.Length, out bytesRead))
            {
                int stringLength = Array.IndexOf(buffer, (byte)0); // Find the first null terminator
                if (stringLength < 0) stringLength = buffer.Length; // No null terminator found, use entire buffer
                return Encoding.ASCII.GetString(buffer, 0, stringLength);
            }
            return null;
        }

        public static void CloseWindow(IntPtr hWnd)
        {
            NativeMethods.PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }
    }

    public class NativeMethods
    {
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hWnd, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);
    }

    public class WindowInfo
    {
        public IntPtr Handle { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
    }


    

}
