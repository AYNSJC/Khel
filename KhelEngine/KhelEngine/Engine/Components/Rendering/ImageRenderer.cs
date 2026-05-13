using KhelEngine.Mathf;

public class ImageRenderer : Behaviour {
	public Vector2 scale = Vector2.One;
	public Vector4 color = Vector4.One;

	private QuadData quadData = new QuadData();

	public override void Enter() {
		quadData.transform = new Transform();

		quadData.transform.position = entity.transfrom.position;
		quadData.transform.rotation = entity.transfrom.rotation;
		quadData.transform.scale = scale;
		quadData.color = color;

		Engine.Windom.AddQuad(quadData);
	}

	public override void Loop() {
		quadData.transform.position = entity.transfrom.position;
		quadData.transform.rotation = entity.transfrom.rotation;
		quadData.transform.scale = scale;
		quadData.color = color;
	}

	public override void Exit() {
		Engine.Windom.RemoveQuad(quadData);
	}
}