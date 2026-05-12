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
		RotatePlayer();
	}

	private void MovePlayer() {
		if(_direction.SquareMagnitude() != 0) {
			entity.transfrom.position += _direction * speed * Engine.deltaTime;
			PrintPosition();
		}
	}

	private void RotatePlayer() {
		entity.transfrom.LookTowards(Input.GetMousePosition());
	}

	private void GetDirection() {
		_direction = Vector2.Zero;

		if(Input.GetKey(KeyCode.W)) {
			_direction.y = 1;
		}

		if(Input.GetKey(KeyCode.S)) {
			_direction.y = -1;
		}

		if(Input.GetKey(KeyCode.D)) {
			_direction.x = 1;
		}

		if(Input.GetKey(KeyCode.A)) {
			_direction.x = -1;
		}

		_direction.Normalize();
	}

	private void PrintPosition() {
		Logger.Log("Player's Position: " + entity.transfrom.position.ToString());
		Logger.Log("Player's Rotation: " + entity.transfrom.rotation);
	}
}
