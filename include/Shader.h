#ifndef SHADER_H
#define SHADER_H

#include <glad/glad.h> // Include OpenGL headers
#include <glm/glm.hpp>

#include <string>
#include <fstream>
#include <sstream>
#include <iostream>

class Shader
{
public:
    unsigned int ID; // Shader program ID

    // Constructor: reads and builds the shader from file paths
    Shader(const char* vertexPath, const char* fragmentPath);
    
    // Activate the shader
    void use();
    
    // Uniform utility functions
    void setBool(const std::string &name, bool value) const;
    void setInt(const std::string &name, int value) const;
    void setFloat(const std::string &name, float value) const;

    // [NEW] Utility function to set 4X4 matrix uniforms
    void setMat4(const std::string &name, const glm::mat4 &mat) const;
    void setVec3(const std::string &name, float x, float y, float z) const;

private:
    // Compile error checking utility
    void checkCompileErrors(unsigned int shader, std::string type);
};

#endif