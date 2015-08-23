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
    class Coracao : Texture2D
    {
        Texture2D texture;
        Point frameSize = new Point(16, 16);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(14, 1);

        
        int timeSizeLastFrame = 0;
        public override void Update(GameTime gameTime)
        {

             timeSizeLastFrame += gameTime.ElapsedGameTime.Milliseconds;  // definindo frames por segundo no coração para dar suavidade a animação
            if (timeSizeLastFrame > 50)              // 50 = 50 milisegundos = 20fps, o jogo está rodando a 60fps
            {
                timeSizeLastFrame -= 50;
                currentFrame.X++;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                    if (currentFrame.Y >= sheetSize.Y)
                        currentFrame.Y = 0;
                }
            }
}
        public override void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.End();
            Vector2 pos = new Vector2( //posição do primeiro coracao na tela
        (frameSize.X) / 2,
        (frameSize.Y) / 2
        );
            Vector2 pos2 = new Vector2( //posição do segundo coracao na tela
       (frameSize.X) / 2 + 20,
       (frameSize.Y) / 2
       );
            Vector2 pos3 = new Vector2( //posição do terceiro coracao na tela
      (frameSize.X) / 2 + 40,
      (frameSize.Y) / 2
      );
            spriteBatch.Begin();
            
            spriteBatch.Draw(texture, pos,

      new Rectangle(currentFrame.X * frameSize.X,  // desenhando primeiro coração
          currentFrame.Y * frameSize.Y,
          frameSize.X,
          frameSize.Y),
      Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            spriteBatch.Draw(texture, pos2,
      new Rectangle(currentFrame.X * frameSize.X,  // desenhando segundo coração
          currentFrame.Y * frameSize.Y,
          frameSize.X,
          frameSize.Y),
      Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            spriteBatch.Draw(texture, pos3,          // desenhando terceiro coração
      new Rectangle(currentFrame.X * frameSize.X,
          currentFrame.Y * frameSize.Y,
          frameSize.X,
          frameSize.Y),
      Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

        }

       

    }
}
