using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TopDownShooter.Models
{
    internal class Enemy : Sprite
    {
        public Enemy(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            Speed = 100;
        }

        public void Update(Player player)
        {
            var toPlayer = player.Position - Position;
            Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X);

            if(toPlayer.Length() > 4)
            {
                var direction = Vector2.Normalize(toPlayer);
                Position += direction * Speed * Globals.TotalSeconds;
            }
        }
    }
}
