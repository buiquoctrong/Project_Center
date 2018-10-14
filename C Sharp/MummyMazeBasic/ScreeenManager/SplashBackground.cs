using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MummyMazeBasic
{
    public class SplashBackground: ScreenBackground
    {
        private Song backgroundMusic;
        public override void LoadContent()
        {
            base.LoadContent();
            path = "floor8";
            image = content.Load<Texture2D>(path);
            position = new Vector2(213, 79);
            desRect = new Rectangle((int)position.X, (int)position.Y, 360/GameMapManager.Instance.mapSize,
                                     360/ GameMapManager.Instance.mapSize);
            sourRect = new Rectangle(0, 0, 90, 90);
            path = "BackgroundMusic";
            backgroundMusic = content.Load<Song>(path);
            MediaPlayer.Play(backgroundMusic);
        }

        public override void UploadConten()
        {
            base.UploadConten();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    position = new Vector2(213 + i * 360/ mapSize,79 + j* 360/mapSize);
                    desRect = new Rectangle((int)position.X, (int)position.Y, 360 / mapSize, 360 / mapSize);
                    spriteBatch.Draw(image, desRect, sourRect, Color.White);
                }
            }
            
        }
    }
}
