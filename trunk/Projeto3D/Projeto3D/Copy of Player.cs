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
    class Player : Objeto3D
    {
        public static Player Self;
        public bool levandoDano;
        public int vida,
                   contagemLevandoDano;
        public bool cameraLenta;

        int scale;
        float   velocidade;
        private List<Player> playerLives;

        int contadorTiro;

        MouseState mouse;
        MouseState mouseAntigo;
               

        public Player(Model model)
            : base(model)
        {
            scale = 1;
            Self = this;
            contadorTiro = 10;
            velocidade = 0.5f;

            vida = 3;
            levandoDano = false;
            contagemLevandoDano = 0;
            cameraLenta = false;
        }

        public override void Update(GameTime gameTime)
        {

            #region Mouse
            mouse = Mouse.GetState();

                if (mouse.LeftButton == ButtonState.Pressed &&
                    mouseAntigo.LeftButton == ButtonState.Released)
                {

                    Vector3 destino = Camera3D.self.MousePosition(Mouse.GetState());

                    double angleRadian = Math.Atan2((double)(this.posicao.X - destino.X), (double)(this.posicao.Z - destino.Z));
                    float angleDegrees = -MathHelper.ToDegrees((float)angleRadian);
                    
                    TiroManagem.AddTiro(this.posicao, angleDegrees);

                }

            mouseAntigo = mouse;
            #endregion

            if (levandoDano)
            {
                contagemLevandoDano ++;
                #region Piscando
                
                if (contagemLevandoDano == 1)
                {
                    this.vida -= 1;
                    this.visible = false;
                }
                
                if (contagemLevandoDano == 10)
                {
                    this.visible = true;                    
                }

                if (contagemLevandoDano == 20)
                {
                    this.visible = false;                    
                }
                
                if (contagemLevandoDano == 30)
                {
                    this.visible = true;
                }
                
                if (contagemLevandoDano == 40)
                {
                    this.visible = false;
                }
                
                if (contagemLevandoDano == 50)                                       
                {
                    this.visible = true;
                }

                if (contagemLevandoDano == 60)
                {
                    this.visible = false;                    
                }
                if (contagemLevandoDano == 60)
                {
                    this.visible = true;
                    levandoDano = false;
                    contagemLevandoDano = 0;
                }
                                
                #endregion

            }

            if (mouse.LeftButton == ButtonState.Pressed &&
               mouseAntigo.LeftButton == ButtonState.Pressed)
            {
                contadorTiro--;
                Console.WriteLine(contadorTiro);

                if (contadorTiro == 0)
                {
                    contadorTiro = 10;

                    Vector3 destino = Camera3D.self.MousePosition(Mouse.GetState());

                    double angleRadian = Math.Atan2((double)(this.posicao.X - destino.X), (double)(this.posicao.Z - destino.Z));
                    float angleDegrees = -MathHelper.ToDegrees((float)angleRadian);

                    TiroManagem.AddTiro(this.posicao, angleDegrees);
                }

            }

            MoverPlayer();

            base.Update(gameTime);

        }

        public void MoverPlayer()
        {
            #region Camera Lenta
            
            //estado de texte tranformar em CameraLenta()
            if (cameraLenta == false)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    this.posicao.Z += (float)velocidade;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    this.posicao.Z -= (float)velocidade;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    this.posicao.X += (float)velocidade;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    this.posicao.X -= (float)velocidade;
                }
            }

            else if (cameraLenta == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    this.posicao.Z += ((float)velocidade)/2;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    this.posicao.Z -= ((float)velocidade) / 2;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    this.posicao.X += ((float)velocidade) / 2;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    this.posicao.X -= ((float)velocidade) / 2;
                }
            }
            #endregion
        }


        public void LimitarMovimentoPlayer()
        {
            if (this.posicao.X >= 33)
            {
                this.posicao.X = 33;
            }

            
        }

       
        
        public void TomandoDano()
        {   
            levandoDano = true;
        }

    }
}
