
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MummyMazeBasic.Extentions
{
    public static class CheckRoad
    {
        public static bool isNotOverTop(Vector2 position, int space)
        {
            if (position.Y <= space)
            {
                return true;
            }
            return false;
        }

        public static bool isTouchingTop(Texture2D obj1, Texture2D obj2)
        {
            return false;
        }

        public static int indexOfButton()
        {
            if (Mouse.GetState().X >= 7 && Mouse.GetState().X <= 142
                    && Mouse.GetState().Y >= 430 && Mouse.GetState().Y <= 472)
            {
                return 5;
            }
            if (Mouse.GetState().X >= 7 && Mouse.GetState().X <= 142
                && Mouse.GetState().Y >= 130 && Mouse.GetState().Y <= 172)
            {
                return 1;
                //Get under move
            }
            if (Mouse.GetState().X >= 7 && Mouse.GetState().X <= 142
                && Mouse.GetState().Y >= 172 && Mouse.GetState().Y <= 214)
            {
                return 2;
                // Reset game
            }
            if (Mouse.GetState().X >= 7 && Mouse.GetState().X <= 142
                && Mouse.GetState().Y >= 225 && Mouse.GetState().Y <= 267)
            {
                return 3;
                //option 
            }
            if (Mouse.GetState().X >= 7 && Mouse.GetState().X <= 142
                && Mouse.GetState().Y >= 268 && Mouse.GetState().Y <= 310)
            {
                return 4;
                //World map
            }
            if (Mouse.GetState().X >= 7 && Mouse.GetState().X <= 142
                && Mouse.GetState().Y >= 268 && Mouse.GetState().Y <= 310)
            {

            }
            return 0;
        }

        public static Vector2 PositionInMap(Vector2 position)
        {
            Vector2 local = new Vector2(0, 0);
            local.X = 1 + Math.Abs(((position.X - (float)213) / (180 / GameMapManager.Instance.mapSize)) %
                (2 * GameMapManager.Instance.mapSize + 1));
            local.Y = 1 + Math.Abs(((position.Y - (float)79) / (180 / GameMapManager.Instance.mapSize)) %
                (2 * GameMapManager.Instance.mapSize + 1));
            return local;
        }

        public static CLocal Address(Vector2 position)
        {
            CLocal address = new CLocal();
            address.i = (int)(1 + Math.Abs(((position.X - (float)213) / (180 / GameMapManager.Instance.mapSize)) %
                (2 * GameMapManager.Instance.mapSize + 1)));
            address.j = (int)(1 + Math.Abs(((position.Y - (float)79) / (180 / GameMapManager.Instance.mapSize)) %
                (2 * GameMapManager.Instance.mapSize + 1)));
            return address;
        }

        public static void UpdatePosition(CLocal address, int index)
        {
            GameMapManager.Instance.localActor[index].i = address.i;
            GameMapManager.Instance.localActor[index].j = address.j;
        }
        public static bool MummyEatExplorer()
        {
            CLocal addressMummy = GameMapManager.Instance.localActor[1];
            CLocal addressMummyIntelligent = GameMapManager.Instance.localActor[2];
            CLocal addressExplorer = GameMapManager.Instance.localActor[0];
                if ((addressMummy.i == addressExplorer.i && addressMummy.j == addressExplorer.j)
                || (addressMummyIntelligent.i == addressExplorer.i
                && addressMummyIntelligent.j == addressExplorer.j))
            {
                GameMapManager.Instance.isGameOver = true;
                GameMapManager.Instance.isOptions = true;
                return true;
            }
            return false;
        }
        public static bool CanGoTop(Vector2 position, int level)
        {
            int valueInArr = GameMapManager.Instance.map[limitMin((int)position.Y - 1, 0)][(int)position.X];
            return (valueInArr != 1) && (valueInArr != 3);
        }
        public static bool CanGoBot(Vector2 position, int level)
        {
            int valueInArr = GameMapManager.Instance.map[limitMax((int)position.Y,
                             GameMapManager.Instance.mapSize * 2)][(int)position.X];
            return (valueInArr != 1) && (valueInArr != 3);
        }
        public static bool CanGoLeft(Vector2 position, int level)
        {
            int valueInArr = GameMapManager.Instance.map[(int)(position.Y)][limitMin((int)position.X - 1, 0)];
            return (valueInArr != 2) && (valueInArr != 3);
        }
        public static bool CanGoRight(Vector2 position, int level)
        {
            int valueInArr = GameMapManager.Instance.map[(int)position.Y][(int)position.X];
            return (valueInArr != 2) && (valueInArr != 3);
        }
        public static int limitMax(int before, int limitMax)
        {
            return Math.Min(before, limitMax);
        }
        public static int limitMin(int before, int limitMin)
        {
            return Math.Max(before, limitMin);
        }
        public static float moveSize()
        {
            if (GameMapManager.Instance.mapSize != 0)
            {
                return (float)45 / GameMapManager.Instance.mapSize;
            }
            return 0;
        }
        public static int[] randInOut()
        {
            int[] vectorIn = new int[2];
            Random rand = new Random();
            int randNum = rand.Next(0, 100) % 2;
            if (randNum == 1)
            {
                randNum = rand.Next(0, 100) % (GameMapManager.Instance.mapSize * 2 + 1);
                vectorIn[0] = 0;
                vectorIn[1] = randNum;
            }
            else
            {
                randNum = rand.Next(0, 100) % (GameMapManager.Instance.mapSize * 2 + 1);
                vectorIn[0] = randNum;
                vectorIn[1] = 0;
            }
            return vectorIn;
        }
        public static int randDirection()
        {
            Random rand = new Random();
            return rand.Next(0, 100) % 4 + 1;
        }
    }
}