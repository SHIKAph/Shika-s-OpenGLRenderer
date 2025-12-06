#version 330 core
out vec4 FragColor;

// Material Structure
struct Material {
    sampler2D diffuse; // For texture mapping (Diffuse Map)
    sampler2D specular; // For texture mapping (Specular Map)
    float shineness;
};

// Light Structure
struct Light {
    vec3 position;
    vec3 direction;

    float cutOff; // [NEW] For spotlight, inner cone (light 100%)
    float outerCutOff; // outer cone (light 0%)

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    // float constant;  (attenuation factors - Not use now for simple codes)
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

    // [NEW] Spotlight calculation
    vec3 lightDir = normalize(light.position - FragPos);

      // theta: angle between light direction and fragment to light direction(cosine value)
      float theta = dot(lightDir, normalize(-light.direction));

      // epsilon: smooth edge for spotlight
      float epsilon = light.cutOff - light.outerCutOff;

      // intensity: smooth edge factor for spotlight
      float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);

    // 2. Diffuse Using texture for diffuse component
    vec3 norm = normalize(Normal);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * vec3(texture(material.diffuse, TexCoord));
    // diffuse *= attenuation; // apply attenuation

    // 3. Specular Using texture for specular component
    vec3 viewDir = normalize(viewPos - FragPos); // view direction
    vec3 reflectDir = reflect(-lightDir, norm); // reflect direction
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shineness);
    vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoord));
    // specular *= attenuation; // apply attenuation

    // [NEW] if outside spotlight cone, disable diffuse and specular components
    diffuse *= intensity;
    specular *= intensity;

    // result color
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
}