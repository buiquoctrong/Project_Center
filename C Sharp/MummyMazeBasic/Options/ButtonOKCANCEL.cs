using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MummyMazeBasic
{
    public class ButtonOKCANCEL : Options
    {
        float elapsed;
        private SpriteFont OK;
        private SpriteFont CANCEL;
        private Vector2 OKPosition;
        private Vector2 CANCELPosition;
        private MouseState mouseState;
        private float mouseX;
        private float mouseY;
        private Color OKColor;
        private Color CANCELColor;
        private int level;
        private SpriteFont lv;
        private Color lv2Color;
        private Color lv3Color;
        private Color lv4Color;
        private Color lv5Color;
        private Color lv6Color;
        private Color lv7Color;
        private Vector2 lvPosition;
        private Rectangle lvRect;

        public override void LoadContent()
        {
            base.LoadContent();
            path = "ButtonFont";
            OK = content.Load<SpriteFont>(path);
            CANCEL = content.Load<SpriteFont>(path);
            OKPosition = new Vector2(270, 340);
            CANCELPosition = new Vector2(380, 340);
            desRect = new Rectangle((int)OKPosition.X, (int)OKPosition.Y + 10, 80, 40);
            sourRect = new Rectangle((int)CANCELPosition.X, (int)CANCELPosition.Y + 10, 250, 40);
            OKColor = new Color(226, 197, 29);
            CANCELColor = new Color(226, 197, 29);
            //level
            path = "LevelFont";
            lv = content.Load<SpriteFont>(path);
            lvPosition = new Vector2(200, 200);
            lv2Color = new Color(0, 255, 0);
            lv3Color = new Color(0, 255, 0);
            lv4Color = new Color(0, 255, 0);
            lv5Color = new Color(0, 255, 0);
            lv6Color = new Color(0, 255, 0);
        }

        public override void UploadConten()
        {
            base.UploadConten();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (desRect.Contains(mouseX, mouseY) && (level >= 2))
                {
                    OKColor = Color.DarkRed;
                    GameMapManager.Instance.isWriteText = false;
                    GameMapManager.Instance.isGameOptions = false;
                    GameMapManager.Instance.mapsizeTemp = level;
                    GameMapManager.Instance.isButtonOption = true;
                    GameMapManager.Instance.isNewMap = true;
                    GameMapManager.Instance.isNewActor = true;
                    GameMapManager.Instance.isNewMummy = true;
                    GameMapManager.Instance.isNewMummyIn = true;
                    lv2Color = new Color(0, 255, 0);
                    lv3Color = new Color(0, 255, 0);
                    lv4Color = new Color(0, 255, 0);
                    lv5Color = new Color(0, 255, 0);
                    lv6Color = new Color(0, 255, 0);
                }

                if (sourRect.Contains(mouseX, mouseY))
                {
                    CANCELColor = Color.DarkRed;
                    GameMapManager.Instance.isGameOptions = false;
                    GameMapManager.Instance.isButtonOption = true;
                }

                for (int k = 1; k < 6; k++)
                {
                    lvPosition = new Vector2(250 + k * 35, 300);
                    lvRect = new Rectangle((int)lvPosition.X, (int)lvPosition.Y, 30, 30);
                    if (lvRect.Contains(mouseX, mouseY))
                    {
                        switch (k)
                        {
                            case 1:
                                lv2Color = Color.OrangeRed;
                                lv3Color = new Color(0, 255, 0);
                                lv4Color = new Color(0, 255, 0);
                                lv5Color = new Color(0, 255, 0);
                                lv6Color = new Color(0, 255, 0);
                                lv7Color = new Color(0, 255, 0);
                                level = 2;
                                break;
                            case 2:
                                lv2Color = new Color(0, 255, 0);
                                lv3Color = Color.OrangeRed;
                                lv4Color = new Color(0, 255, 0);
                                lv5Color = new Color(0, 255, 0);
                                lv6Color = new Color(0, 255, 0);
                                lv7Color = new Color(0, 255, 0);
                                level = 3;
                                break;
                            case 3:
                                lv2Color = new Color(0, 255, 0);
                                lv3Color = new Color(0, 255, 0);
                                lv4Color = Color.OrangeRed;
                                lv5Color = new Color(0, 255, 0);
                                lv6Color = new Color(0, 255, 0);
                                lv7Color = new Color(0, 255, 0);
                                level = 4;
                                break;
                            case 4:
                                lv2Color = new Color(0, 255, 0);
                                lv3Color = new Color(0, 255, 0);
                                lv4Color = new Color(0, 255, 0);
                                lv5Color = Color.OrangeRed;
                                lv6Color = new Color(0, 255, 0);
                                lv7Color = new Color(0, 255, 0);
                                level = 5;
                                break;
                            case 5:
                                lv2Color = new Color(0, 255, 0);
                                lv3Color = new Color(0, 255, 0);
                                lv4Color = new Color(0, 255, 0);
                                lv5Color = new Color(0, 255, 0);
                                lv6Color = Color.OrangeRed;
                                lv7Color = new Color(0, 255, 0);
                                level = 6;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (GameMapManager.Instance.isWriteText)
            {
                spriteBatch.DrawString(OK, "OK", OKPosition, OKColor);
                spriteBatch.DrawString(CANCEL, "CANCEL", CANCELPosition, CANCELColor);
                CANCELColor = new Color(226, 197, 29);
                OKColor = new Color(226, 197, 29);
                for (int k = 1; k < 6; k++)
                {
                    lvPosition = new Vector2(250 + k * 35, 300);
                    switch (k)
                    {
                        case 1:
                            lvRect = new Rectangle((int)lvPosition.X, (int)lvPosition.Y, 20, 20);
                            spriteBatch.DrawString(lv, "2", lvPosition, lv2Color);
                            break;
                        case 2:
                            lvRect = new Rectangle((int)lvPosition.X, (int)lvPosition.Y, 20, 20);
                            spriteBatch.DrawString(lv, "3", lvPosition, lv3Color);
                            break;
                        case 3:
                            lvRect = new Rectangle((int)lvPosition.X, (int)lvPosition.Y, 20, 20);
                            spriteBatch.DrawString(lv, "4", lvPosition, lv4Color);
                            break;
                        case 4:
                            lvRect = new Rectangle((int)lvPosition.X, (int)lvPosition.Y, 20, 20);
                            spriteBatch.DrawString(lv, "5", lvPosition, lv5Color);
                            break;
                        case 5:
                            lvRect = new Rectangle((int)lvPosition.X, (int)lvPosition.Y, 20, 20);
                            spriteBatch.DrawString(lv, "6", lvPosition, lv6Color);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
