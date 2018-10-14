using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MummyMazeBasic.Extentions;

namespace MummyMazeBasic
{
    public class ButtonStrip : ScreenBackground
    {
        List<Rectangle> listMenu = new List<Rectangle>();
        List<Rectangle> positionMenu = new List<Rectangle>();
        List<Rectangle> showMenu = new List<Rectangle>();
        public override void LoadContent()
        {
            base.LoadContent();
            path = "buttonstrip";
            image = content.Load<Texture2D>(path);

            position = new Vector2(0, 0);
            for (int i = 0; i <= 10; i++)
            {
                sourRect = new Rectangle(0, i * 42, 135, 42);
                listMenu.Add(sourRect);
            }
            desRect = new Rectangle(7, 130, 135, 42);
            positionMenu.Add(desRect);
            desRect = new Rectangle(7, 172, 135, 42);
            positionMenu.Add(desRect);
            desRect = new Rectangle(7, 225, 135, 42);
            positionMenu.Add(desRect);
            desRect = new Rectangle(7, 268, 135, 42);
            positionMenu.Add(desRect);
            desRect = new Rectangle(7, 430, 135, 42);
            positionMenu.Add(desRect);
            // add
            showMenu.Add(listMenu[0]);
            showMenu.Add(listMenu[2]);
            showMenu.Add(listMenu[4]);
            showMenu.Add(listMenu[6]);
            showMenu.Add(listMenu[10]);
        }

        public override void UploadConten()
        {
            base.UploadConten();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                System.Console.Write(Mouse.GetState().X + Mouse.GetState().Y);
                switch (CheckRoad.indexOfButton())
                {
                    case 1:
                        // undo
                        break;
                    case 2:
                        // reset game
                        GameMapManager.Instance.isNewMap = true;
                        GameMapManager.Instance.isNewActor = true;
                        GameMapManager.Instance.isNewMummy = true;
                        GameMapManager.Instance.isNewMummyIn = true;
                        break;
                    case 3:
                        // option
                        if (GameMapManager.Instance.isButtonOption)
                        {
                            GameMapManager.Instance.isGameOptionsScroll = true;
                            GameMapManager.Instance.isOptions = true;
                            GameMapManager.Instance.isButtonOption = false;
                        }
                        break;
                    case 4:
                        // world map
                        break;
                    case 5:
                        MainGame.self.Exit();
                        break;
                }
            }
            else
            {
                switch (CheckRoad.indexOfButton())
                {
                    case 1:
                        showMenu[0] = listMenu[1];
                        break;
                    case 2:
                        showMenu[1] = listMenu[3];
                        break;
                    case 3:
                        showMenu[2] = listMenu[5];
                        break;
                    case 4:
                        showMenu[3] = listMenu[7];
                        break;
                    case 5:
                        showMenu[4] = listMenu[10];
                        break;
                    default:
                        showMenu[0] = listMenu[0];
                        showMenu[1] = listMenu[2];
                        showMenu[2] = listMenu[4];
                        showMenu[3] = listMenu[6];
                        showMenu[4] = listMenu[9];
                        break;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(image, positionMenu[0], showMenu[0],  Color.White);
            spriteBatch.Draw(image, positionMenu[1], showMenu[1], Color.White);
            spriteBatch.Draw(image, positionMenu[2], showMenu[2], Color.White);
            //spriteBatch.Draw(image, positionMenu[3], showMenu[3],  Color.White);
            spriteBatch.Draw(image, positionMenu[4], showMenu[4], Color.White);
        }
    }
}
