using System.Collections.Generic;
using System.Drawing;
using GameConcepts;
using GameConcepts.Entities;

namespace GalagaGame.Entities
{
    public class Powerups : Entity
    {
        public Powerups(Game game, IEnumerable<IEntityScript> scripts) : base(game, scripts)
        {
        }

        public override void RenderEntity(Graphics graphics)
        {
            throw new System.NotImplementedException();
        }
    }
}
