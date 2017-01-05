using System.Collections.Generic;
using GameConcepts;
using GameConcepts.Entities;

namespace GalagaGame.Entities
{
    internal class Enemies : Entity
    {
        public Enemies(int scoreValue, Game game, IEnumerable<IEntityScript> scripts) : base(game, scripts)
        {
            ScoreValue = scoreValue;
        }

        public int ScoreValue { get; }
    }
}
