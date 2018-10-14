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
    public class Walls : Map
    {
        public override void LoadContent()
        {
            base.LoadContent();
            path = "walls8";
            image = content.Load<Texture2D>(path);
            path = "stairs8";
            door = content.Load<Texture2D>(path);
            position = new Vector2(100, 100);
            desRect = new Rectangle((int)position.X, (int)position.Y,
                                    (180 / GameMapManager.Instance.mapSize),
                                    14 * 4 / GameMapManager.Instance.mapSize);
            sourRect = new Rectangle(12, 0, 45, 14);
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
            if (maze[2 * GameMapManager.Instance.mapSize] !=null)
            {

            for (int i = 1; i < 2 * GameMapManager.Instance.mapSize + 1; i++)
            {
                for (int j = 1; j < 2 * GameMapManager.Instance.mapSize + 1; j++)
                {
                    //213, 79 , 45 ,36
                   // if (maze[i][j])
                //    {
                        if (maze[i][j] == 1 || maze[i][j] == 3)
                        {
                            position = new Vector2(213 + 181 / GameMapManager.Instance.mapSize * (j - 1),
                                                   79 - (182 / GameMapManager.Instance.mapSize) / 8 + (180 / GameMapManager.Instance.mapSize) * (i));
                            desRect = new Rectangle((int)position.X, (int)position.Y,
                                                   (180 / GameMapManager.Instance.mapSize) + 1,
                                                   14 * 4 / GameMapManager.Instance.mapSize);
                            sourRect = new Rectangle(12, 0, 45, 14);
                            spriteBatch.Draw(image, desRect, sourRect, Color.White);
                        }
                        if (maze[i][j] == 2 || maze[i][j] == 3)
                        {
                            position = new Vector2(212 + 182 / GameMapManager.Instance.mapSize * (j),
                                                   79 + 181 / GameMapManager.Instance.mapSize * (i - 1));
                            desRect = new Rectangle((int)position.X, (int)position.Y,
                                                    12 * 4 / GameMapManager.Instance.mapSize,
                                                    (180 / GameMapManager.Instance.mapSize) + 1);
                            sourRect = new Rectangle(0, 0, 12, 63);
                            spriteBatch.Draw(image, desRect, sourRect, Color.White);
                        }
                        if (maze[i][j] == 4 || maze[i][j] == 5)
                        {

                            if (j == 2 * GameMapManager.Instance.mapSize)
                            {//214, 73
                                position = new Vector2(214
                                                       + (180 / GameMapManager.Instance.mapSize) * (j),
                                                       73 + (180 / GameMapManager.Instance.mapSize) * (i - 1));
                                desRect = new Rectangle((int)position.X, (int)position.Y,
                                                            53 / 45 * (180 / GameMapManager.Instance.mapSize),
                                                            51 / 45 * (180 / GameMapManager.Instance.mapSize));
                                sourRect = new Rectangle(45, 0, 53, 51);
                            }
                            else
                            {
                                if (j == 1)
                                {
                                    position = new Vector2(215 - (180 / GameMapManager.Instance.mapSize),
                                                           73 + (180 / GameMapManager.Instance.mapSize) * (i - 1));
                                    desRect = new Rectangle((int)position.X, (int)position.Y,
                                                            53 / 45 * (180 / GameMapManager.Instance.mapSize),
                                                            51 / 45 * (180 / GameMapManager.Instance.mapSize));
                                    sourRect = new Rectangle(141, 0, 53, 51);
                                }
                                else
                                {
                                    if (i == 2 * GameMapManager.Instance.mapSize)
                                    {
                                        position = new Vector2(215 + (180 / GameMapManager.Instance.mapSize) * (j),
                                                               78 + (180 / GameMapManager.Instance.mapSize) * (i));/// 45 * (180 / GameMapManager.Instance.mapSize)
                                        desRect = new Rectangle((int)position.X, (int)position.Y,
                                                                (int)((float)35 / 45 * (180 / GameMapManager.Instance.mapSize)),
                                                                (int)((float)35 / 45 * (180 / GameMapManager.Instance.mapSize)));
                                        sourRect = new Rectangle(100, 0, 35, 39);
                                    }

                                    else
                                    {
                                        if (i == 1)
                                        {
                                            position = new Vector2(217 + (180 / GameMapManager.Instance.mapSize) * (j - 1),
                                                                   20 + (int)(float)(20 / 45 * (180 / GameMapManager.Instance.mapSize)));

                                            desRect = new Rectangle((int)position.X, (int)position.Y,
                                                                    (int)((float)38 / 45 * (180 / GameMapManager.Instance.mapSize)),
                                                                    (int)(180 / GameMapManager.Instance.mapSize));
                                            sourRect = new Rectangle(3, 0, 38, 66);
                                        }
                                    }
                                }
                            }
                            spriteBatch.Draw(door, desRect, sourRect, Color.White);
                        }
                    }
                }
            }
        }
    }
}
