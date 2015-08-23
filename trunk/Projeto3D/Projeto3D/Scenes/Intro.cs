using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Projeto3D.Scenes
{
    class Intro:SceneBase
    {

       
        public Intro()
            : base()
        {
            image = Game1.self.Content.Load<Texture2D>("bg");
            Game1.self.Window.Title = "Intro";
          
        }

        public override void start()
        {

        }
        public override void terminate()
        {
            //SceneManager.setScene(new Menu());
        }

        public override void update(GameTime gameTime)
        {
            InputController.getState();
            if (InputController.isKeyJustPressed(Keys.Enter))
            {
                SceneManager.setScene(new Menu());
            }
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, new Vector2(Game1.self.Window.ClientBounds.Width/2,Game1.self.Window.ClientBounds.Height/2), Color.White);
          
        }

    }
}
