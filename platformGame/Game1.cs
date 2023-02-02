using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;

namespace platformGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        List<Platform> platfromList;
        List<Enemy> enemyList;
        Player player;
        Texture2D backgroundTex;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 460;
            graphics.PreferredBackBufferWidth = 600;

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

            Assests.LoadTextures(Content);

            ReadFromFile("platform.json");

            // TODO: use this.Content to load your game content here
        }

        public void ReadFromFile (string fileName)
        {
            Rectangle playerRect = JsonParser.GetRectangle(fileName, "player");
            player = new Player(playerRect);

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

            


            player.Update(gameTime);

            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

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

            spriteBatch.End();



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}