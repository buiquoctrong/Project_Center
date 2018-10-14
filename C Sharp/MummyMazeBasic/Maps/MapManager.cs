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

namespace MummyMazeBasic
{
    public class MapManager
    {
        private static MapManager instance;

        public Map walls { get; set; }
        public ContentManager Content { get; set; }

        public static MapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapManager();
                }
                return instance;
            }
        }

        public MapManager()
        {
            walls = new Walls();
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            walls.LoadContent();
        }

        public void UploadConten()
        {
            walls.UploadConten();
        }

        public void Update(GameTime gameTime)
        {
            walls.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            walls.Draw(spriteBatch);
        }
    }
}

