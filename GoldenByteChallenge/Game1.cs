#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using TrinityCore.GameComponents;

#endregion

namespace GoldenByteChallenge
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private ScreenManager screenManager; 

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            var s = new StringWriter();
            Console.SetOut(s);

            Console.WriteLine("hello");
            Console.WriteLine("from console");

            var text = s.GetStringBuilder().ToString();

            var menuScreen = new Screen(this, "menu");
            var optionsScreen = new Screen(this, "options", true);
            var gameScreen = new Screen(this, "game");

            screenManager = new ScreenManager(this);
            

            var t = s.GetStringBuilder().ToString();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            InputHandler.Update();

            if (InputHandler.MouseLeftPressDown())
            {
                screenManager.PushScreen(new Screen(this, "anotherScreen", true));
            }
            if (InputHandler.MouseRightPressDown())
            {
                screenManager.PopScreen();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Window.Title = screenManager.ScreenCount.ToString();

            base.Draw(gameTime);
        }
    }
}
