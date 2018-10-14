using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MummyMazeBasic
{
    public class BackOptions : Options
    {
        float elapsed;
        public override void LoadContent()
        {
            base.LoadContent();
            path = "menuback";
            image = content.Load<Texture2D>(path);
            //position = new Vector2(150, -400);
            position = new Vector2(150, 0);
            desRect = new Rectangle((int)position.X, (int)position.Y, 600, 480);
            sourRect = new Rectangle(0, 0, 640, 480);
        }

        public override void UploadConten()
        {
            base.UploadConten();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (GameMapManager.Instance.isOptions)
            {
                //position.Y = -400;
                position.Y = 0;
                GameMapManager.Instance.isOptions = false;
            }
            //elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //if (elapsed >10f && position.Y < 0)
            //{
               // position.Y += 7;
                desRect = new Rectangle((int)position.X, (int)position.Y, 480, 480);
            //elapsed = 0;
            // }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, desRect, sourRect, Color.White);
        }
    }
}
