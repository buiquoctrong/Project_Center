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
    public class GameMapManager
    {
        private static GameMapManager instance;
        //private int[][] mapItem;
        //private int[][] mapActor;
        //private List<int[][]> mapHistory;
        private Random random;
        public int level { get; set; }
        public int mapSize { get; set; }
        public bool isNewMap { get; set; }
        public bool isNewActor { get; set; }
        public bool isNewMummy { get; set; }
        public List<int[]> theWay { get; set; }
        public bool isNewMummyIn { get; set; }
        public int[][] map { get; set; }
        public List<Extentions.CLocal> localActor;
        public bool isGameOver { get; set; }
        public bool isOptions { get; set; }
        public bool isGameOptions { get; set; }
        public bool isGameOptionsScroll { get; set; }
        public bool isButtonOption { get; set; }
        public bool isWriteText { get; set; }
        public int mapsizeTemp { get; set; }
        public ContentManager Content { get; set; }

        public static GameMapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameMapManager();
                }
                return instance;
            }
        }

        public GameMapManager()
        {
            random = new Random();
            level = 1;
            mapSize = 3;
            mapsizeTemp = 3;
            isNewMap = true;
            map = new int[mapSize * 2 + 1][];
            isNewActor = true;
            isNewMummy = true;
            isNewMummyIn = true;
            theWay = new List<int[]>();
            randomPosition();
            isGameOver = false;
            isOptions = false;
            isGameOptions = true;
            isGameOptionsScroll = false;
            isButtonOption = false;
            isWriteText = false;
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            ScreenManager.Instance.LoadContent(Content);
            ActorManager.Instance.LoadContent(Content);
            MapManager.Instance.LoadContent(Content);
            OptionsManager.Instance.LoadContent(Content);
        }

        public void UploadConten()
        {
            ActorManager.Instance.UploadConten();
            ScreenManager.Instance.UploadConten();
            MapManager.Instance.UploadConten();
            OptionsManager.Instance.UploadConten();
        }

        public void Update(GameTime gameTime)
        {
            ActorManager.Instance.Update(gameTime);
            ScreenManager.Instance.Update(gameTime);
            MapManager.Instance.Update(gameTime);
            OptionsManager.Instance.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ScreenManager.Instance.Draw(spriteBatch);
            MapManager.Instance.Draw(spriteBatch);
            ActorManager.Instance.Draw(spriteBatch);
            OptionsManager.Instance.Draw(spriteBatch);
        }

        public void randomPosition()
        {
            Extentions.CLocal actorMummy = new Extentions.CLocal();
            Extentions.CLocal actorMummyIntel = new Extentions.CLocal();
            actorMummyIntel.i = 0;
            actorMummyIntel.j = 0;
            if (localActor == null)
            {
                localActor = new List<Extentions.CLocal>();
            }
            else
            {
                localActor.Clear();
            }
            actorMummy.i = random.Next() % (mapSize * 2 - 1) + 1;
            actorMummy.j = random.Next() % (mapSize * 2 - 1) + 1;
            localActor.Add(actorMummy);
            //localActor.Insert(1, actorMummy);
            while (actorMummy.i == actorMummyIntel.i && actorMummy.j == actorMummy.j
                || actorMummyIntel.j == 0 || actorMummyIntel.i == 0)
            {
                actorMummyIntel.j = random.Next() % (mapSize * 2 - 1) + 1;
                actorMummyIntel.i = random.Next() % (mapSize * 2 - 1) + 1;
            }
            //localActor.Insert(2, actorMummyIntel);
            localActor.Add(actorMummyIntel);
        }
    }
}

