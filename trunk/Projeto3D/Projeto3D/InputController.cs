using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Projeto3D
{
    static class InputController
    {
        public static KeyboardState teclado;
        public static KeyboardState oldTeclado;
        public static MouseState mouse;
        public static MouseState oldMouse;

        public static List<Keys> keysPressed = new List<Keys>();

        public static void getState()
        {
            oldTeclado = teclado;
            oldMouse = mouse;
            teclado = Keyboard.GetState();
            mouse = Mouse.GetState();

            Keys[] keys = teclado.GetPressedKeys();

            foreach (Keys keyPressed in keys)
            {
                if (!keysPressed.Contains(keyPressed))
                {
                    keysPressed.Add(keyPressed);
                }
            }

            foreach (Keys keyPressed in keysPressed)
            {
                if (teclado.IsKeyUp(keyPressed))
                {
                    keysPressed.Remove(keyPressed);
                    break;
                }
            }
        }

        public static bool isKeyJustPressed(Keys key)
        {
            if (teclado.IsKeyDown(key) && oldTeclado.IsKeyUp(key))
            {
                return true;
            }

            return false;
        }
    }
}
