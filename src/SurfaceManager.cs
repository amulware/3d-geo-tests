using amulware.Graphics;
using amulware.Graphics.Meshes;
using amulware.Graphics.Meshes.ObjFile;
using amulware.Graphics.ShaderManagement;
using Bearded.Utilities;

namespace Game
{
    sealed class SurfaceManager : Singleton<SurfaceManager>
    {
        public Matrix4Uniform ProjectionMatrix { get; private set; }
        public Matrix4Uniform ModelviewMatrix { get; private set; }

        public IndexedSurface<PrimitiveVertexData> Primitives { get; private set; }
        public IndexedSurface<UVColorVertexData> Text { get; private set; }

        public IndexedSurface<MeshVertex> Mesh { get; private set; }
        public Matrix4Uniform MeshTransform { get; private set; }

        public SurfaceManager(ShaderManager shaderMan)
        {
            // matrices
            this.ProjectionMatrix = new Matrix4Uniform("projectionMatrix");
            this.ModelviewMatrix = new Matrix4Uniform("modelviewMatrix");
            this.MeshTransform = new Matrix4Uniform("meshTransform");

            // create shaders
            shaderMan.MakeShaderProgram("primitives");
            shaderMan.MakeShaderProgram("uvcolor");
            shaderMan.MakeShaderProgram("mesh");

            // surfaces
            this.Primitives = new IndexedSurface<PrimitiveVertexData>();
            this.Primitives.AddSettings(this.ProjectionMatrix, this.ModelviewMatrix);
            shaderMan["primitives"].UseOnSurface(this.Primitives);

            this.Text = new IndexedSurface<UVColorVertexData>();
            this.Text.AddSettings(this.ProjectionMatrix, this.ModelviewMatrix,
                new TextureUniform("diffuseTexture", new Texture("data/fonts/inconsolata.png", true)));
            shaderMan["uvcolor"].UseOnSurface(this.Text);


            var obj = ObjFileMesh.FromFile("data/obj/teapot.obj");

            var mesh = obj.ToMesh();

            this.Mesh = mesh.ToIndexedSurface<MeshVertex>();
            this.Mesh.AddSettings(this.ProjectionMatrix, this.ModelviewMatrix, this.MeshTransform);
            this.Mesh.ClearOnRender = false;
            shaderMan["mesh"].UseOnSurface(this.Mesh);

        }
    }
}