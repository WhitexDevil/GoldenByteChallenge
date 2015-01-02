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
using TrinityCore.Screens;

#endregion

namespace GoldenByteChallenge
{
    public class TrinityGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private ScreenManager screenManager;

        public ScreenManager ScreenManager
        {
            get { return screenManager; }
        }

        public TrinityGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            screenManager = new ScreenManager(this);
            screenManager.PushScreen(new TestScreen(this, screenManager));
           
            Components.Add(screenManager);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Window.Title = screenManager.ScreenCount.ToString();

            base.Draw(gameTime);
        }
    }
}
