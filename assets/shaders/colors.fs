#version 330 core
out vec4 FragColor;

uniform vec3 objectColor; // Color of the object
uniform vec3 lightColor;  // Color of the light source

void main()
{
    // object color * light color = wachted color
    FragColor = vec4(lightColor * objectColor, 1.0);
}