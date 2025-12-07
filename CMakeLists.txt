cmake_minimum_required(VERSION 3.14)

# 1. Setting Project Name and Languages
project(ShikaOpenGLRenderer VERSION 1.0.0 LANGUAGES CXX C)

# 2. Setting C++ Standard
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# 3. Setting Auto download External Library (FetchContent)
include(FetchContent)

# [3-1] Download GLFW (Create Windows and managing input)
FetchContent_Declare(
    glfw
    GIT_REPOSITORY https://github.com/glfw/glfw.git
    GIT_TAG        3.3.8
)
FetchContent_MakeAvailable(glfw)

# [3-2] Download GLM (Math Library)
FetchContent_Declare(
    glm
    GIT_REPOSITORY https://github.com/g-truc/glm.git
    GIT_TAG        0.9.9.8
)
FetchContent_MakeAvailable(glm)

# [3-3] Download Assimp (3D Model Loading Library)
FetchContent_Declare(
    assimp 
    GIT_REPOSITORY https://github.com/assimp/assimp.git
    GIT_TAG v5.2.5
)
set(ASSIMP_BUILD_TESTS OFF CACHE BOOL "" FORCE)
set(ASSIMP_BUILD_ASSIMP_TOOLS OFF CACHE BOOL "" FORCE)
set(ASSIMP_INSTALL_PDB OFF CACHE BOOL "" FORCE)
FetchContent_MakeAvailable(assimp)

# 4. Execute File Create(include main.cpp and All the cpp files in src folder)
file(GLOB_RECURSE SOURCES "src/*.cpp" "src/*.c")
add_executable(${PROJECT_NAME} ${SOURCES})

# 5. Setting Header file Route(Include Directory) 
target_include_directories(${PROJECT_NAME} PUBLIC 
    ${CMAKE_CURRENT_SOURCE_DIR}/include
    ${CMAKE_CURRENT_SOURCE_DIR}/external
)

# 6. Linking Library (Linking)
target_link_libraries(${PROJECT_NAME} PRIVATE glfw glm assimp)

# OpneGL Framework Setting for Mac User
if (APPLE)
    target_link_libraries(${PROJECT_NAME} PRIVATE "-framework OpenGL -framework IOKit -framework Cocoa")
else()
    # System OpenGL Connect if Windows/Linux
    find_package(OpenGL REQUIRED)
    target_link_libraries(${PROJECT_NAME} PRIVATE OpenGL::GL)
endif()