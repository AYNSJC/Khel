using System;

public class PlayerDebug : Script {
	public override void Enter() {
		Console.WriteLine("Player's Position: ");
		Console.WriteLine(entity.transfrom.position.x);
		Console.WriteLine(entity.transfrom.position.y);
	}
}
