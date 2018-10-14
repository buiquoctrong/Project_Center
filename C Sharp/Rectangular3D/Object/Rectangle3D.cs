using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Rectangular3D
{
    public class Rectangle3D : Sprite3D
    {
        private KeyboardState keyState;
        private VertexPositionTexture[] verticesTex;
        private VertexPositionColor[] verticesColor;
        private int[] indices;
        private VertexBuffer vertexBuffer;
        private IndexBuffer indexBuffer;
        private BasicEffect basicEffect;
        //Matriz
        private Matrix view;
        private Matrix projection;
        private Matrix world;
        //camera
        private Vector3 cameraPosition = new Vector3(2.0f, 5.0f, 5.0f);
        private Vector3 cameraTarget = Vector3.Zero;
        private Vector3 cameraUp = Vector3.Up;
        public override void LoadContent()
        {
            base.LoadContent();
            //initial BasicEffect
            basicEffect = new BasicEffect(MainGame.self.GraphicsDevice);
            // initial 6 faces
            _faces = new Texture2D[6];
            _path = "faces1";
            _faces[0] = _content.Load<Texture2D>(_path);
            _faces[1] = _content.Load<Texture2D>("faces2");
            _faces[2] = _content.Load<Texture2D>("faces3");
            _faces[3] = _content.Load<Texture2D>("faces4");
            _faces[4] = _content.Load<Texture2D>("faces5");
            _faces[5] = _content.Load<Texture2D>("faces6");
            //initial rotate
            _rotateZ = 0.0f;
            _rotateY = 0.0f;

            // initial texture
            CreateIndexedCubeTextured();

            //initial camera
            CreateCamera();

            
        }
        public override void UploadConten()
        {
            base.UploadConten();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
            {
                _rotateY += 0.05f;
            }
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
            {
                _rotateY -= 0.05f;
            }
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                _rotateZ += 0.05f;
            }
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                _rotateZ -= 0.05f;
            }
            if (keyState.IsKeyDown(Keys.X))
            {
                _faces[0] = _content.Load<Texture2D>("texture");
                _faces[1] = _content.Load<Texture2D>("texture");
                _faces[2] = _content.Load<Texture2D>("texture");
                _faces[3] = _content.Load<Texture2D>("texture");
                _faces[4] = _content.Load<Texture2D>("texture");
                _faces[5] = _content.Load<Texture2D>("texture");
            }

            if (keyState.IsKeyDown(Keys.Z))
            {
                _faces[0] = _content.Load<Texture2D>(_path);
                _faces[1] = _content.Load<Texture2D>("faces2");
                _faces[2] = _content.Load<Texture2D>("faces3");
                _faces[3] = _content.Load<Texture2D>("faces4");
                _faces[4] = _content.Load<Texture2D>("faces5");
                _faces[5] = _content.Load<Texture2D>("faces6");
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            basicEffect.View = view;
            basicEffect.Projection = projection;
            basicEffect.World = world * Matrix.CreateRotationY(_rotateY) * Matrix.CreateRotationZ(_rotateZ);
            basicEffect.VertexColorEnabled = false;
            basicEffect.TextureEnabled = true;

            for (int i = 0; i < 6; i++)
            {
                basicEffect.Texture = _faces[i];
                foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    MainGame.self.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList,
                     verticesTex, 0, verticesTex.Length, indices, i * 6, 2);
                }
            }
        }
        private void CreateIndexedCubeTextured()
        {
            verticesTex = new VertexPositionTexture[]
            {
                new VertexPositionTexture( new Vector3(1 , 1 , -1)    ,new Vector2(1,0)),
                new VertexPositionTexture( new Vector3(1 , -1 , -1)   ,new Vector2(1,1)),
                new VertexPositionTexture( new Vector3(-1 , -1 , -1)  ,new Vector2(0,1)),
                new VertexPositionTexture( new Vector3(-1 , 1 , -1)   ,new Vector2(0,0)),
                new VertexPositionTexture( new Vector3(1 , 1 , 1)     ,new Vector2(1,0)),
                new VertexPositionTexture( new Vector3(-1 , 1 , 1)    ,new Vector2(1,1)),
                new VertexPositionTexture( new Vector3(-1 , -1 , 1)   ,new Vector2(0,1)),
                new VertexPositionTexture( new Vector3(1 , -1 , 1)    ,new Vector2(0,0)),
                new VertexPositionTexture( new Vector3(1 , 1 , -1)    ,new Vector2(1,0)),
                new VertexPositionTexture( new Vector3(1 , 1 , 1)     ,new Vector2(1,1)),
                new VertexPositionTexture( new Vector3(1 , -1 , 1)    ,new Vector2(0,1)),
                new VertexPositionTexture( new Vector3(1 , -1 , -1)   ,new Vector2(0,0)),
                new VertexPositionTexture( new Vector3(1 , -1 , -1)   ,new Vector2(1,0)),
                new VertexPositionTexture( new Vector3(1 , -1 , 1)    ,new Vector2(1,1)),
                new VertexPositionTexture( new Vector3(-1 , -1 , 1)   ,new Vector2(0,1)),
                new VertexPositionTexture( new Vector3(-1 , -1 , -1)  ,new Vector2(0,0)),
                new VertexPositionTexture( new Vector3(-1 , -1 , -1)  ,new Vector2(1,0)),
                new VertexPositionTexture( new Vector3(-1 , -1 , 1)   ,new Vector2(1,1)),
                new VertexPositionTexture( new Vector3(-1 , 1 , 1)    ,new Vector2(0,1)),
                new VertexPositionTexture( new Vector3(-1 , 1 , -1)   ,new Vector2(0,0)),
                new VertexPositionTexture( new Vector3(1 , 1 , 1)     ,new Vector2(1,0)),
                new VertexPositionTexture( new Vector3(1 , 1 , -1)    ,new Vector2(1,1)),
                new VertexPositionTexture( new Vector3(-1 , 1 , -1)   ,new Vector2(0,1)),
                new VertexPositionTexture( new Vector3(-1 , 1 , 1)    ,new Vector2(0,0))
            };
            //initial indices
            indices = new int[]
            {
                 0, 3, 2, 0, 2, 1,
                 4, 7, 6, 4,6, 5,
                8, 11, 10,8,10, 9,
                12, 15, 14, 12, 14, 13,
                16, 19, 18,16,18, 17,
                20, 23, 22,20,22, 21
            };

            vertexBuffer = new VertexBuffer(MainGame.self.GraphicsDevice, typeof(VertexPositionTexture),
                                            verticesTex.Length, BufferUsage.WriteOnly);
            vertexBuffer.SetData(verticesTex);
            indexBuffer = new IndexBuffer(MainGame.self.GraphicsDevice,
                                          IndexElementSize.ThirtyTwoBits, indices.Length, BufferUsage.WriteOnly);
            indexBuffer.SetData(indices);

            MainGame.self.GraphicsDevice.SetVertexBuffer(vertexBuffer);
        }
        private void CreateCamera()
        {
            view = Matrix.CreateLookAt(cameraPosition, cameraTarget, cameraUp);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 
                         MainGame.self.GraphicsDevice.Viewport.Width /
                         MainGame.self.GraphicsDevice.Viewport.Height,
                         0.01f, 1000.0f);
            world = Matrix.Identity;
        }
    }
}