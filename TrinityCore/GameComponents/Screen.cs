using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;

namespace TrinityCore.GameComponents
{
    public class Screen : DrawableGameComponent
    {
        private ScreenManager screenManager;
        public string Name { get; private set; }

        public Boolean IsPopUp { get; private set; }
        public Boolean IsFullScreen { get; private set; }
        public ObservableCollection<GameComponent> Components { get; private set; }
        public ScreenManager ScreenManager
        {
            get { return screenManager; }
        }

        public Screen(Game game, ScreenManager parentScreenManager, string name, Boolean isPopUp = false, Boolean isFullScreen = true) : base(game)
        {
            Name = name;
            IsPopUp = isPopUp;
            IsFullScreen = isFullScreen;
            Components = new ObservableCollection<GameComponent>();
            screenManager = parentScreenManager;
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
            foreach (IGameComponent component in Components)
                component.Initialize();
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in Components)
                component.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var component in Components.Where(comp => comp is DrawableGameComponent))
                (component as DrawableGameComponent).Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            foreach (var component in Components)
                component.Dispose();

            base.UnloadContent();
        }

        public void Remove()
        {
            UnloadContent();
        }
    }
}
