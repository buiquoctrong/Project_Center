using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace MummyMazeBasic
{
    public class Explorer : Actor
    {
        int frame;
        float elapsed;
        Texture2D actor1;
        Texture2D space;
        bool isStand;
        Rectangle rectStand;
        KeyboardState keyState;
        public override void LoadContent()
        {
            base.LoadContent();
            //moveSize = Extentions.CheckRoad.moveSize();
            position = new Vector2(213 + (GameMapManager.Instance.localActor[0].j - 1) * (4 * moveSize),
                                        79 + (GameMapManager.Instance.localActor[0].i - 1) * (4 * moveSize));
            desRect = new Rectangle((int)position.X,
                                    (int)position.Y,
                                    180 / GameMapManager.Instance.mapSize,
                                    180 / (GameMapManager.Instance.mapSize + 1));
            rectStand = new Rectangle((int)position.X, (int)position.Y, 90 / GameMapManager.Instance.mapSize,
                                         90 / GameMapManager.Instance.mapSize);
            sourRect = new Rectangle(0, 0, 45, 36);
            path = "explorer8";
            actor = content.Load<Texture2D>(path);
            path = "_explorer8";
            actor1 = content.Load<Texture2D>(path);
            path = "circle8";
            space = content.Load<Texture2D>(path);
            frame = 0;
            elapsed = 0;
            disableKey = false;
            isStand = false;
            gameLevel = GameMapManager.Instance.level;

        }
        public override void UploadConten()
        {
            base.UploadConten();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //when input keyboard is not block
            if (!disableKey)
            {
                //get state keyboard
                keyState = Keyboard.GetState();
                local = Extentions.CheckRoad.PositionInMap(position);
            }
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
            {
                if (((position.Y >= Ystart + moveSize * 4)
                    && Extentions.CheckRoad.CanGoTop(local, gameLevel))
                    || (frame != 0))
                {
                    disableKey = true;
                    elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (elapsed > 100f)
                    {
                        if (frame >= 4)
                        {
                            frame = 0;
                            disableKey = false;
                            keyState = default(KeyboardState);
                            Extentions.CheckRoad.UpdatePosition(Extentions.CheckRoad.Address(position), 0);
                            Extentions.CheckRoad.MummyEatExplorer();
                        }
                        else
                        {
                            frame++;
                            position.Y -= moveSize;
                        }
                        elapsed = 0;
                    }
                    desRect = new Rectangle((int)position.X, (int)position.Y, 180 / GameMapManager.Instance.mapSize,
                                    180 / (GameMapManager.Instance.mapSize + 1));
                    sourRect = new Rectangle(45 * frame, 0, 45, 36);
                }

            }
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                if (((position.X <= Xend - moveSize * 4)
                    && Extentions.CheckRoad.CanGoRight(local, gameLevel))
                    || (frame != 0))
                {
                    disableKey = true;
                    elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (elapsed > 100f)
                    {
                        if (frame >= 4)
                        {
                            frame = 0;
                            disableKey = false;
                            keyState = default(KeyboardState);
                            Extentions.CheckRoad.UpdatePosition(Extentions.CheckRoad.Address(position), 0);
                            Extentions.CheckRoad.MummyEatExplorer();
                        }
                        else
                        {
                            frame++;
                            position.X += moveSize;
                        }
                        elapsed = 0;
                    }
                    desRect = new Rectangle((int)position.X, (int)position.Y, 180 / GameMapManager.Instance.mapSize,
                                    180 / (GameMapManager.Instance.mapSize + 1));
                    sourRect = new Rectangle(45 * frame, 46, 45, 36);
                }
            }
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                if (((position.X >= Xstart + moveSize * 4)
                    && Extentions.CheckRoad.CanGoLeft(local, gameLevel))
                    || (frame != 0))
                {
                    disableKey = true;
                    elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (elapsed > 100f)
                    {
                        if (frame >= 4)
                        {
                            frame = 0;
                            disableKey = false;
                            keyState = default(KeyboardState);
                            Extentions.CheckRoad.UpdatePosition(Extentions.CheckRoad.Address(position), 0);
                            Extentions.CheckRoad.MummyEatExplorer();
                        }
                        else
                        {
                            frame++;
                            position.X -= moveSize;
                        }
                        elapsed = 0;
                    }
                    desRect = new Rectangle((int)position.X, (int)position.Y, 180 / GameMapManager.Instance.mapSize,
                                    180 / (GameMapManager.Instance.mapSize + 1));
                    sourRect = new Rectangle(45 * frame, 137, 45, 36);
                }
            }

            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
            {
                if (((position.Y <= Yend - moveSize * 4)
                    && Extentions.CheckRoad.CanGoBot(local, gameLevel))
                    || (frame != 0))
                {
                    disableKey = true;
                    elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (elapsed > 100f)
                    {
                        if (frame >= 4)
                        {
                            frame = 0;
                            disableKey = false;
                            keyState = default(KeyboardState);
                            Extentions.CheckRoad.UpdatePosition(Extentions.CheckRoad.Address(position), 0);
                            Extentions.CheckRoad.MummyEatExplorer();
                        }
                        else
                        {
                            frame++;
                            position.Y += moveSize;
                        }
                        elapsed = 0;
                    }
                    desRect = new Rectangle((int)position.X, (int)position.Y, 180 / GameMapManager.Instance.mapSize,
                                    180 / (GameMapManager.Instance.mapSize + 1));
                    sourRect = new Rectangle(45 * frame, 93, 45, 36);
                }
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                disableKey = true;
                isStand = true;
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed > 100f)
                {
                    if (frame >= 4)
                    {
                        frame = 0;
                        disableKey = false;
                        isStand = false;
                        keyState = default(KeyboardState);
                        Extentions.CheckRoad.MummyEatExplorer();
                    }
                    else
                    {
                        frame++;
                    }
                    elapsed = 0;
                }
                rectStand = new Rectangle((int)position.X, (int)position.Y, 45, 45);
            }

            moveSize = Extentions.CheckRoad.moveSize();
           
            if (GameMapManager.Instance.isNewActor || GameMapManager.Instance.isNewMap)
            {
                position = new Vector2(213 + (GameMapManager.Instance.localActor[0].j - 1) * (4 * moveSize),
                                        79 + (GameMapManager.Instance.localActor[0].i - 1) * (4 * moveSize));
                GameMapManager.Instance.isNewActor = false;
            }
            desRect = new Rectangle((int)position.X, (int)position.Y, 180 / GameMapManager.Instance.mapSize,
                                    180 / (GameMapManager.Instance.mapSize + 1));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(actor1, desRect, sourRect, Color.White);
            spriteBatch.Draw(actor, desRect, sourRect, Color.White);
        }
    }
}