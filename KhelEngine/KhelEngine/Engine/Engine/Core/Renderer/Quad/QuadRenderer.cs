using KhelEngine.Mathf;
using Silk.NET.OpenGL;
using System.Numerics;

public class QuadRenderer {
	private GL _gl;

	private uint _vao;
	private uint _vbo;
	private uint _shaderProgram;

	float aspect = (float)Engine.ProjectSettings.Width / (float)Engine.ProjectSettings.Height;

	private Matrix4x4 _projection;

	public QuadRenderer(GL gl) {
		float worldHeight = 10f;
		float worldWidth = worldHeight * aspect;

		_projection = Matrix4x4.CreateOrthographic(worldWidth, worldHeight, -1f, 1f);

		_gl = gl;

		SetupMesh();
		SetupShader();
	}

	private unsafe void SetupMesh() {
		float[] vertices = {
			-0.5f, -0.5f, 0f,  0f, 1f,
			 0.5f, -0.5f, 0f,  1f, 1f,
			 0.5f,  0.5f, 0f,  1f, 0f,

			0.5f,  0.5f, 0f,  1f, 0f,
			-0.5f,  0.5f, 0f,  0f, 0f,
			-0.5f, -0.5f, 0f,  0f, 1f
		};

		_vao = _gl.GenVertexArray();
		_vbo = _gl.GenBuffer();

		_gl.BindVertexArray(_vao);

		_gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);

		fixed(float* v = &vertices[0]) {
			_gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(vertices.Length * sizeof(float)), v, BufferUsageARB.StaticDraw);
		}

		_gl.Enable(GLEnum.Blend);
		_gl.BlendFunc(GLEnum.SrcAlpha,GLEnum.OneMinusSrcAlpha);

		// position attribute (location 0)
		_gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), (void*)0);
		_gl.EnableVertexAttribArray(0);

		// uv attribute (location 1)
		_gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), (void*)(3 * sizeof(float)));
		_gl.EnableVertexAttribArray(1);

		_gl.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
		_gl.BindVertexArray(0);
	}

	private void SetupShader() {
		string vertexShaderSource =
		"""
         #version 330 core

         layout (location = 0) in vec3 aPosition;
         layout (location = 1) in vec2 aTexCoord;

         uniform mat4 projection;
         uniform vec2 offset;
         uniform float rotation;
         uniform vec2 scale;

         out vec2 TexCoord;

         void main()
         {
            vec2 scaled = aPosition.xy * scale;

            float s = sin(rotation);
            float c = cos(rotation);

            vec2 rotated;

            rotated.x = scaled.x * c - scaled.y * s;
            rotated.y = scaled.x * s + scaled.y * c;

            vec2 pos = rotated + offset;

            gl_Position = projection * vec4(pos, aPosition.z, 1.0);

            TexCoord = aTexCoord;
         }
         """;

		string fragmentShaderSource =
		"""
         #version 330 core

         out vec4 FragColor;

         in vec2 TexCoord;

         uniform vec4 quadColor;
         uniform sampler2D uTexture;
         uniform bool hasTexture;

         void main()
         {
            if (hasTexture) {
                FragColor = texture(uTexture, TexCoord) * quadColor;
            } 
            else {
                FragColor = quadColor;
            }
         }
        """;

		uint vertexShader = _gl.CreateShader(ShaderType.VertexShader);
		_gl.ShaderSource(vertexShader, vertexShaderSource);
		_gl.CompileShader(vertexShader);

		uint fragmentShader = _gl.CreateShader(ShaderType.FragmentShader);
		_gl.ShaderSource(fragmentShader, fragmentShaderSource);
		_gl.CompileShader(fragmentShader);

		_shaderProgram = _gl.CreateProgram();

		_gl.AttachShader(_shaderProgram, vertexShader);
		_gl.AttachShader(_shaderProgram, fragmentShader);

		_gl.LinkProgram(_shaderProgram);

		_gl.DeleteShader(vertexShader);
		_gl.DeleteShader(fragmentShader);
	}

	public void Draw(Transform transform, KhelEngine.Mathf.Vector4 color, uint textureId = 0, bool hasTexture = false) {
		_gl.UseProgram(_shaderProgram);

		int projectionLocation = _gl.GetUniformLocation(_shaderProgram, "projection");
		unsafe {
			fixed(float* projectionPtr = &_projection.M11) {
				_gl.UniformMatrix4(projectionLocation, 1, true, projectionPtr);
			}
		}

		int offsetLocation = _gl.GetUniformLocation(_shaderProgram, "offset");
		_gl.Uniform2(offsetLocation, transform.position.x, transform.position.y);

		int rotationLocation = _gl.GetUniformLocation(_shaderProgram, "rotation");
		_gl.Uniform1(rotationLocation, Angle.Degree2Radian(transform.rotation));

		int sizeLocation = _gl.GetUniformLocation(_shaderProgram, "scale");
		_gl.Uniform2(sizeLocation, transform.scale.x, transform.scale.y);

		int colorLocation = _gl.GetUniformLocation(_shaderProgram, "quadColor");
		_gl.Uniform4(colorLocation, color.x, color.y, color.z, color.w);

		int hasTextureLocation = _gl.GetUniformLocation(_shaderProgram, "hasTexture");
		_gl.Uniform1(hasTextureLocation, hasTexture ? 1 : 0);

		if(hasTexture) {
			_gl.ActiveTexture(TextureUnit.Texture0);
			_gl.BindTexture(TextureTarget.Texture2D, textureId);
			int textureLocation = _gl.GetUniformLocation(_shaderProgram, "uTexture");
			_gl.Uniform1(textureLocation, 0);
		}

		_gl.BindVertexArray(_vao);

		_gl.DrawArrays(PrimitiveType.Triangles, 0, 6);
	}
}