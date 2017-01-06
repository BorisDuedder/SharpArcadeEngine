using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConcepts;

namespace SharpGameEngine
{
    public enum GamesEnum { Galaga };
    class GameFactory
    {
        static public Game CreateGame(GamesEnum game)
        {
            Game chosenGame = null;
            switch (game)
            {
                case GamesEnum.Galaga:
                    chosenGame = new GalagaGame.GalagaGame();
                    break;
                default:
                    throw new ArgumentException("Unknown game.");

            }
            return chosenGame;
        }
    }
}
