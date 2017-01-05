using System.Collections.Generic;
using GameConcepts;
using GameConcepts.Entities;

namespace GalagaGame.Entities
{
    public class Powerups : Entity
    {
        public Powerups(Game game, IEnumerable<IEntityScript> scripts) : base(game, scripts)
        {
        }
    }
}
