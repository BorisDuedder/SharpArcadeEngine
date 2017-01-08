using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GalagaGame.Entities;
using GameConcepts;

namespace GalagaGame
{
    enum GalagaState
    {
        ShowCredits,
        GameStarted,
        GamePaused,
        GameRunning,
        GameEnded
    };
    public class GalagaGame : Game
    {
        private GalagaState _galagaState;
        private Image _startScreen;
        private Image _spaceBackground;


        public GalagaGame() : base()
        {
            _galagaState=GalagaState.ShowCredits;
            Name = "Galaga V0.1";
            Player=new Player(this, new List<IEntityScript>());
            LoadImages();
        }

        public override Image LoadImage(string fileName)
        {
            var thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            return Image.FromStream(thisExe.GetManifestResourceStream(fileName));
        }

    private void LoadImages()
        {
            //System.Reflection.Assembly thisExe;
            //thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            //string[] resources = thisExe.GetManifestResourceNames();
            //string list = "";

            //// Build the string of resources.
            //foreach (string resource in resources)
            //    list += resource + "\r\n";

            _startScreen = LoadImage(@"GalagaGame.resources.images.TitleImage.png");
            _spaceBackground = LoadImage(@"GalagaGame.resources.images.SpaceBackground.png");
        }

        public override void OnKeyPressed(KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Left)
            {
                // Move left
                if (Player.X > 10)
                    Player.X -= 10;
            }

            if (args.KeyCode == Keys.Right)
            {
                // Move right
                if (Player.X < 500)
                    Player.X += 10;
            }

            if (args.KeyCode == Keys.Space)
            {
                if(_galagaState==GalagaState.ShowCredits || _galagaState==GalagaState.GamePaused)
                    _galagaState= GalagaState.GameStarted;
                if(_galagaState==GalagaState.GameEnded)
                    _galagaState= GalagaState.ShowCredits;
                // Fire
            }

            if (args.KeyCode == Keys.H)
            {
                if(_galagaState==GalagaState.GameRunning)
                    _galagaState=GalagaState.GamePaused;
            }

            if (args.KeyCode == Keys.Escape)
            {
                // Escape key was pressed
                _galagaState=GalagaState.GameEnded;
            }
        }

        /// <summary>
        /// Maps the current game state to methods executing the state operations.
        /// </summary>
        /// <param name="graphics"></param>
        public override void OnDrawScene(Graphics graphics)
        {
            switch (_galagaState)
            {
                case GalagaState.GameStarted:GameStarted(graphics);
                    break;
                case GalagaState.GameRunning:GameRunning(graphics);
                    break;
                case GalagaState.GamePaused:ShowGamePaused(graphics);
                    break;
                case GalagaState.GameEnded:ShowGameEnded(graphics);
                    break;
                case GalagaState.ShowCredits:ShowCredits(graphics);
                    break;
                default:    throw new ArgumentException("Unknown state");
            }
        }

        private void GameStarted(Graphics graphics)
        {
            CallInitializeScripts();
            _galagaState=GalagaState.GameRunning;
            GameRunning(graphics);
        }

        private void GameRunning(Graphics graphics)
        {
            if (_spaceBackground != null) graphics.DrawImage(_spaceBackground, 0, 0, new Rectangle(0, 0, 1024, 768), GraphicsUnit.Pixel);

            RenderScene(graphics);
        }

        private void ShowCredits(Graphics graphics)
        {
            if (_startScreen != null) graphics.DrawImage(_startScreen, 0,0, new Rectangle(0,0,1024,768),  GraphicsUnit.Pixel);
            graphics.DrawString(Name, new Font("Arial", 16), new SolidBrush(Color.White), new PointF(100.0F, 100.0F));
            graphics.DrawString("Press space to start", new Font("Arial", 16), new SolidBrush(Color.White), new PointF(50.0F, 150.0F));
        }

        private void ShowGamePaused(Graphics graphics)
        {
            graphics.DrawString("Game paused", new Font("Arial", 16), new SolidBrush(Color.White), new PointF(100.0F, 100.0F));
        }

        private void ShowGameEnded(Graphics graphics)
        {
            CallDestroyScripts();
            graphics.DrawString("Game over!", new Font("Arial", 16), new SolidBrush(Color.White), new PointF(150.0F, 100.0F));
            graphics.DrawString($"Your score is {Score}.", new Font("Arial", 16), new SolidBrush(Color.White), new PointF(100.0F, 150.0F));
        }
    }
}