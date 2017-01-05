using System.Collections.Generic;
using GameConcepts;
using GameConcepts.Entities;

namespace GalagaGame.Entities
{
    class Player : Entity
    {
        public Player(Game game, IEnumerable<IEntityScript> scripts) : base(game, scripts)
        {
        }
    }
}
