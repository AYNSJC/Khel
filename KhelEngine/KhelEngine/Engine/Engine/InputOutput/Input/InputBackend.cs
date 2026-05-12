using KhelEngine.Mathf;
using System.Runtime.InteropServices;

public static class InputBackend {
	private static int GetVKCode(KeyCode key) {
		switch(key) {
			// Mouse buttons
			case KeyCode.LEFT_MOUSE_BUTTON: return 0x01;
			case KeyCode.RIGHT_MOUSE_BUTTON: return 0x02;
			case KeyCode.MIDDLE_MOUSE_BUTTON: return 0x04;
			case KeyCode.EXTRA_MOUSE_BUTTON1: return 0x05;
			case KeyCode.EXTRA_MOUSE_BUTTON2: return 0x06;

			// Control Keys
			case KeyCode.BACKSPACE: return 0x08;
			case KeyCode.TAB: return 0x09;
			case KeyCode.ENTER: return 0x0D;
			case KeyCode.SHIFT: return 0x10;
			case KeyCode.CONTROL: return 0x11;
			case KeyCode.ALT: return 0x12;
			case KeyCode.PAUSE: return 0x13;
			case KeyCode.CAPS_LOCK: return 0x14;
			case KeyCode.ESCAPE: return 0x1B;

			// Navigation & Editing Keys
			case KeyCode.SPACE: return 0x20;
			case KeyCode.PAGE_UP: return 0x21;
			case KeyCode.PAGE_DOWN: return 0x22;
			case KeyCode.END: return 0x23;
			case KeyCode.HOME: return 0x24;
			case KeyCode.LEFT: return 0x25;
			case KeyCode.UP: return 0x26;
			case KeyCode.RIGHT: return 0x27;
			case KeyCode.DOWN: return 0x28;
			case KeyCode.SELECT: return 0x29;
			case KeyCode.PRINT: return 0x2A;
			case KeyCode.EXECUTE: return 0x2B;
			case KeyCode.PRINT_SCREEN: return 0x2C;
			case KeyCode.INSERT: return 0x2D;
			case KeyCode.DELETE: return 0x2E;
			case KeyCode.HELP: return 0x2F;

			// 0–9
			case KeyCode.N0: return 0x30;
			case KeyCode.N1: return 0x31;
			case KeyCode.N2: return 0x32;
			case KeyCode.N3: return 0x33;
			case KeyCode.N4: return 0x34;
			case KeyCode.N5: return 0x35;
			case KeyCode.N6: return 0x36;
			case KeyCode.N7: return 0x37;
			case KeyCode.N8: return 0x38;
			case KeyCode.N9: return 0x39;

			// A–Z
			case KeyCode.A: return 0x41;
			case KeyCode.B: return 0x42;
			case KeyCode.C: return 0x43;
			case KeyCode.D: return 0x44;
			case KeyCode.E: return 0x45;
			case KeyCode.F: return 0x46;
			case KeyCode.G: return 0x47;
			case KeyCode.H: return 0x48;
			case KeyCode.I: return 0x49;
			case KeyCode.J: return 0x4A;
			case KeyCode.K: return 0x4B;
			case KeyCode.L: return 0x4C;
			case KeyCode.M: return 0x4D;
			case KeyCode.N: return 0x4E;
			case KeyCode.O: return 0x4F;
			case KeyCode.P: return 0x50;
			case KeyCode.Q: return 0x51;
			case KeyCode.R: return 0x52;
			case KeyCode.S: return 0x53;
			case KeyCode.T: return 0x54;
			case KeyCode.U: return 0x55;
			case KeyCode.V: return 0x56;
			case KeyCode.W: return 0x57;
			case KeyCode.X: return 0x58;
			case KeyCode.Y: return 0x59;
			case KeyCode.Z: return 0x5A;

			// Windows / System
			case KeyCode.LEFT_SUPER_KEY: return 0x5B;
			case KeyCode.RIGHT_SUPER_KEY: return 0x5C;
			case KeyCode.CONTEXT_MENU: return 0x5D;

			// Numpad
			case KeyCode.NUMPAD0: return 0x60;
			case KeyCode.NUMPAD1: return 0x61;
			case KeyCode.NUMPAD2: return 0x62;
			case KeyCode.NUMPAD3: return 0x63;
			case KeyCode.NUMPAD4: return 0x64;
			case KeyCode.NUMPAD5: return 0x65;
			case KeyCode.NUMPAD6: return 0x66;
			case KeyCode.NUMPAD7: return 0x67;
			case KeyCode.NUMPAD8: return 0x68;
			case KeyCode.NUMPAD9: return 0x69;
			case KeyCode.MULTIPLY: return 0x6A;
			case KeyCode.ADD: return 0x6B;
			case KeyCode.SEPARATOR: return 0x6C;
			case KeyCode.SUBTRACT: return 0x6D;
			case KeyCode.DECIMAL: return 0x6E;
			case KeyCode.DIVIDE: return 0x6F;

			// Function Keys
			case KeyCode.F1: return 0x70;
			case KeyCode.F2: return 0x71;
			case KeyCode.F3: return 0x72;
			case KeyCode.F4: return 0x73;
			case KeyCode.F5: return 0x74;
			case KeyCode.F6: return 0x75;
			case KeyCode.F7: return 0x76;
			case KeyCode.F8: return 0x77;
			case KeyCode.F9: return 0x78;
			case KeyCode.F10: return 0x79;
			case KeyCode.F11: return 0x7A;
			case KeyCode.F12: return 0x7B;
			case KeyCode.F13: return 0x7C;
			case KeyCode.F14: return 0x7D;
			case KeyCode.F15: return 0x7E;
			case KeyCode.F16: return 0x7F;
			case KeyCode.F17: return 0x80;
			case KeyCode.F18: return 0x81;
			case KeyCode.F19: return 0x82;
			case KeyCode.F20: return 0x83;
			case KeyCode.F21: return 0x84;
			case KeyCode.F22: return 0x85;
			case KeyCode.F23: return 0x86;
			case KeyCode.F24: return 0x87;

			// Locks
			case KeyCode.NUMLOCK: return 0x90;
			case KeyCode.SCROLL: return 0x91;

			// Left/Right Modifiers
			case KeyCode.LEFT_SHIFT: return 0xA0;
			case KeyCode.RIGHT_SHIFT: return 0xA1;
			case KeyCode.LEFT_CONTROL: return 0xA2;
			case KeyCode.RIGHT_CONTROL: return 0xA3;
			case KeyCode.LEFT_ALT: return 0xA4;
			case KeyCode.RIGHT_ALT: return 0xA5;

			// OEM Keys
			case KeyCode.COLON_SEMICOLON: return 0xBA;
			case KeyCode.EQUAL_PLUS: return 0xBB;
			case KeyCode.COMMA_LESS_THAN: return 0xBC;
			case KeyCode.MINUS_UNDERSCORE: return 0xBD;
			case KeyCode.PERIOD_GREATER_THAN: return 0xBE;
			case KeyCode.FORWARD_SLASH_QUESTION_MARK: return 0xBF;
			case KeyCode.BACKTICK_SQUIGGLE: return 0xC0;
			case KeyCode.SQUARE_CURLY_BRACKET_OPEN: return 0xDB;
			case KeyCode.BACK_SLASH_PIPE: return 0xDC;
			case KeyCode.SQUARE_CURLY_BRACKET_CLOSE: return 0xDD;
			case KeyCode.QUOTES: return 0xDE;

			default: return 0;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct POINT {
		public int X;
		public int Y;
	}

	[DllImport("user32.dll")]
	private static extern bool GetCursorPos(out POINT lpPoint);

	[DllImport("user32.dll")]
	private static extern bool ScreenToClient(nint hWnd, ref POINT lpPoint);

	[DllImport("user32.dll")]
	private static extern short GetAsyncKeyState(int vKey);

	public static nint WindowHandle = Engine.Windom.hwnd;

	public static Vector2 GetMousePosition() {
		GetCursorPos(out POINT p);

		ScreenToClient(WindowHandle, ref p);

		return new Vector2(p.X, p.Y);
	}

	public static bool IsKeyPressed(KeyCode key) {
		int vk = GetVKCode(key);
		return (GetAsyncKeyState(vk) & 0x8000) != 0;
	}
}