﻿    using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TopDownShooter
{
    internal class InputManager
    {
        private static MouseState _lastMouseState;
        private static Vector2 _direction;
        public static Vector2 Direction => _direction;
        public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
        public static bool MouseClicked { get; private set; }
        public static bool MouseLeftDown { get; private set; }

        public static void Update()
        {
            var keyboardState = Keyboard.GetState();
            var mouseState = Mouse.GetState();

            _direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W)) _direction.Y--;
            if (keyboardState.IsKeyDown(Keys.S)) _direction.Y++;
            if (keyboardState.IsKeyDown(Keys.A)) _direction.X--;
            if (keyboardState.IsKeyDown(Keys.D)) _direction.X++;

            MouseLeftDown = mouseState.LeftButton == ButtonState.Pressed;
            MouseClicked = MouseLeftDown && (_lastMouseState.LeftButton == ButtonState.Released);

            _lastMouseState = mouseState;
        }

    }
}
