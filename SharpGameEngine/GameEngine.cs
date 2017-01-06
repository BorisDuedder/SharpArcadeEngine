using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConcepts;

namespace SharpGameEngine
{
    public class GameEngine
    {
        private GameFrame _frame;
        private Game selectedGame;

        public GameEngine(GameFrame frame)
        {
            _frame = frame;
            selectedGame = GameFactory.CreateGame(GamesEnum.Galaga);
            frame.DrawScene+=new DrawSceneHandler(selectedGame.OnDrawScene);
            frame.KeyPressed+=new KeyPressedHandler(selectedGame.OnKeyPressed);
        }

    }
}
