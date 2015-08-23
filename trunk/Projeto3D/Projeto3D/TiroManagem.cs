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
    class TiroManager
    {
        static public List<Tiro> listaTiro;
        static public Model modeloTiros;


        static public void Initialize(Model modeloTiros)
        {
            TiroManager.modeloTiros = modeloTiros;
            TiroManager.listaTiro = new List<Tiro>();
        }

        static public void AddTiro(Vector3 posicao, float angulo)
        {
            Tiro tiro;
            tiro = new Tiro(modeloTiros,angulo);
            tiro.posicao = posicao;
            listaTiro.Add(tiro);
        }

        static public void Draw(Camera3D camera)
        {
            for (int i = 0; i < listaTiro.Count; i++)
            {
                listaTiro[i].Draw(camera);
            }
        }

        static public void Update(GameTime gameTime)
        {
            for (int i = 0; i < listaTiro.Count; i++)
            {
                listaTiro[i].update();
            }
        }
    }
}
