using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projeto3D.Scenes;

namespace Projeto3D
{

    class Pause : SceneBase
    {


        public Pause()
            : base()
        {
            imagempause = Game1.self.Content.Load<Texture2D>("pause");
            Game1.self.Window.Title = "Pause";

        }

        public override void start()
        {

        }
        public override void terminate()
        {
            
        }

        public override void update(GameTime gameTime)
        {
            InputController.getState();
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                SceneManager.setScene(new Level());
            }
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(imagempause, new Vector2(Game1.self.Window.ClientBounds.Width / 2, Game1.self.Window.ClientBounds.Height / 2), Color.White);

        }

    }
}
