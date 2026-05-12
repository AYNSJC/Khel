using KhelEngine.Mathf;
using Silk.NET.OpenGL;

public class QuadRenderer {
	private GL _gl;

	private uint _vao;
	private uint _vbo;
	private uint _shaderProgram;

	float aspect = (float)Engine.ProjectSettings.Width / (float)Engine.ProjectSettings.Height;

	public QuadRenderer(GL gl) {
		_gl = gl;

		SetupMesh();
		SetupShader();
	}

	private unsafe void SetupMesh() {
		float[] vertices =
		{
            // triangle 1
            -0.5f, -0.5f, 0f,
			 0.5f, -0.5f, 0f,
			 0.5f,  0.5f, 0f,

            // triangle 2
             0.5f,  0.5f, 0f,
			-0.5f,  0.5f, 0f,
			-0.5f, -0.5f, 0f
		};

		_vao = _gl.GenVertexArray();
		_vbo = _gl.GenBuffer();

		_gl.BindVertexArray(_vao);

		_gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);

		fixed(float* v = &vertices[0]) {
			_gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(vertices.Length * sizeof(float)), v, BufferUsageARB.StaticDraw);
		}

		_gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), null);

		_gl.EnableVertexAttribArray(0);

		_gl.BindBuffer(BufferTargetARB.ArrayBuffer, 0);
		_gl.BindVertexArray(0);
	}

	private void SetupShader() {
		string vertexShaderSource =
		"""
        #version 330 core 

        layout (location = 0) in vec3 aPosition;

        uniform vec2 offset;
        uniform float rotation;
        uniform vec2 scale;

        void main()
        {
            float s = sin(rotation);
            float c = cos(rotation);

            vec2 rotated;

            rotated.x = aPosition.x * c - aPosition.y * s;
            rotated.y = aPosition.x * s + aPosition.y * c;

            vec2 pos = rotated * scale + offset;

            gl_Position = vec4(pos, aPosition.z, 1.0);
        }
        """;

		string fragmentShaderSource =
		"#version 330 core\n" +
		"\n" +
		"out vec4 FragColor;\n" +
		"\n" +
		"uniform vec4 quadColor;\n" +
		"\n" +
		"void main()\n" +
		"{\n" +
		"    FragColor = quadColor;\n" +
		"}";

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

	public void Draw(Transform transform, Vector4 color) {
		_gl.UseProgram(_shaderProgram);

		int aspectLocation = _gl.GetUniformLocation(_shaderProgram, "aspect");
		_gl.Uniform1(aspectLocation, aspect);

		int offsetLocation = _gl.GetUniformLocation(_shaderProgram, "offset");
		_gl.Uniform2(offsetLocation, transform.position.x, transform.position.y);

		int rotationLocation = _gl.GetUniformLocation(_shaderProgram, "rotation");
		_gl.Uniform1(rotationLocation, Angle.Degree2Radian(transform.rotation));

		int sizeLocation = _gl.GetUniformLocation(_shaderProgram, "scale");
		_gl.Uniform2(sizeLocation, transform.scale.x, transform.scale.y);

		int colorLocation = _gl.GetUniformLocation(_shaderProgram, "quadColor");
		_gl.Uniform4(colorLocation, color.x, color.y, color.z, color.w);

		_gl.BindVertexArray(_vao);

		_gl.DrawArrays(PrimitiveType.Triangles, 0, 6);
	}
}