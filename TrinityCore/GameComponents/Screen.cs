using System;
using Microsoft.Xna.Framework;

namespace TrinityCore.GameComponents
{
    public class Screen : DrawableGameComponent
    {
        public string Name { get; private set; }

        public Boolean IsPopUp { get; private set; }
        public Boolean IsFullScreen { get; private set; }
        
        public Screen(Game game, string name, Boolean isPopUp = false, Boolean isFullScreen = true) : base(game)
        {
            Name = name;
            IsPopUp = isPopUp;
            IsFullScreen = isFullScreen;

            Console.WriteLine("Screen created: {0}", name);
        }

        public void Show()
        {
            Visible = true;
            Enabled = true;
        }

        public void Hide()
        {
            Visible = false;
            Enabled = false;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        public void Remove()
        {
            UnloadContent();
        }
    }
}
