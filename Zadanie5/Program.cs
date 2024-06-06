using System;
using System.Runtime.InteropServices;

namespace Zadanie5
{
    class Program
    {
        // Importowanie funkcji z user32.dll do tworzenia i obsługi okna
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, uint dwStyle,
            int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage(ref MSG lpmsg);

        [DllImport("user32.dll")]
        public static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        public static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern ushort RegisterClass(ref WNDCLASS lpWndClass);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool EndPaint(IntPtr hWnd, [In] ref PAINTSTRUCT lpPaint);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void PostQuitMessage(int nExitCode);

        // Importowanie funkcji z gdi32.dll do rysowania
        [DllImport("gdi32.dll")]
        public static extern IntPtr MoveToEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);

        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);

        // Stałe
        private const int WS_OVERLAPPEDWINDOW = 0xcf0000;
        private const int WS_VISIBLE = 0x10000000;
        private const int CW_USEDEFAULT = unchecked((int)0x80000000);
        private const int WM_DESTROY = 0x0002;
        private const int WM_PAINT = 0x000F;
        private const int SW_SHOWNORMAL = 1;

        // Struktury
        [StructLayout(LayoutKind.Sequential)]
        public struct WNDCLASS
        {
            public uint style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point pt;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;
            public System.Drawing.Rectangle rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            public byte[] rgbReserved;
        }

        // Procedura okna
        private static IntPtr WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM_PAINT:
                    {
                        PAINTSTRUCT ps;
                        IntPtr hdc = BeginPaint(hWnd, out ps);

                        // Rysowanie cosinusa
                        DrawCosine(hdc);

                        EndPaint(hWnd, ref ps);
                        return IntPtr.Zero;
                    }
                case WM_DESTROY:
                    PostQuitMessage(0);
                    return IntPtr.Zero;
            }
            return DefWindowProc(hWnd, msg, wParam, lParam);
        }

        // Funkcja rysująca wykres cosinusa
        private static void DrawCosine(IntPtr hdc)
        {
            // Ustawienia wykresu
            int width = 800;
            int height = 600;
            int centerX = width / 2;
            int centerY = height / 2;
            int amplitude = 100;

            // Ustawienie punktu początkowego
            MoveToEx(hdc, 0, centerY, IntPtr.Zero);

            for (int x = 0; x < width; x++)
            {
                double radians = (x - centerX) * 2 * Math.PI / width;
                int y = centerY - (int)(amplitude * Math.Cos(radians));
                LineTo(hdc, x, y);
            }
        }

        static void Main(string[] args)
        {
            // Rejestracja klasy okna
            WNDCLASS wc = new WNDCLASS();
            wc.lpszClassName = "MyWindowClass";
            wc.lpfnWndProc = Marshal.GetFunctionPointerForDelegate((WndProc)WindowProc);

            RegisterClass(ref wc);

            // Tworzenie okna
            IntPtr hWnd = CreateWindowEx(0, wc.lpszClassName, "Cosine Function", WS_OVERLAPPEDWINDOW | WS_VISIBLE,
                CW_USEDEFAULT, CW_USEDEFAULT, 800, 600, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            ShowWindow(hWnd, SW_SHOWNORMAL);

            // Pętla komunikatów
            MSG msg;
            while (GetMessage(out msg, IntPtr.Zero, 0, 0))
            {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
        }

        // Delegat procedury okna
        private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
