using System;
using System.Runtime.InteropServices;

namespace Oracle.Utilities
{
    public static class Kernel32Utility
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadLibrary(string lpFileName);
    }
}