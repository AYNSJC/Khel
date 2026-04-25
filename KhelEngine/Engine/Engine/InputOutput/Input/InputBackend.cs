using System.Runtime.InteropServices;

public static class InputBackend {
	[DllImport("user32.dll")]
	private static extern short GetAsyncKeyState(int vKey);

	public static bool IsKeyPressed(Key key) {
		return (GetAsyncKeyState((int)key) & 0x8000) != 0;
	}
}
