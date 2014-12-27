using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace TrinityCore.GameComponents
{
    public static class InputHandler
    {
        private static MouseState newMouseState;
        private static MouseState oldMouseState;

        private static KeyboardState newKeyboardState;
        private static KeyboardState oldKeyboardState;

        private static TouchCollection touchPanelState;

        public static MouseState MouseState
        {
            get { return newMouseState; }
        }

        public static KeyboardState KeyboardState
        {
            get { return newKeyboardState; }
        }

        static InputHandler()
        {
            newKeyboardState = oldKeyboardState = Keyboard.GetState();
            newMouseState = oldMouseState = Mouse.GetState();
            touchPanelState = TouchPanel.GetState();
        }

        public static void Update()
        {
            oldKeyboardState = newKeyboardState;
            newKeyboardState = Keyboard.GetState();

            oldMouseState = newMouseState;
            newMouseState = Mouse.GetState();

            touchPanelState = TouchPanel.GetState();
        }

        public static Boolean MouseLeftPressDown()
        {
            return newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released;
        }

        public static Boolean MouseLeftUp()
        {
            return newMouseState.LeftButton == ButtonState.Released && oldMouseState.LeftButton == ButtonState.Pressed;
        }

        public static Boolean MouseRightPressDown()
        {
            return newMouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released;
        }

        public static Boolean MouseRightUp()
        {
            return newMouseState.RightButton == ButtonState.Released && oldMouseState.RightButton == ButtonState.Pressed;
        }

        public static IEnumerable<Keys> KeyboardKeyDown()
        {
            return newKeyboardState.GetPressedKeys().Except(oldKeyboardState.GetPressedKeys());
        }

        public static IEnumerable<Keys> KeyboardKeysUp()
        {
            return oldKeyboardState.GetPressedKeys().Except(newKeyboardState.GetPressedKeys());
        }

        public static TouchCollection Taps()
        {
            return touchPanelState;
        }
    }
}
