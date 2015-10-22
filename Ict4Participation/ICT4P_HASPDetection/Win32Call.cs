using System;
using System.Runtime.InteropServices;

namespace ICT4P_HASPDetection
{
    class Win32Call
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
