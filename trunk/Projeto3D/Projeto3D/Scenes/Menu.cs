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
    class Menu:SceneBase
    {
        
        Projeto3D.Objeto2D menu;
        
        public Menu()
            : base()
        {
            Game1.self.Window.Title = "Menu";
            Game1.self.IsMouseVisible = true;
        }

        public override void start()
        {
            menu = new Objeto2D(Game1.self.Content.Load<Texture2D>("bg"));
            menu.posicao.X = 512;
            menu.posicao.Y = 384;
            
        }

        public override void terminate()
        {
            //SceneManager.setScene(new Level());
        }

        public override void update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                SceneManager.setScene(new Level());
            }            
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);

            //spriteBatch.DrawString(Game1.self.UIFont, "To Start Game Press Enter", new Vector2(Game1.self.GraphicsDevice.Viewport.Width / 2, Game1.self.GraphicsDevice.Viewport.Height / 2), Color.Blue);            
        }
    }
}
