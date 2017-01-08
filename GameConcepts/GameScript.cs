using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConcepts.Entities;

namespace GameConcepts
{
    // Command Object Interface
    public interface IGameScript
    {
        void Execute(Game game);

        void Initialize(Game game);
        void Collision(Game game);
        void Destroy(Game game);
    }
}
