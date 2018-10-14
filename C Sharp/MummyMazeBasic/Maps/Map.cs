using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MummyMazeBasic.Extentions;

namespace MummyMazeBasic
{
    public class Map
    {
        CLocal actorLocal = new CLocal();
        protected ContentManager content;
        protected Texture2D image;
        protected Texture2D door;
        protected string path;
        protected Rectangle desRect;
        protected Rectangle sourRect;
        protected Vector2 position;
        public int[][] maze;
        Random rand = new Random();
        public Map()
        {
            maze = new int[2 * GameMapManager.Instance.mapSize + 2][];
            SetMap();
            GameMapManager.Instance.map = maze;
            position = new Vector2(0, 0);
        }
        public virtual void LoadContent()
        {
            content = new ContentManager(
                ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UploadConten()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
            if (GameMapManager.Instance.isNewMap)
            {
                GameMapManager.Instance.mapSize = GameMapManager.Instance.mapsizeTemp;
                maze = new int[2 * GameMapManager.Instance.mapSize + 2][];
                GameMapManager.Instance.isNewMap = false;
                SetMap();
                GameMapManager.Instance.map = maze;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
        /// <summary>
        /// 1: Wall in Bot
        /// 2: Wall in Right
        /// 3: Wall in Bot and Right
        /// 4: In 
        /// 5: Out
        /// </summary>
        public void SetMap()
        {
            Random rand = new Random();
            for (int i = 0; i <= 2 * GameMapManager.Instance.mapSize + 1; i++)
            {
                maze[i] = new int[2 * GameMapManager.Instance.mapSize + 2];
                for (int j = 0; j <= 2 * GameMapManager.Instance.mapSize + 1; j++)
                {

                    maze[i][j] = rand.Next(0, 100) % 4;
                    if (j == 2 * GameMapManager.Instance.mapSize)
                    {
                        while (maze[i][j] == 2 || maze[i][j] == 3)
                        {
                            maze[i][j] = rand.Next(0, 100) % 4;
                        }
                    }
                    if (i == 2 * GameMapManager.Instance.mapSize)
                    {
                        while (maze[i][j] == 1 || maze[i][j] == 3)
                        {
                            maze[i][j] = rand.Next(0, 100) % 4;
                        }
                    }
                }
            }
            // create way
            int[] wayIn = new int[2];
            int[] wayOut = new int[2];

            wayIn[0] = randDirection();
            wayIn[1] = 1;

            wayOut[0] = randDirection();
            wayOut[1] = 2 * GameMapManager.Instance.mapSize;

            maze[wayIn[0]][wayIn[1]] = 4; //In
            maze[wayOut[0]][wayOut[1]] = 5;//Out
            if (GameMapManager.Instance.localActor == null)
            {
                GameMapManager.Instance.localActor = new List<CLocal>();
            }
            GameMapManager.Instance.randomPosition();
            // Explorer local
            actorLocal.i = wayIn[0];
            actorLocal.j = wayIn[1];
            GameMapManager.Instance.localActor.Insert(0, actorLocal);

            if (GameMapManager.Instance.theWay.Count != 0)
            {
                GameMapManager.Instance.theWay.Clear();
            }
            GameMapManager.Instance.theWay.Add(wayIn);
            //while (!((int)wayIn[0] == (int)wayOut[0]
            //         && (int)wayIn[1] == (int)wayOut[1]))
            //{
            //    switch (way)
            //    {
            //        case 1: //up
            //            if (wayIn[0] - 1 >= 0)
            //            {
            //                wayIn[0] -= 1;
            //                GameMapManager.Instance.theWay.Add(wayIn);
            //                maze[wayIn[0]][wayIn[1]] = 0;
            //            }
            //            break;
            //        case 2: //right
            //            if (wayIn[1] + 1 <= 2 * GameMapManager.Instance.mapSize)
            //            {
            //                wayIn[1] += 1;
            //                GameMapManager.Instance.theWay.Add(wayIn);
            //                maze[wayIn[0]][wayIn[1]] = 0;
            //            }
            //            break;
            //        case 3: // down
            //            if (wayIn[0] + 1 <= 2 * GameMapManager.Instance.mapSize)
            //            {
            //                wayIn[0] += 1;
            //                GameMapManager.Instance.theWay.Add(wayIn);
            //                maze[wayIn[0]][wayIn[1]] = 0;
            //            }
            //            break;
            //        case 4: // left
            //            if (wayIn[1] - 1 >= 0)
            //            {
            //                wayIn[1] -= 1;
            //                GameMapManager.Instance.theWay.Add(wayIn);
            //                maze[wayIn[0]][wayIn[1]] = 0;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }
        public int[] randInOut()
        {
            int[] vectorIn = new int[2];
            int randNum = rand.Next(0, 100) % 2;
            if (randNum == 1)
            {
                randNum = rand.Next(0, 100) % (GameMapManager.Instance.mapSize * 2 + 1);
                int m = rand.Next(0, 100) % 1;
                if (m == 1)
                {
                    vectorIn[0] = GameMapManager.Instance.mapSize * 2;
                }
                else
                {
                    vectorIn[0] = 1;
                }
                vectorIn[1] = randNum;
            }
            else
            {
                randNum = rand.Next(0, 100) % (GameMapManager.Instance.mapSize * 2 + 1);
                int m = rand.Next(0, 100) % 1;
                if (m == 0)
                {
                    vectorIn[1] = GameMapManager.Instance.mapSize * 2;
                }
                else
                {
                    vectorIn[1] = 1;
                }
                vectorIn[0] = randNum;
            }
            return vectorIn;
        }

        public int randDirection()
        {
            return rand.Next(0, 100) % (GameMapManager.Instance.mapSize * 2) + 1;
        }
    }
}
