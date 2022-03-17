using System;
using System.Runtime.InteropServices;

namespace VeriffDemo.Tests.UI.Tests.Utilities
{
    public class OperatingSystem
    {
        public static OS? GetOperatingSystem()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OS.Windows;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OS.Mac;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OS.Linux;
            }

            return null;
        }
    }
}
