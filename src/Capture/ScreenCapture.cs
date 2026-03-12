using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AutoClips.Capture;

public class ScreenCapture
{
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

    public Bitmap CaptureWindow(Process process)
    {
        var handle = process.MainWindowHandle;

        if (handle == IntPtr.Zero)
            return null;

        GetWindowRect(handle, out RECT rect);

        int width = rect.Right - rect.Left;
        int height = rect.Bottom - rect.Top;

        Bitmap bmp = new Bitmap(width, height);

        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, new Size(width, height));
        }

        return bmp;
    }

    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
