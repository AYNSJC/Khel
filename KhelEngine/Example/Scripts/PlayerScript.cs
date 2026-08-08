using KhelEngine.Mathf;

public class PlayerScript : Script {
    private float speed = 7f;

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
            entity.transform.position += _direction * (speed * Engine.deltaTime);
        }
    }

    private void RotatePlayer() {
        entity.transform.LookTowards(Input.GetMouseWorldPosition());
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

        _direction.Normalized();

        if(Input.GetKeyDown(KeyCode.LEFT_MOUSE_BUTTON)) {
            Instantiate.Create(new BulletEntity(), entity.transform.position + entity.transform.Forward, entity.transform.rotation, Vector2.One);
        }

        if(Input.MouseClick(0, this.entity)) {
            PrintPosition();
        }
    }

    private void PrintPosition() {
        Logger.Log("Player's Position: " + entity.transform.position.ToString());
        Logger.Log("Player's Rotation: " + entity.transform.rotation);
        Logger.Log(SceneManager.activeScene.entityList.Count.ToString());
    }
}
