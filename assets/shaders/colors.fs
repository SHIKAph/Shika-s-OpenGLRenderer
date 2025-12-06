#version 330 core
out vec4 FragColor;

// Material Structure
struct Material {
    sampler2D diffuse; // [NEW] For texture mapping (Diffuse Map)
    sampler2D specular; // [NEW] For texture mapping (Specular Map)
    float shineness;
};

// Light Structure
struct Light {
    // vec3 position; (Sun light doesn't have position, but point light does)
    vec3 direction;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    // float constant; (Sun light doesn't have attenuation, but point light does)
    // float linear;
    // float quadratic;
};

in vec3 Normal; // Normal came from vertex shader
in vec3 FragPos; // World coordinates came from vertex shader
in vec2 TexCoord; // Texture coordinates from vertex shader

uniform vec3 viewPos; // camera position (for calculates Specular)
uniform Material material; // material properties
uniform Light light; // light properties

void main()
{
    // Calculate distance and attenuation (Delete for Sun light)
    // float distance    = length(light.position - FragPos);
    // float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));

    // 1. Ambient Using texture for ambient component
    vec3 ambient = light.ambient * vec3(texture(material.diffuse, TexCoord));
    // ambient *= attenuation; // apply attenuation

    // 2. Diffuse Using texture for diffuse component
    vec3 norm = normalize(Normal);

    // [Important Change] Light direction calculation for Sun light
    // vec3 lightDir = normalize(light.position - FragPos); // Direction of light origin (point light)
    // For Sun light, light direction is constant and opposite to light's direction
    vec3 lightDir = normalize(-light.direction);

    // calculates angle of light and normal for Dot Product
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, TexCoord));
    // diffuse *= attenuation; // apply attenuation

    // 3. Specular Using texture for specular component
    vec3 viewDir = normalize(viewPos - FragPos); // view direction
    vec3 reflectDir = reflect(-lightDir, norm); // reflect direction
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shineness);
    vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoord));
    // specular *= attenuation; // apply attenuation

    // result color
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
}