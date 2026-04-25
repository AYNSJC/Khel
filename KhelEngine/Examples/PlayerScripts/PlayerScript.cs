using KhelEngine.Mathf;

public class PlayerScript : Script {
	private float speed = 5f;

	private Vector2 _direction = Vector2.Zero;

	public override void Enter() {
		PrintPosition();
	}

	public override void Loop() {
		GetDirection();
		MovePlayer();
	}

	private void MovePlayer() {
		if(_direction.SquareMagnitude() != 0) {
			entity.transfrom.position += _direction;
			PrintPosition();
		}
	}

	private void GetDirection() {
		_direction = Vector2.Zero;

		float amount = speed * Engine.deltaTime;

		if(Input.GetKey(WindowsKeyCode.W)) {
			_direction.y = amount;
		}

		if(Input.GetKey(WindowsKeyCode.S)) {
			_direction.y = -amount;
		}

		if(Input.GetKey(WindowsKeyCode.D)) {
			_direction.x = amount;
		}

		if(Input.GetKey(WindowsKeyCode.A)) {
			_direction.x = -amount;
		}

		_direction.Normalize();
	}

	private void PrintPosition() {
		Logger.Log("Player's Position: ");
		Logger.Log(entity.transfrom.position.x.ToString() + ", ");
		Logger.Log(entity.transfrom.position.y.ToString());
	}
}
