using System.Collections.Generic;
using System.Drawing;
using GameConcepts;
using GameConcepts.Entities;

namespace GalagaGame.Entities
{
    public class Enemies : Entity
    {
        public Enemies(int scoreValue, Game game, IEnumerable<IEntityScript> scripts, int width, int height) : base(game, scripts, width, height)
        {
            ScoreValue = scoreValue;
        }

        public int ScoreValue { get; }
        public override void RenderEntity(Graphics graphics)
        {
            throw new System.NotImplementedException();
        }
    }
}
