using System.Collections.Generic;
using GameConcepts;
using GameConcepts.Entities;

namespace GalagaGame.Entities
{
    internal class Enemies : Entity
    {
        public Enemies(int scoreValue, Game game, IEnumerable<IEntityScript> scripts, int width, int height) : base(game, scripts, width, height)
        {
            ScoreValue = scoreValue;
        }

        public int ScoreValue { get; }
    }
}
