using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameConcepts.Entities
{
    public class Entity
    {
        public IEnumerable<IEntityScript> Scripts { get; }
        public int X { get; set;  }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        private Game _game;
        private Game game;
        private IEnumerable<IEntityScript> scripts;

        public Entity(Game game, IEnumerable<IEntityScript> scripts, int width, int height)
        {
            _game = game;
            Scripts = scripts;
            Width = width;
            Height = height;
        }

        public Entity(Game game, IEnumerable<IEntityScript> scripts)
        {
            this.game = game;
            this.scripts = scripts;
        }

        public void RenderEntity(Graphics graphics)
        {
            
        }
    }
}
