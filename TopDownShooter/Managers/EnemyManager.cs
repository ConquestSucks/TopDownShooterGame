using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TopDownShooter.Models;

namespace TopDownShooter.Managers
{
    internal class EnemyManager
    {
        private static Texture2D _texture;
        public static List<Enemy> Enemies { get; } = new();
        private static float _spawnCooldown;
        private static float _spawnTime;
        private static Random _random;
        private static int _padding;

        public static void Init()
        {
            _texture = Globals.Content.Load<Texture2D>("player");
            _spawnCooldown = 0.5f;
            _spawnTime = _spawnCooldown;
            _random = new();
            _padding = _texture.Width / 2;
        }

        public static void AddEnemy()
        {
            Enemies.Add(new(_texture, RandomPosition()));
        }

        private static Vector2 RandomPosition()
        {
            float w = Globals.Bounds.X;
            float h = Globals.Bounds.Y;
            Vector2 pos = new();

            if (_random.NextDouble() < w / (w + h))
            {
                pos.X = (int)(_random.NextDouble() * w);
                pos.Y = (int)(_random.NextDouble() < 0.5 ? -_padding : h + _padding);
            }
            else
            {
                pos.Y = (int)(_random.NextDouble() * h);
                pos.X = (int)(_random.NextDouble() < 0.5 ? -_padding : w + _padding);
            }

            return pos;
        }

        public static void Update(Player player)
        {
            _spawnTime -= Globals.TotalSeconds;
            while (_spawnTime <= 0)
            {
                _spawnTime += _spawnCooldown;
                AddEnemy();
            }

            foreach (var e in Enemies)
            {
                e.Update(player);
            }
        }

        public static void Draw()
        {
            foreach (var e in Enemies)
            {
                e.Draw();
            }
        }
    }
}
