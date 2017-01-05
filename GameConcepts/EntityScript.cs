using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConcepts.Entities;

namespace GameConcepts
{
    public interface IEntityScript
    {
        void Initialize(Game game);
        void Action(Game game, Entity entity);
        void Collision(Game game, Entity entity);
        void Destroy(Game game);
    }
}
