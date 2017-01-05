using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConcepts.Entities;

namespace GameConcepts
{
    public interface IGameScript
    {
        void Initialize(Game game);
        void Action(Game game);
        void Collision(Game game);
        void Destroy(Game game);
    }
}
