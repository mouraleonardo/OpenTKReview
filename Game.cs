using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace WindowEngine
{
    // Game class handles the logic and rendering for our 3D graphics app
    public class Game
    {
        // Surface for 2D pixel operations (simplified for this demo)
        private Surface screen;
        // Angle for spinning animation
        private float angle = 0f;

        // Constructor: Initialize with screen dimensions
        public Game(int width, int height)
        {
            screen = new Surface(width, height);
        }

        // Initialize OpenGL state and resources
        public void Init()
        {
            // Set clear color to dark blue for a clean background
            GL.ClearColor(0.0f, 0.0f, 0.2f, 1.0f);
            // Enable depth testing for 3D rendering
            GL.Enable(EnableCap.DepthTest);
            // Set up a basic orthographic projection (2D-like for simplicity)
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-2.0, 2.0, -2.0, 2.0, -10.0, 10.0); // World coords: -2 to 2
        }

        // Called each frame to update and render
        public void Tick()
        {
            // Clear the screen and depth buffer
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Update angle for spinning animation (radians per frame)
            angle += 0.05f;

            // Render in 3D using OpenGL
            RenderGL();
        }

        // Custom OpenGL rendering
        public void RenderGL()
        {
            // Set modelview matrix for transformations
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            // Apply rotation around Z-axis for spinning effect
            GL.Rotate(angle * 180 / MathHelper.Pi, 0, 0, 1);

            // Draw a white square (2x2 in world coords)
            GL.Color3(1.0f, 1.0f, 1.0f); // White color
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-1.0f, -1.0f); // Bottom-left
            GL.Vertex2(1.0f, -1.0f);  // Bottom-right
            GL.Vertex2(1.0f, 1.0f);   // Top-right
            GL.Vertex2(-1.0f, 1.0f);  // Top-left
            GL.End();
        }
    }

    // Simple Surface class to mimic pixel array (placeholder for 2D operations)
    public class Surface
    {
        public int[] pixels;
        public int width, height;

        public Surface(int width, int height)
        {
            this.width = width;
            this.height = height;
            pixels = new int[width * height];
        }
    }
}