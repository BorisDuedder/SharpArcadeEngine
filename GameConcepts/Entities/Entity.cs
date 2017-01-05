using System.Collections;
using System.Collections.Generic;

namespace GameConcepts.Entities
{
    public class Entity
    {
        public IEnumerable<IEntityScript> Scripts { get; }
        public int X { get; set;  }
        private int Y { get; set; }
        private Game _game;

        public Entity(Game game, IEnumerable<IEntityScript> scripts)
        {
            _game = game;
            Scripts = scripts;
        }
    }
}
