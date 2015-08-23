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
    class GameOver : SceneBase
    {
        
        Projeto3D.Objeto2D gameOver;

        public GameOver()
            : base()
        {
            Game1.self.Window.Title = "GAME OVER";
            Game1.self.IsMouseVisible = true;
        }

        public override void start()
        {
            gameOver = new Objeto2D(Game1.self.Content.Load<Texture2D>("GO"));
            gameOver.posicao.X = 512;
            gameOver.posicao.Y = 384;
        }

        public override void terminate()
        {
            
        }

        public override void update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                SceneManager.setScene(new Menu());
            }
        }
        
        public override void draw(SpriteBatch spriteBatch)
        {
            gameOver.Draw(spriteBatch);
        }
    }
}
