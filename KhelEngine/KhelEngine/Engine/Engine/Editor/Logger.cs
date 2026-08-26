using System;

public static class Logger {
	static Logger() {
		Console.WriteLine("=======================");
		Console.WriteLine("Logs: ");
	}

	public static void Log(string log) {
		Console.WriteLine(log);
	}

	public static void Error(string err) {
		Console.WriteLine("ERROR: " + err);
	}
}
