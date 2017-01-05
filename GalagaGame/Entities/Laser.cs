using System.Collections.Generic;
using GameConcepts;
using GameConcepts.Entities;

namespace GalagaGame.Entities
{
    public class LaserGame : Entity
    {
        public LaserGame(Game game, IEnumerable<IEntityScript> scripts) : base(game, scripts)
        {
        }
    }
}
