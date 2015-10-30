using amulware.Graphics;
using amulware.Graphics.Meshes;
using Bearded.Utilities.SpaceTime;
using OpenTK;

namespace Game
{
    class MeshInstance : GameObject
    {
        private MeshSurfaceInstance instance;

        public MeshInstance(GameState game,
            Surface meshSurface, Matrix4Uniform transformUniform, Vector3 position, float scale)
            : base(game)
        {
            this.instance = new MeshSurfaceInstance(meshSurface, transformUniform)
            {
                Translation = position,
                Scale = scale,
            };
        }

        public override void Update(TimeSpan elapsedTime)
        {
        }

        public override void Draw()
        {
            this.instance.Render();
        }
    }
}