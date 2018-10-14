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
    public class ScreenBackground
    {
        protected ContentManager content;
        protected Texture2D image;
        protected string path;
        protected Rectangle desRect;
        protected Rectangle sourRect;
        protected Vector2 position;
        protected int mapSize;
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
            mapSize = GameMapManager.Instance.mapSize;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
