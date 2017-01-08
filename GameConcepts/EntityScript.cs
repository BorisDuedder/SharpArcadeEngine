using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConcepts.Entities;

namespace GameConcepts
{
    // Command Object Interface
    public interface IEntityScript
    {
        void Execute(Game game, Entity entity);

        void Initialize(Game game, Entity entity);
        void Collision(Game game, Entity entity);
        void Destroy(Game game, Entity entity);
    }
}
