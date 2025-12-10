# ShikaOpenGLRenderer

![Language](https://img.shields.io/badge/language-C++17-blue.svg)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey.svg)
![License](https://img.shields.io/badge/license-MIT-green.svg)
![OpenGL](https://img.shields.io/badge/OpenGL-3.3-red.svg)

**ShikaOpenGLRenderer**は、OpenGL 3.3 (Core Profile) をベースにゼロから設計・実装した自作3Dレンダリングエンジンです。 既存のゲームエンジンに依存せず、グラフィックスパイプライン (Graphics Pipeline) の構築、シェーダ (Shader) 管理、およびモダンC++設計の実装を通して、3D CGのレンダリングアーキテクチャを実証することを目的としています。

---

## 🚀 実装機能とロードマップ

- [x] **Project Setup**: Modern CMake (FetchContent) を用いたビルド環境の構築
- [x] **Window Management**: GLFWによるウィンドウ制御とクロスプラットフォーム対応
- [x] **OpenGL Loading**: GLADによるOpenGL関数ポインタのロード管理
- [x] **Rendering Pipeline**: 基本図形（三角形）の描画およびバッファオブジェクト (VBO/VAO) の抽象化
- [x] **Shaders**: シェーダクラスの実装（頂点シェーダ・フラグメントシェーダのコンパイルとリンク管理）
- [x] **Camera System**: FPS（一人称）視点カメラの実装とビュー変換行列の制御
- [x] **Lighting**: フォン反射モデル (Phong Reflection Model) の実装（環境光・拡散反射・鏡面反射）
- [x] **Model Loading**: Assimpライブラリを用いた3Dメッシュデータの読み込み

---

## 🛠 技術スタック

* **言語**: C++17
* **ビルドシステム**: CMake (3.14+)
* **グラフィックスAPI**: OpenGL 3.3 Core Profile
* **ライブラリ**:
    * [GLFW](https://www.glfw.org/) - ウィンドウ管理および入力処理
    * [GLAD](https://glad.dav1d.de/) - OpenGLローダ
    * [GLM](https://github.com/g-truc/glm) - 数学ライブラリ（ベクトル・行列演算）

---

## 📦 ビルド方法

本プロジェクトは **CMake** を使用しており、依存ライブラリは自動的にダウンロード・管理されます。手動でのライブラリインストールは不要です。

### 前提環境
* CMake 3.14 or higher
* C++ Compiler (GCC, Clang, or MSVC)
* Graphics Driver supporting OpenGL 3.3+

### ビルド手順

```bash
# 1. Clone the repository
git clone [https://github.com/SHIKAph/Shika-s-OpenGLRenderer.git](https://github.com/SHIKAph/Shika-s-OpenGLRenderer.git)
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

> *現在、レンダリングエンジンの駆動ができないため（軍内部のネット環境）、ライティング計算やモデル描画のスクリーンショットを近日中に公開予定です。*

---

## 📄 License

本プロジェクトは **MIT License** の下で公開されています。  
詳細は [LICENSE](LICENSE) をご確認ください。