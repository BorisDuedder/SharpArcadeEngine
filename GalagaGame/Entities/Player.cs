using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using GameConcepts;
using GameConcepts.Entities;

namespace GalagaGame.Entities
{
    class Player : Entity
    {
        private readonly Image playerImage;

        public Player(Game game, List<IEntityScript> scripts) : base(game, scripts)
        {
            this.X = 200;
            this.Y = 300;
            playerImage = Game.LoadImage(@"GalagaGame.resources.images.Player.png");
        }

        public override void RenderEntity(Graphics graphics)
        {
            graphics?.DrawImage(playerImage, X, Y);
        }
    }
}
