using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TrinityCore.GameComponents
{
    public class FPSCounter : DrawableGameComponent
    {
        private Game game;

        private Queue<double> fpsQueue;
        private int maxSamples;

        public double AverageFPS { get; private set; }
        public double CurrentFPS { get; private set; }

        public FPSCounter(Game game) : base(game)
        {
            this.game = game;
            fpsQueue = new Queue<double>();
        }

        public override void Draw(GameTime gameTime)
        {
            CurrentFPS = (1f / gameTime.ElapsedGameTime.TotalSeconds);
            if (fpsQueue.Count > maxSamples)
            {
                fpsQueue.Dequeue();
                fpsQueue.Enqueue(CurrentFPS);
            }
            else
                fpsQueue.Enqueue(CurrentFPS);

            AverageFPS = fpsQueue.Average();

            game.Window.Title = string.Format("cur: {0:F4}; ave: {1:F4}", CurrentFPS, AverageFPS);
        }
    }
}
