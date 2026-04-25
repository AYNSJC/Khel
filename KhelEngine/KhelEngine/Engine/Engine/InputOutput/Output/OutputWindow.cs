using System;
using System.Runtime.InteropServices;

public class OutputWindow {
	// Handle to the actual native window (HWND in Win32)
	private IntPtr _hwnd;

	private bool _running = true;
	private const int WS_OVERLAPPEDWINDOW = 0x00CF0000;
	private const int CW_USEDEFAULT = unchecked((int)0x80000000);
	private const uint WM_CLOSE = 0x0010;
	private const uint WM_DESTROY = 0x0002;
	private const uint WM_QUIT = 0x0012;
	private static WndProc _wndProcDelegate = WindowProc;
	private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	public bool IsRunning => _running;

	public OutputWindow(int width, int height, string title) {
		RegisterWindowClass();

		_hwnd = CreateWindowEx(0, "OutputWindowClass", title, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, width, height, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

		ShowWindow(_hwnd, 1);
		UpdateWindow(_hwnd);
	}

	public void PollEvents() {
		MSG msg;

		while(PeekMessage(out msg, IntPtr.Zero, 0, 0, 1)) {
			if(msg.message == WM_QUIT) {
				_running = false;
				return;
			}

			TranslateMessage(ref msg);
			DispatchMessage(ref msg);
		}
	}

	private static IntPtr WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam) {
		switch(msg) {
			case WM_CLOSE:
				DestroyWindow(hWnd);
				return IntPtr.Zero;

			case WM_DESTROY:
				PostQuitMessage(0);
				return IntPtr.Zero;
		}

		return DefWindowProc(hWnd, msg, wParam, lParam);
	}

	private void RegisterWindowClass() {
		WNDCLASS wc = new WNDCLASS();
		wc.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProcDelegate);

		wc.lpszClassName = "OutputWindowClass";

		RegisterClass(ref wc);
	}

	#region Win32 Interop
	[StructLayout(LayoutKind.Sequential)]
	struct WNDCLASS {
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
	struct MSG {
		public IntPtr hwnd;
		public uint message;
		public IntPtr wParam;
		public IntPtr lParam;
		public uint time;
		public int pt_x;
		public int pt_y;
	}

	[DllImport("user32.dll")]
	static extern ushort RegisterClass(ref WNDCLASS lpWndClass);

	[DllImport("user32.dll")]
	static extern IntPtr CreateWindowEx(
		int dwExStyle,
		string lpClassName,
		string lpWindowName,
		int dwStyle,
		int x, int y, int width, int height,
		IntPtr hWndParent,
		IntPtr hMenu,
		IntPtr hInstance,
		IntPtr lpParam);

	[DllImport("user32.dll")]
	static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("user32.dll")]
	static extern bool UpdateWindow(IntPtr hWnd);

	[DllImport("user32.dll")]
	static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint min, uint max, uint removeMsg);

	[DllImport("user32.dll")]
	static extern bool TranslateMessage(ref MSG lpMsg);

	[DllImport("user32.dll")]
	static extern IntPtr DispatchMessage(ref MSG lpMsg);

	[DllImport("user32.dll")]
	static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	static extern bool DestroyWindow(IntPtr hWnd);

	[DllImport("user32.dll")]
	static extern void PostQuitMessage(int nExitCode);
	#endregion
}