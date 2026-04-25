using KhelEngine.Mathf;

public class PlayerScript : Script {
	private float speed = 5f;

	private Vector2 _direction = Vector2.Zero;

	public override void Enter() {
		PrintPosition();
	}

	public override void Loop() {
		GetDirection();
	}

	public override void FixedLoop() {
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

		if(Input.GetKey(Key.W)) {
			_direction.y = speed;
		}

		if(Input.GetKey(Key.S)) {
			_direction.y = -speed;
		}

		if(Input.GetKey(Key.D)) {
			_direction.x = speed;
		}

		if(Input.GetKey(Key.A)) {
			_direction.x = -speed;
		}
	}

	private void PrintPosition() {
		Logger.Log("Player's Position: ");
		Logger.Log(entity.transfrom.position.x.ToString() + ", ");
		Logger.Log(entity.transfrom.position.y.ToString());
	}
}
