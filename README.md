# ShikaOpenGLRenderer

![Language](https://img.shields.io/badge/language-C++17-blue.svg)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey.svg)
![License](https://img.shields.io/badge/license-MIT-green.svg)
![OpenGL](https://img.shields.io/badge/OpenGL-3.3-red.svg)

## [日本語版はこちらへ](https://github.com/SHIKAph/Shika-s-OpenGLRenderer/blob/main/README.ja.md)

**ShikaOpenGLRenderer** is a custom-built 3D rendering engine based on OpenGL 3.3 Core Profile.  
This project demonstrates the implementation of the graphics pipeline, shader management, and modern C++ architecture without relying on heavy game engines.

---

## 🚀 Features & Roadmap

- [x] **Project Setup**: Modern CMake build system with FetchContent.
- [x] **Window Management**: GLFW integration with cross-platform support.
- [x] **OpenGL Loading**: GLAD integration for managing function pointers.
- [x] **Rendering Pipeline**: Basic triangle rendering & VBO/VAO/EBO abstraction.
- [x] **Shaders**: Shader class implementation (Vertex & Fragment).
- [x] **Camera System**: FPS style camera movement.
- [x] **Lighting**: Phong lighting model implementation.
- [x] **Model Loading**: Mesh loading via Assimp.

---

## 🛠 Tech Stack

* **Language**: C++17
* **Build System**: CMake (3.14+)
* **Graphics API**: OpenGL 3.3 Core Profile
* **Libraries**:
    * [GLFW](https://www.glfw.org/) - Windowing & Input
    * [GLAD](https://glad.dav1d.de/) - OpenGL Loader
    * [GLM](https://github.com/g-truc/glm) - Mathematics (Vectors/Matrices)

---

## 📦 How to Build

This project uses **CMake** to manage dependencies automatically. You don't need to manually install libraries.

### Prerequisites
* CMake 3.14 or higher
* C++ Compiler (GCC, Clang, or MSVC)
* Graphics Driver supporting OpenGL 3.3+

### Build Steps

```bash
# 1. Clone the repository
git clone [https://github.com/SHIKA-gfx/Shika-s-OpenGLRenderer.git](https://github.com/SHIKA-gfx/Shika-s-OpenGLRenderer.git)
cd Shika-s-OpenGLRenderer

# 2. Generate build files (Dependencies will be downloaded automatically)
cmake -B build

# 3. Compile
cmake --build build

# 4. Run
./build/ShikaOpenGLRenderer
```

---

## 🖼 Gallery

> *Currently, the rendering engine is in the initial setup phase.* > *Screenshots of the triangle rendering and lighting will be uploaded here soon.*

---

## 📄 License

This project is licensed under the **MIT License**.  
See the [LICENSE](LICENSE) file for details.