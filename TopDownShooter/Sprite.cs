using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownShooter
{
    internal class Sprite
    {
        protected readonly Texture2D _texture;
        protected readonly Vector2 origin;
        public Vector2 _position { get; set; }
        public int _speed { get; set; }
        public float _rotation { get; set; }

        public Sprite(Texture2D tex, Vector2 pos)
        {
            _texture = tex;
            _position = pos;
            _speed = 300;
            origin = new(tex.Width / 2, tex.Height / 2);
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, _position, null, Color.White, _rotation, origin, 1, SpriteEffects.None, 1);
        }
    }
}
