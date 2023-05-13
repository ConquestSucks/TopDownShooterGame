﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TopDownShooter.Managers;

namespace TopDownShooter
{
    internal class Player : Sprite
    {
        public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
        }

        private void Fire()
        {
            ProjectileData pd = new()
            {
                Position = Position,
                Rotation = Rotation,
                Lifespan = 2,
                Speed = 600
            };

            ProjectileManager.AddProjecttile(pd);
        }

        public void Update()
        {
            if(InputManager.Direction != Vector2.Zero)
            {
                var direction = Vector2.Normalize(InputManager.Direction);
                Position = new(
                    MathHelper.Clamp(Position.X + (direction.X * Speed * Globals.TotalSeconds), 0, Globals.Bounds.X),
                    MathHelper.Clamp(Position.Y + (direction.Y * Speed * Globals.TotalSeconds), 0, Globals.Bounds.Y)
                );
            }

            var toMouse = InputManager.MousePosition - Position;
            Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            if (InputManager.MouseClicked)
            {
                Fire();
            }
        }
    }
}
