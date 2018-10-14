using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Rectangular3D
{
    public class GameController
    {
        private static GameController instance;
        private Sprite3D rect3D;
        public ContentManager Content { get; set; }
        public static GameController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameController();
                }
                return instance;
            }
        }

        public GameController()
        {
            rect3D = new Rectangle3D();
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            rect3D.LoadContent();
        }

        public void UploadConten()
        {
            rect3D.UploadConten();
        }

        public void Update(GameTime gameTime)
        {
            rect3D.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rect3D.Draw(spriteBatch);
        }
    }
}

