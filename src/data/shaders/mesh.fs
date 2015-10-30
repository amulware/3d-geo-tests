#version 130

in vec3 p_position;
in vec3 p_normal;

out vec4 fragColor;

void main()
{
	vec3 normal = normalize(p_normal);

	float l = dot(normal, vec3(0, 1, 0));
	float r = min(l, 0.5);

	float z = (p_position.z + 1) * 0.5;

    fragColor = vec4(z, z, z, 1);
}