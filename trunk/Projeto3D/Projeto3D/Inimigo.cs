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
    class Inimigo : Objeto3D
    {
        public int vida;

        public float velocidadeMax, aceleracao, velocidadeSlow;
        public Vector3 velocidade;

        public bool cameraLenta;


        public Inimigo(Model modelo)
            : base(modelo)
        {

            velocidadeMax = 1;
            aceleracao = 0.01f;
            vida = 100;

            cameraLenta = false;
            velocidade = Vector3.Zero;

        }


        public override void Update(GameTime gameTime)
        {
            //Console.WriteLine("Oi");

            this.aceleracao = 0.01f;

            if (Player.Self.posicao.X <= this.posicao.X)
            {
                this.velocidade.X = MathHelper.Lerp(this.velocidade.X, -velocidadeMax, aceleracao);
            }

            if (Player.Self.posicao.X >= this.posicao.X)
            {
                this.velocidade.X = MathHelper.Lerp(this.velocidade.X, velocidadeMax, aceleracao);
            }

            if (Player.Self.posicao.Z <= this.posicao.Z)
            {
                this.velocidade.Z = MathHelper.Lerp(this.velocidade.Z, -velocidadeMax, aceleracao);
            }

            if (Player.Self.posicao.Z >= this.posicao.Z)
            {
                this.velocidade.Z = MathHelper.Lerp(this.velocidade.Z, velocidadeMax, aceleracao);
            }

            #region Camera Lenta

            if (Player.Self.cameraLenta)
            {
                this.posicao += this.velocidade / 2;
            }
            else
            {
                this.posicao += this.velocidade;
            }


            #endregion


            base.Update(gameTime);




        }
    }

}
