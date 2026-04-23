public class PlayerDebug : Script {
	public override void Enter() {
		Logger.Log("Player's Position: ");
		Logger.Log(entity.transfrom.position.x.ToString() + ", ");
		Logger.Log(entity.transfrom.position.y.ToString());
	}
}
