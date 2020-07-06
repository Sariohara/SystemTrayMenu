﻿// <copyright file="Scaling.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Drawing;
    internal static class Scaling
    {
        internal static float Factor = 1;

        private enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }

        internal static void Initialize()
        {
            CalculateScalingFactor();
            SetProcessDPIAwareWhenNecessary();
            static void SetProcessDPIAwareWhenNecessary()
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    DllImports.NativeMethods.User32SetProcessDPIAware();
                }
            }
        }

        private static void CalculateScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = DllImports.NativeMethods.Gdi32GetDeviceCaps(
                desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = DllImports.NativeMethods.Gdi32GetDeviceCaps(
                desktop, (int)DeviceCap.DESKTOPVERTRES);
            Factor = PhysicalScreenHeight / (float)LogicalScreenHeight;
        }
    }
}
