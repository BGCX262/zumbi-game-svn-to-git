using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projeto3D
{
    static class SceneManager
    {
        private static SceneBase current;

        public static void setScene(SceneBase scene)
        {
            if (current != null)
                current.terminate();

            current = scene;

            if (current != null)
                current.start();
        }

        public static void restartScene()
        {
            current.terminate();
            current.start();
        }

        public static bool update(GameTime gameTime)
        {
            //Se a cena não existir, pare.
            if (current == null)
            {
                return false;
            }
            //Se a cena existir
            else
            {
                current.update(gameTime);

                return true;
            }
        }

        public static bool draw(SpriteBatch spriteBatch)
        {
            if (current == null)
            {
                return false;
            }
            else
            {
                current.draw(spriteBatch);

                return true;
            }
        }
    }
}
