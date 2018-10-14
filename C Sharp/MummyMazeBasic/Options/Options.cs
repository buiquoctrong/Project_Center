using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MummyMazeBasic
{
    public class Options
    {
        protected ContentManager content;
        protected Texture2D image;
        protected string path;
        protected Rectangle desRect;
        protected Rectangle sourRect;
        protected Vector2 position;

        public virtual void LoadContent()
        {
            content = new ContentManager(
                ScreenManager.Instance.Content.ServiceProvider, "Content"); 
        }

        public virtual void UploadConten()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
