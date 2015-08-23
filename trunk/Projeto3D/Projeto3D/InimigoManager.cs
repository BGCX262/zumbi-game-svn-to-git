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
   static class InimigoManager
    {

       public static List<Inimigo> listaInimigos = new List<Inimigo>();

       public static Model modeloInimigos;

       public static Random random = new Random();
       
       
       
       public static void criarInimigo(int quantidade)
       {
           if (Pontos.Self.pontos < 150)   //continua nascendo zombie enquanto o player tiver menos de 140 pontos
           {
               for (int i = 0; i <= quantidade; i++)
               {
                   Inimigo inimigo = new Inimigo(modeloInimigos);
                   inimigo.posicao = new Vector3(NextFloat(-40, 80), 0, NextFloat(-40, 80)); //posição onde zombie nasce

                   listaInimigos.Add(inimigo);
               }
           
           
           }
          
       }

       public static void Update(GameTime gameTime)
       {
           foreach (Inimigo inimigoAtual in listaInimigos)
           {
               inimigoAtual.Update(gameTime);
           }

       }
   
        public static void Draw(Camera3D camera)
        {
            foreach (Inimigo inimigoAtual in listaInimigos)
            {
                inimigoAtual.Draw(camera);
                
            }

        }

        public static float NextFloat(float min, float max)
        {
            return (float)(min + (random.NextDouble() * (max - min)));
        }


    }


      











}

