using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameConcepts.Entities
{
    public abstract class Entity
    {
        public IEnumerable<IEntityScript> Scripts { get; }
        public int X { get; set;  }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        protected Game Game;

        protected Entity(Game game, IEnumerable<IEntityScript> scripts, int width, int height)
        {
            Game = game;
            Scripts = scripts;
            Width = width;
            Height = height;
        }

        protected Entity(Game game, IEnumerable<IEntityScript> scripts)
        {
            this.Game = game;
            this.Scripts = scripts;
        }

        public abstract void RenderEntity(Graphics graphics);
    }
}
