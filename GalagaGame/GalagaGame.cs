using System.Drawing;
using System.Windows.Forms;
using GameConcepts;

namespace GalagaGame
{
    enum GalagaState
    {
        ShowCredits,
        GameStart,
        GamePaused,
        GameEnd
    };
    public class GalagaGame : Game
    {
        private GalagaState _galagaState;

        public GalagaGame() : base()
        {
            _galagaState=GalagaState.ShowCredits;
        }

        public override void OnKeyPressed(KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Left)
            {
                // Move left
            }

            if (args.KeyCode == Keys.Right)
            {
                // Move right
            }

            if (args.KeyCode == Keys.Space)
            {
                if(_galagaState==GalagaState.ShowCredits || _galagaState==GalagaState.GamePaused)
                    _galagaState= GalagaState.GameStart;
                // Fire
            }

            if (args.KeyCode == Keys.H)
            {
                _galagaState=GalagaState.GamePaused;
            }

            if (args.KeyCode == Keys.Escape)
            {
                // Escape key was pressed
                _galagaState=GalagaState.GameEnd;
            }
        }

        public override void OnDrawScene(Graphics graphics)
        {
            if (_galagaState == GalagaState.GameStart)
                RenderScene(graphics);
            if (_galagaState==GalagaState.ShowCredits)
                ShowCredits(graphics);
            if(_galagaState==GalagaState.GamePaused)
                ShowGamePaused(graphics);
        }

        private void ShowCredits(Graphics graphics)
        {
            graphics.DrawString("Galaga V0.1", new Font("Arial", 16), new SolidBrush(Color.White), new PointF(100.0F, 100.0F));
            graphics.DrawString("Press space", new Font("Arial", 16), new SolidBrush(Color.White), new PointF(100.0F, 150.0F));
        }

        private void ShowGamePaused(Graphics graphics)
        {
            graphics.DrawString("Game paused", new Font("Arial", 16), new SolidBrush(Color.White), new PointF(100.0F, 100.0F));
        }
    }
}