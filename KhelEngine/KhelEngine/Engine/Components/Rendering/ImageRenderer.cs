using KhelEngine.Mathf;

public class ImageRenderer : Behaviour {
	public Vector4 color = Vector4.One;

	public override void Enter() {
		QuadData quadData = new QuadData();

		quadData.transform = entity.transfrom;
		quadData.color = color;

		Engine.Windom.AddQuad(quadData);
	}

	public override void Loop() {
		
	}
}