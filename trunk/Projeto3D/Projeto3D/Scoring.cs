using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Projeto3D
{
    class Pontos
    {
        public static Pontos Self;
        public float pontos, multiplicador;


        public Pontos()
        {
            Self = this;
            pontos = 0;
            multiplicador = 1;
            
        }

        public void GanharPontos(float pontos)
        {
            this.pontos += pontos * multiplicador;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        
            spriteBatch.DrawString(Game1.self.UIFont, "Pontos: " + this.pontos.ToString(), new Vector2(10, 30), Color.White);
        
        }
    }
}
//    static class Scoring
//    {
//        //Static esta salva dentro da classe
//        //Public e o nivel de protecao dentro da classe

//        static MouseState mouse;
//        static MouseState mouseAntigo;
        
//        //static public Texture2D imgNumeros;
//        static public Rectangle[] pontos = null;

//        static public int pontosNave;

//        //static public bool marcarPonto;

//        static public SpriteFont pontuacao;
        
//        static public void Initialize()
//        {
//             //Em classes estaticas(static) o "this" e o proprio nome da classe

            

//            pontosNave = 0;

//            pontosNave.ToString();

//            pontuacao = Game1.Self.Content.Load<SpriteFont>(@"SpriteFont1");
                    
//        }

//        static public void Update(GameTime gameTime)
//        {
            
//            mouse = Mouse.GetState();

//            //if (Level1.listaMeteoro[Level1.i].hitTestObject(TiroManager.listaTiro[Level1.j]))
//            //{

//            //    marcarPonto = true;
            
            

//            pontosNave += 10;


//            //}

//            mouseAntigo = mouse;

         

//        }


//        static public void Draw(SpriteBatch spriteBatch)
//        {

//            spriteBatch.DrawString(pontuacao,"Score: "+pontosNave, new Vector2(500.0f, 10.0f), Color.Red);
        
//        }



//     }


