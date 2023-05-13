using Microsoft.Xna.Framework.Graphics;
using TopDownShooter.Managers;

namespace TopDownShooter
{
    internal class GameManager
    {
        private readonly Player _player;

        public GameManager()
        {
            ProjectileManager.Init();
            _player = new(Globals.Content.Load<Texture2D>("player"), new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2));
            EnemyManager.Init();
            EnemyManager.AddEnemy();
        }

        public void Restart()
        {

        }

        public void Update()
        {
            InputManager.Update();
            _player.Update();
            EnemyManager.Update(_player);
            ProjectileManager.Update();
        }

        public void Draw()
        {
            ProjectileManager.Draw();
            _player?.Draw();
           _player.Draw();
           EnemyManager.Draw();
        }
    }
}
