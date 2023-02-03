using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;
using System.Linq;

namespace platformGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        List<Platform> platfromList;
        List<Enemy> enemyList;
        Player player;
        Chest chest;
        
        Texture2D backgroundTex;
        Texture2D winTex;
        Texture2D loseTex;
        SpriteFont textFont;

        public enum GameState { Playing, Won, Lost }
        public GameState gameState;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 660;
            graphics.PreferredBackBufferWidth = 1200;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            platfromList = new List<Platform>();
            enemyList = new List<Enemy>();
            player = null;

            backgroundTex = Content.Load<Texture2D>("background");
            loseTex = Content.Load<Texture2D>("YouLose");
            winTex = Content.Load<Texture2D>("win2");

            textFont = Content.Load<SpriteFont>("font");

            Assests.LoadTextures(Content);

            ReadFromFile("platform.json");

            // TODO: use this.Content to load your game content here
        }

        public void ReadFromFile(string fileName)
        {
            Rectangle playerRect = JsonParser.GetRectangle(fileName, "player");
            player = new Player(playerRect);

            Rectangle chestRect = JsonParser.GetRectangle(fileName, "chest");
            chest = new Chest(chestRect);

            List<Rectangle> platformsRect = JsonParser.GetRectangleList(fileName, "platforms");
            foreach (Rectangle r in platformsRect)
            {

                Platform p = new Platform(r);
                platfromList.Add(p);

            }

            List<Rectangle> enemyRects = JsonParser.GetRectangleList(fileName, "enemies");
            foreach (Rectangle r in enemyRects)
            {
                Enemy e = new Enemy(r);
                enemyList.Add(e);

            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyMouseReader.Update();

            switch (gameState)
            {
                case GameState.Playing:
                    player.Update(gameTime, platfromList);
                    chest.Update();


                    foreach (Enemy e in enemyList)
                    {

                        e.Update();
                        e.enemyRec.Intersects(player.playerRec);

                        if (e.enemyRec.Intersects(player.playerRec))
                        {
                            gameState = GameState.Lost;

                        }

                        if (chest.chestRec.Intersects(player.playerRec))
                        {
                            gameState = GameState.Won;

                        }

                    }


                    break;

                case GameState.Won:
                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        Exit();
                    }

                    break;

                case GameState.Lost:
                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        Exit();
                    }
                    break;



            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.Playing:
                    spriteBatch.Draw(backgroundTex, Vector2.Zero, Color.White);

                    foreach (Platform t in platfromList)
                    {
                        t.Draw(spriteBatch);
                    }

                    foreach (Enemy e in enemyList)
                    {
                        e.Draw(spriteBatch);
                    }

                    player.Draw(spriteBatch);
                    chest.Draw(spriteBatch);

                    break;

                case GameState.Won:
                    spriteBatch.Draw(winTex, Vector2.Zero, Color.White);
                    spriteBatch.DrawString(textFont, "Press Escape To Exit", new Vector2(490, 420), Color.White);
                    break;

                case GameState.Lost:
                    spriteBatch.Draw(loseTex, Vector2.Zero, Color.White);
                    spriteBatch.DrawString(textFont, "Press Escape To Exit", new Vector2(490, 420), Color.Green);

                    break;


            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}