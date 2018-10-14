using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MummyMazeBasic
{
    public class BackDrop : ScreenBackground
    {
        public override void LoadContent()
        {
            base.LoadContent();
            path = "backdrop";
            image = content.Load<Texture2D>(path);
            position = new Vector2(0, 0);
            desRect = new Rectangle((int)position.X, (int)position.Y, 640,480);
            sourRect = new Rectangle(0, 0, 640, 480);
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
            spriteBatch.Draw(image, desRect, sourRect, Color.White);
        }
    }
}
