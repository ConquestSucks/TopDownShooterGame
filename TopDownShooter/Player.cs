using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownShooter
{
    internal class Player : Sprite
    {
        public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
        }

        public void Update()
        {
            if(InputManager.Direction != Vector2.Zero)
            {
                var direction = Vector2.Normalize(InputManager.Direction);
                _position += direction * _speed * Globals.TotalSeconds;
            }

            var toMouse = InputManager.MousePosition - _position;
            _rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);
        }
    }
}
