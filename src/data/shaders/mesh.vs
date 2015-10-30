#version 130

uniform mat4 projectionMatrix;
uniform mat4 modelviewMatrix;
uniform mat4 meshTransform;

in vec3 v_position;
in vec3 v_normal;

out vec3 p_position;
out vec3 p_normal;

void main()
{
	p_position = v_position;
	gl_Position = projectionMatrix
		* modelviewMatrix
		* meshTransform
		* vec4(v_position, 1.0);
	p_normal = v_normal;
}