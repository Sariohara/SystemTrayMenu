﻿using System;
using System.Runtime.InteropServices;

namespace SystemTrayMenu.NativeMethods
{
    public static partial class NativeMethods
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
