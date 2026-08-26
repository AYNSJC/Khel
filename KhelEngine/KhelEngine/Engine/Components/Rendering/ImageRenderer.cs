using System;
using Silk.NET.OpenGL;
using StbImageSharp;
using KhelEngine.Mathf;
using System.IO;

public class ImageRenderer : Behaviour {
	public Vector2 positionOffset = Vector2.Zero;
	public float rotationOffset = 0f;
	public Vector2 scale = Vector2.One;
	public Vector4 color = Vector4.One;

	private string fullImagePath = "";

	private QuadData quadData = new QuadData();

	public override void Enter() {
		quadData.transform = new Transform();

		UpdateTransformAndColor();

		Engine.window.AddQuad(quadData);
	}

	public override void Loop() {
		UpdateTransformAndColor();
	}

	public override void Exit() {
		Engine.window.RemoveQuad(quadData);

		if(quadData.hasTexture) {
			Engine.window.gl.DeleteTexture(quadData.textureId);
		}
	}

	public void SetImage(string path) {
		if(quadData.hasTexture) {
			Engine.window.gl.DeleteTexture(quadData.textureId);
			quadData.hasTexture = false;
		}

		fullImagePath = path;

		if(!string.IsNullOrEmpty(path)) {
			quadData.textureId = LoadTexture(path);
			quadData.hasTexture = true;
		}
	}

	public string GetImagePath() {
		return fullImagePath;
	}

	private void UpdateTransformAndColor() {
		quadData.transform.position = entity.transform.position + positionOffset;
		quadData.transform.rotation = entity.transform.rotation + rotationOffset;
		quadData.transform.scale = new Vector2(scale.x * entity.transform.scale.x, scale.y * entity.transform.scale.y);
		quadData.color = color;
	}

	private uint LoadTexture(string path) {
		GL gl = Engine.window.gl;

		uint textureId = gl.GenTexture();
		gl.ActiveTexture(TextureUnit.Texture0);
		gl.BindTexture(TextureTarget.Texture2D, textureId);

		if(!Path.IsPathRooted(fullImagePath)) {
			path = Path.Combine(Application.projectPath, fullImagePath);
		}

		if(!File.Exists(path)) {
			Logger.Log("ERROR: " + path + " does not exsist!");
			return 0;
		}

		ImageResult image = ImageResult.FromMemory(File.ReadAllBytes(path), ColorComponents.RedGreenBlueAlpha);

		gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba, (uint)image.Width, (uint)image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, (ReadOnlySpan<byte>)image.Data);

		gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)GLEnum.ClampToEdge);
		gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)GLEnum.ClampToEdge);
		gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)GLEnum.Linear);
		gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)GLEnum.Linear);

		gl.BindTexture(TextureTarget.Texture2D, 0);

		return textureId;
	}
}