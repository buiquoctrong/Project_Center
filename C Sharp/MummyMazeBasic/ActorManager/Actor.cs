using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MummyMazeBasic.Extentions;
namespace MummyMazeBasic
{
    public class Actor
    {

        //attributes
        protected ContentManager content;
        protected Texture2D actor;
        protected string path;
        protected Rectangle desRect;
        protected Rectangle sourRect;
        protected Vector2 position;
        protected bool disableKey;
        protected Vector2 local;
        protected static int gameLevel;
        protected float moveSize = 11.25f;
        protected const float Xstart = 213;
        protected const float Xend = 563;
        protected const float Ystart = 79;
        protected const float Yend = 429;
        //method
        public virtual void LoadContent()
        {
            content = new ContentManager(
                ActorManager.Instance.Content.ServiceProvider, "Content");
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
        public virtual Vector2 Local()
        {
            return local;
        }
    }
}
