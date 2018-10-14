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
    public class OverGame : Options
    {
        float elapsed;
        public override void LoadContent()
        {
            base.LoadContent();
            path = "_gameovertext";
            image = content.Load<Texture2D>(path);
            position = new Vector2(213, 0);
            desRect = new Rectangle((int)position.X, (int)position.Y, 360, 83);
            sourRect = new Rectangle(0, 0, 493, 83);
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
                position.Y = 0;
            }
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed > 10f && position.Y < 360)
            {
                position.Y += 7;
                desRect = new Rectangle((int)position.X, (int)position.Y, 360, 83);
                elapsed = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, desRect, sourRect, Color.White);
        }
    }
}
