#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal; // Normal Vector
layout (location = 2) in vec2 aTexCoord; // [NEW]

out vec3 Normal;
out vec3 FragPos; // Pixel's World coordinates
out vec2 TexCoord; // [NEW]

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    gl_Position = projection * view * model * vec4(aPos, 1.0);

    // World coordinates for lighting calculates
    FragPos = vec3(model * vec4(aPos, 1.0));

    // Should be rotate Normal Vector
    Normal = mat3(transpose(inverse(model))) * aNormal;

    // [NEW]
    TexCoord = aTexCoord;
}