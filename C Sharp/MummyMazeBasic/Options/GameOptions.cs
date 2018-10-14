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
    public class GameOptions : Options
    {
        float elapsed;
        private SpriteFont font;

        public override void LoadContent()
        {
            base.LoadContent();
            path = "menufront";
            image = content.Load<Texture2D>(path);
            path = "ButtonFont";
            font = content.Load<SpriteFont>(path);
            position = new Vector2(155, -600);
            desRect = new Rectangle((int)position.X, (int)position.Y, 400, 400);
            sourRect = new Rectangle(0, 0, 640, 476);
        }

        public override void UploadConten()
        {
            base.UploadConten();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (GameMapManager.Instance.isGameOptionsScroll)
            {
                position.Y = -600;
                GameMapManager.Instance.isGameOptionsScroll = false;
            }
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed > 10f && position.Y < 0)
            {
                position.Y += 7;
                desRect = new Rectangle((int)position.X, (int)position.Y, 480, 400);
                elapsed = 0;
            }
            else
            {
                if (position.Y >= 0)
                {
                    GameMapManager.Instance.isWriteText = true;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, desRect, sourRect, Color.White);
        }
    }
}
