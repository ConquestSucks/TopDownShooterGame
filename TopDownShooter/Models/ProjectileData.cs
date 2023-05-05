using Microsoft.Xna.Framework;

namespace TopDownShooter
{
    public sealed class ProjectileData
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Lifespan { get; set; }
        public int Speed { get; set; }
    }
}