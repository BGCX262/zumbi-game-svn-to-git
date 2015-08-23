using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Projeto3D
{
    class Objeto2D
    {
        public Texture2D textura;
        public Color cor;
        public Vector2 posicao;
        public Vector2 vetorOrigem;
        public Vector2 vetorEscala;
        public float rotacao;
        public float alpha;
        public bool visible;
        public Rectangle collisionBounds;
        public Rectangle retanguloDeCorte;
        public SpriteEffects efeito;
        // camada


        public Objeto2D(Texture2D textura)
        {
            this.textura = textura;
            posicao = new Vector2(200 , 200);
            cor = Color.White;
            rotacao = 0;
            vetorOrigem = new Vector2(textura.Width/2 , textura.Height/2);
            vetorEscala = new Vector2(1 , 1);
            visible = true;
            alpha = 1;
            calcularRetangulo();

            retanguloDeCorte = new Rectangle(0, 0, textura.Width, textura.Height);

            efeito = SpriteEffects.None;
        }

        public void calcularRetangulo()
        {
            collisionBounds = new Rectangle( (int)(posicao.X - (vetorOrigem.X * vetorEscala.X) ),
                (int)(posicao.Y - (vetorOrigem.Y * vetorEscala.Y)), 
                (int)(textura.Width * vetorEscala.X), (int)(textura.Height * vetorEscala.Y));
        }

        public bool hitTestObject(Objeto2D objeto)
        {
            this.calcularRetangulo();
            objeto.calcularRetangulo();

            
           
            if (this.collisionBounds.Intersects(objeto.collisionBounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible==true)
            {
                spriteBatch.Draw(textura, posicao, retanguloDeCorte, cor * alpha, MathHelper.ToRadians(rotacao), vetorOrigem, vetorEscala, efeito, 0.5f);
                
            }

        }
    }
}
