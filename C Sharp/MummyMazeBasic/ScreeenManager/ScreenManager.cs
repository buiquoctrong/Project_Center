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
    public class ScreenManager
    {
        private static ScreenManager instance;

        ScreenBackground currentBackground;
        ScreenBackground backDrop;
        ScreenBackground buttonStrip;

        public ContentManager Content { get; set; }

        public static ScreenManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }

        public ScreenManager()
        {
            currentBackground = new SplashBackground();
            backDrop = new BackDrop();
            buttonStrip = new ButtonStrip();
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentBackground.LoadContent();
            backDrop.LoadContent();
            buttonStrip.LoadContent();
        }

        public void UploadConten()
        {
            currentBackground.UploadConten();
            backDrop.UploadConten();
            buttonStrip.UploadConten();

        }

        public void Update(GameTime gameTime)
        {
            backDrop.Update(gameTime);
            currentBackground.Update(gameTime);
            buttonStrip.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backDrop.Draw(spriteBatch);
            currentBackground.Draw(spriteBatch);
            buttonStrip.Draw(spriteBatch);
        }
    }
}

