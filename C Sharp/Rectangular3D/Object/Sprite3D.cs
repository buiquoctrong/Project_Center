using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Rectangular3D
{
    public class Sprite3D
    {
        private static Sprite3D instance;
        //attributes
        protected ContentManager _content;
        protected string _path;
        protected Vector3 _sprite3D;
        protected Rectangle _desRect;
        protected Rectangle _sourRect;
        protected Vector2 _position;
        protected Texture2D[] _faces;
        protected float _rotateZ;
        protected float _rotateY;
       // protected ContentManager Content { get => _content; set => _content = value; }

        //method
        public virtual void LoadContent()
        {
            _content = new ContentManager(
                GameController.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UploadConten()
        {
            _content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
