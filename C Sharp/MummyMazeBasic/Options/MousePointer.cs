using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MummyMazeBasic
{
    public class MousePointer : Options
    {
        public override void LoadContent()
        {
            base.LoadContent();
            path = "pointer";
            image = content.Load<Texture2D>(path);
            position = new Vector2(-27, -27);
            desRect = new Rectangle((int)position.X, (int)position.Y, 54, 54);
            sourRect = new Rectangle(0, 0, 54, 54);
        }

        public override void UploadConten()
        {
            base.UploadConten();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            position = new Vector2(Mouse.GetState().X - 27, Mouse.GetState().Y - 27);
            desRect = new Rectangle((int)position.X, (int)position.Y, 54, 54);
            sourRect = new Rectangle(0, 0, 54, 54);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, desRect, sourRect, Color.White);
        }
    }
}
