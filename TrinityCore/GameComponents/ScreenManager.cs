using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrinityCore.GameComponents
{
    public class ScreenManager : DrawableGameComponent
    {
        private List<Screen> activeScreens;

        public Int32 ScreenCount
        {
            get { return activeScreens.Count; }
        }

        public ScreenManager(Game game) : base(game)
        {
            activeScreens = new List<Screen>();
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Screen screen in activeScreens.Where(scr => scr.Enabled))
            {
                screen.Update(gameTime);
            }
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Screen screen in activeScreens.Where(scr => scr.Visible))
            {
                screen.Draw(gameTime);
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// Добавляет в менеджер новый экран
        /// </summary>
        /// <param name="screen">Имя экрана</param>
        public void PushScreen(Screen screen)
        {
            if (activeScreens != null)
            {
                if (!screen.IsPopUp)
                {
                    foreach (var activeScreen in activeScreens)
                        activeScreen.Remove();
                    
                    activeScreens = new List<Screen>{screen};
                }
                else
                {
                    if (activeScreens.Count != 0)
                    {
                        activeScreens.Last().Enabled = false;
                        
                        if (screen.IsFullScreen)
                            activeScreens.Last().Visible = false;
                    }
                    activeScreens.Add(screen);
                }
            }
        }

        /// <summary>
        /// Удаляет текущий экран и достаёт из стэка предыдущий
        /// если таких нет, то остаётся пустым
        /// </summary>
        public void PopScreen()
        {
            if (activeScreens != null)
            {
                // Удаляем последный активный экран
                var last = activeScreens.LastOrDefault();
                if (last != null)
                {
                    last.Remove();
                    activeScreens.RemoveAt(activeScreens.Count - 1);

                    // Предпоследний экран активируем
                    var lastButOne = activeScreens.LastOrDefault();

                    if (lastButOne != null)
                        lastButOne.Show();
                }

            }
        }
    }
}
