#version 330 core
out vec4 FragColor;

// [NEW] Material Structure
struct Material {
    sampler2D diffuse; // [NEW] For texture mapping (Diffuse Map)
    sampler2D specular; // [NEW] For texture mapping (Specular Map)
    float shineness;
};

// Light Structure
struct Light {
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 Normal; // Normal came from vertex shader
in vec3 FragPos; // World coordinates came from vertex shader
in vec2 TexCoord; // [NEW] Texture coordinates from vertex shader

uniform vec3 viewPos; // camera position (for calculates Specular)
uniform Material material; // material properties
uniform Light light; // light properties

void main()
{
    // 1. Ambient [NEW] Using texture for ambient component
    vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoord));

    // 2. Diffuse [NEW] Using texture for diffuse component
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos); // Direction of light
    // calculates angle of light and normal for Dot Product
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, TexCoord));

    // 3. Specular [NEW] Using texture for specular component
    vec3 viewDir = normalize(viewPos - FragPos); // view direction
    vec3 reflectDir = reflect(-lightDir, norm); // reflect direction
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shineness);
    vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoord));

    // result color
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
}