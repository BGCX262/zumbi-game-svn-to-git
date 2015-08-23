using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projeto3D
{
    abstract class SceneBase
    {
        public abstract void start();
        public abstract void update(GameTime gameTime);
        public abstract void draw(SpriteBatch spriteBatch);
        public abstract void terminate();
    }
}
