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
    public class ActorManager
    {
        private static ActorManager instance;

        // List of actor
        Actor mummyStupid;
        Actor explorer;
        Actor mummyIntelligent;
        public int[][] local;
        //Content manager
        public ContentManager Content { get; set; }

        /// <summary>
        /// Output instance
        /// </summary>
        public static ActorManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActorManager();
                }
                return instance;
            }
        }

        /// <summary>
        /// Initial actor
        /// </summary>
        public ActorManager()
        {
            explorer = new Explorer();
            mummyStupid = new Mummy();
            mummyIntelligent = new MummyIntelligent();

        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            explorer.LoadContent();
            mummyIntelligent.LoadContent();
            mummyStupid.LoadContent();
        }

        public void UploadConten()
        {
            explorer.UploadConten();
            mummyIntelligent.UploadConten();
            mummyStupid.UploadConten();
        }

        public void Update(GameTime gameTime)
        {
            explorer.Update(gameTime);
            mummyIntelligent.Update(gameTime);
            mummyStupid.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            explorer.Draw(spriteBatch);
            mummyIntelligent.Draw(spriteBatch);
            mummyStupid.Draw(spriteBatch);
        }
    }
}

