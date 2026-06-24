using Silk.NET.OpenGL;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;

public class OutputWindow {
	// Handle to the actual native window (HWND in Win32)
	private IntPtr _hwnd;

	public nint hwnd => _hwnd;

	private IntPtr _hdc;
	private IntPtr _glContext;

	private const uint PFD_DRAW_TO_WINDOW = 0x00000004;
	private const uint PFD_SUPPORT_OPENGL = 0x00000020;
	private const uint PFD_DOUBLEBUFFER = 0x00000001;

	private const byte PFD_TYPE_RGBA = 0;
	private const sbyte PFD_MAIN_PLANE = 0;

	private bool _running = true;
	private const int WS_OVERLAPPEDWINDOW = 0x00CF0000;
	private const int CW_USEDEFAULT = unchecked((int)0x80000000);
	private const uint WM_CLOSE = 0x0010;
	private const uint WM_DESTROY = 0x0002;
	private const uint WM_QUIT = 0x0012;
	private static WndProc _wndProcDelegate = WindowProc;
	private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[DllImport("opengl32.dll")]
	static extern IntPtr wglGetProcAddress(string name);

	[DllImport("kernel32.dll")]
	static extern IntPtr LoadLibrary(string lpFileName);

	[DllImport("kernel32.dll")]
	static extern IntPtr GetProcAddress(
		IntPtr hModule,
		string procName);

	[DllImport("gdi32.dll")]
	static extern bool SwapBuffers(IntPtr hdc);

	public bool IsRunning => _running;

	private GL _gl;

	private List<QuadData> _quadDataList = new List<QuadData>();

	public GL gl => _gl;

	private int _width;
	private int _height;

	private QuadRenderer _quadRenderer;

	private float aspect;

	private KhelEngine.Mathf.Vector4 _bgColor;

	public OutputWindow(int width, int height, string title, KhelEngine.Mathf.Vector4 bgColor) {
		RegisterWindowClass();

		_width = width;
		_height = height;

		_hwnd = CreateWindowEx(0, "OutputWindowClass", title, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, _width, _height, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

		ShowWindow(_hwnd, 1);
		UpdateWindow(_hwnd);

		aspect = (float) _width / (float) _height;

		float worldHeight = 10f;
		float worldWidth = worldHeight * aspect;

		var _projection = Matrix4x4.CreateOrthographic(worldWidth, worldHeight, -1f, 1f);

		_bgColor = bgColor;

		CreateOpenGLContext();

		_quadRenderer = new QuadRenderer(gl);
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

	public void CreateOpenGLContext() {
		// Get drawing surface from window
		_hdc = GetDC(_hwnd);

		PIXELFORMATDESCRIPTOR pfd = new PIXELFORMATDESCRIPTOR();

		pfd.nSize = (ushort)Marshal.SizeOf<PIXELFORMATDESCRIPTOR>();
		pfd.nVersion = 1;

		// Tell Windows we want:
		// - OpenGL support
		// - drawing to a window
		// - double buffering
		pfd.dwFlags =
			PFD_DRAW_TO_WINDOW |
			PFD_SUPPORT_OPENGL |
			PFD_DOUBLEBUFFER;

		// RGBA color mode
		pfd.iPixelType = PFD_TYPE_RGBA;

		// 32-bit color buffer
		pfd.cColorBits = 32;

		// 24-bit depth buffer
		pfd.cDepthBits = 24;

		// Main drawing layer
		pfd.iLayerType = PFD_MAIN_PLANE;

		// Ask Windows for best pixel format
		int pixelFormat = ChoosePixelFormat(_hdc, ref pfd);

		// Apply pixel format to window
		SetPixelFormat(_hdc, pixelFormat, ref pfd);

		// Create OpenGL context
		_glContext = wglCreateContext(_hdc);

		// Activate OpenGL context
		wglMakeCurrent(_hdc, _glContext);

		_gl = GL.GetApi(name =>
		{
			IntPtr proc = wglGetProcAddress(name);

			if(proc == IntPtr.Zero) {
				IntPtr module = LoadLibrary("opengl32.dll");

				proc = GetProcAddress(module, name);
			}

			return proc;
		});

		RECT rect;

		GetClientRect(_hwnd, out rect);

		int width = rect.right - rect.left;
		int height = rect.bottom - rect.top;

		_gl.Viewport(0, 0, (uint)width, (uint)height);
	}

	public void Render() {
		_gl.ClearColor(_bgColor.x, _bgColor.y, _bgColor.z, _bgColor.w);

		_gl.Clear(ClearBufferMask.ColorBufferBit);

		foreach(QuadData quad in _quadDataList) {
			_quadRenderer.Draw(quad.transform, quad.color, quad.textureId, quad.hasTexture);
		}

		SwapBuffers(_hdc);
	}

	#region OpenGL
	[DllImport("user32.dll")]
	static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("gdi32.dll")]
	static extern int SetPixelFormat(IntPtr hdc, int format, ref PIXELFORMATDESCRIPTOR pfd);

	[DllImport("gdi32.dll")]
	static extern int ChoosePixelFormat(IntPtr hdc, ref PIXELFORMATDESCRIPTOR pfd);

	[DllImport("opengl32.dll")]
	static extern IntPtr wglCreateContext(IntPtr hdc);

	[DllImport("opengl32.dll")]
	static extern bool wglMakeCurrent(IntPtr hdc, IntPtr hglrc);
	#endregion

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

	[StructLayout(LayoutKind.Sequential)]
	struct RECT {
		public int left;
		public int top;
		public int right;
		public int bottom;
	}

	[DllImport("user32.dll")]
	static extern bool GetClientRect(
		IntPtr hWnd,
		out RECT lpRect
	);

	#endregion

	public void AddQuad(QuadData quadData) {
		_quadDataList.Add(quadData);
	}
	public void RemoveQuad(QuadData quadData) {
		_quadDataList.Remove(quadData);
	}
}