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
    class Tiro : Objeto3D
    {

        float velocidade,
              angulo;
        public bool cameraLenta;

        public Tiro(Model model, float angulo)
            : base(model)
        {
            this.angulo = angulo;

            velocidade = 0.5f;

            cameraLenta = false;
        }

        public void update()
        {
            #region Camera Lenta
            
            //estado de texte tranformar em CameraLenta()            
            if (cameraLenta == false)
            {
                this.posicao.Z -= (float)Math.Cos(MathHelper.ToRadians(angulo)) * velocidade;
                this.posicao.X += (float)Math.Sin(MathHelper.ToRadians(angulo)) * velocidade;
            }
            this.escala = new Vector3(0.5f, 0.5f, 0.5f);

            if (cameraLenta == true)
            {
                this.posicao.Z -= (float)Math.Cos(MathHelper.ToRadians(angulo)) * velocidade/2;
                this.posicao.X += (float)Math.Sin(MathHelper.ToRadians(angulo)) * velocidade/2;
            }
            
            #endregion
        }

    }
}
