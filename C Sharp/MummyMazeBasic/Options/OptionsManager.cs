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
    public class OptionsManager
    {
        private static OptionsManager instance;

        Options gameover;
        Options backOptios;
        Options gameOptions;
        Options mouse;
        Options buttonOKCANCEL;

        public ContentManager Content { get; set; }

        public static OptionsManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new OptionsManager();
                }
                return instance;
            }
        }

        public OptionsManager()
        {
            gameover = new OverGame();
            backOptios = new BackOptions();
            gameOptions = new GameOptions();
            mouse = new MousePointer();
            buttonOKCANCEL = new ButtonOKCANCEL();
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            gameover.LoadContent();
            backOptios.LoadContent();
            gameOptions.LoadContent();
            mouse.LoadContent();
            buttonOKCANCEL.LoadContent();
        }

        public void UploadConten()
        {
            gameover.UploadConten();
            backOptios.UploadConten();
            gameOptions.UploadConten();
            mouse.UploadConten();
            buttonOKCANCEL.UploadConten();
        }

        public void Update(GameTime gameTime)
        {
            gameover.Update(gameTime);
            backOptios.Update(gameTime);
            gameOptions.Update(gameTime);
            mouse.Update(gameTime);
            buttonOKCANCEL.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (GameMapManager.Instance.isGameOver)
            {
                backOptios.Draw(spriteBatch);
                gameover.Draw(spriteBatch);
            }
            if (!GameMapManager.Instance.isButtonOption)
            {
                backOptios.Draw(spriteBatch);
                gameOptions.Draw(spriteBatch);
                buttonOKCANCEL.Draw(spriteBatch);
            }
            mouse.Draw(spriteBatch);
        }
    }
}

