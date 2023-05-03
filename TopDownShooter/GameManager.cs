using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter
{
    internal class GameManager
    {
        private readonly Player _player;

        public GameManager()
        {
            _player = new(Globals.Content.Load<Texture2D>("player"), new(200, 200));
        }

        public void Restart()
        {

        }

        public void Update()
        {
            InputManager.Update();
            _player.Update();
        }

        public void Draw()
        {
           _player.Draw();
        }
    }
}
