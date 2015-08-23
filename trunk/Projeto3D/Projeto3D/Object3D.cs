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
    class Objeto3D
    {
        Model modelo;

        public Vector3 posicao, velocidade;
        public Vector3 rotacao;
        public Vector3 escala;

        private Vector3 tamanhoBox;

        public Boolean recalcularBox, boxCalculada;

        //Texture2D textura;
        BoundingBox boundingBox;


        public Boolean visible;


        public Objeto3D(Model modelo)
        {
            this.modelo = modelo;

            posicao = new Vector3(0, 0, 0);
            rotacao = new Vector3(0, 0, 0);
            escala = new Vector3(1, 1, 1);



            visible = true;
            // textura = Game1.Self.Content.Load<Texture2D>("Alien Probe/textures/Probe_col");
        }

        public virtual void Update(GameTime gameTime)
        {
            //Console.WriteLine(Player.Self.posicao);
        }

        public Matrix worldMatrx
        {
            get
            {
                Matrix matriz = Matrix.Identity
                    * Matrix.CreateScale(escala)
                    * Matrix.CreateRotationX(MathHelper.ToRadians(rotacao.X))
                    * Matrix.CreateRotationY(MathHelper.ToRadians(rotacao.Y))
                    * Matrix.CreateRotationZ(MathHelper.ToRadians(rotacao.Z))
                    * Matrix.CreateTranslation(posicao);



                return matriz;
            }
        }

        public void CalcularBox()
        {
            if (recalcularBox)
            {
                calcularTamanhoBox();
            }
            else
            {
                if (boxCalculada)
                {
                    posicionarBox();
                }
                else
                {
                    calcularTamanhoBox();
                }
            }
        }

        private void posicionarBox()
        {
            boundingBox = new BoundingBox(
                posicao - tamanhoBox / 2,
                posicao + tamanhoBox / 2);
        }

        private void calcularTamanhoBox()
        {
            boxCalculada = true;

            //Inicia os cantos da caixa com valores maximo e minimo
            Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            //para cada malha e submalha no modelo
            foreach (ModelMesh mesh in modelo.Meshes)
            {
                foreach (ModelMeshPart meshPart in mesh.MeshParts)
                {
                    //Texture2D[] texturas = new Texture2D[5];
                    int vertexStride = meshPart.VertexBuffer.VertexDeclaration.VertexStride;//o número de bytes de um vértice para o próximo
                    int vertexBufferSize = meshPart.NumVertices * vertexStride;//o tamanho do buffer (array) de vértices
                    float[] vertexData = new float[vertexBufferSize / sizeof(float)];//um array [] com o tamanho certo para caber o vertexBufferSize
                    meshPart.VertexBuffer.GetData<float>(vertexData);//pegar GetData a informação de float e preencher o buffer de vértices
                    //percorrer de i = 0 até o tamanho do buffer de vértices em float andando de float em float (ver cada ponto)
                    for (int i = 0; i < vertexBufferSize / sizeof(float); i += vertexStride / sizeof(float))
                    {
                        //cria um vertor transformado com os tres pontos em relação ao mundo
                        Vector3 transformedPosition = Vector3.Transform(new Vector3(vertexData[i], vertexData[i + 1], vertexData[i + 2]), worldMatrx);

                        //calcula os pontos, o mínimo e o máximo
                        min = Vector3.Min(min, transformedPosition);
                        max = Vector3.Max(max, transformedPosition);

                    }
                }
            }

            boundingBox = new BoundingBox(min, max);
            tamanhoBox = max - min;
        }

        public Boolean hitTestObject(Objeto3D objeto)
        {
            this.CalcularBox();
            objeto.CalcularBox();

            ContainmentType tipoColisao = this.boundingBox.Contains(objeto.boundingBox);

            if (tipoColisao != ContainmentType.Disjoint)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Draw(Camera3D camera)
        {
            //modelo.Draw(worldMatrx, camera.View, camera.projecao);
            if (visible)
            {
                if (this is Tiro)
                {

                }

                if (this is Inimigo)
                {

                }

                foreach (ModelMesh malha in modelo.Meshes)
                {


                    foreach (BasicEffect efeito in malha.Effects)
                    {

                        efeito.World = worldMatrx;
                        efeito.View = camera.View;
                        efeito.Projection = camera.projection;
                        //basicEffect.Texture = textura;
                        //basicEffect.TextureEnabled = true;
                        efeito.EnableDefaultLighting();



                        //basicEffect.LightingEnabled = true;
                        //basicEffect.DirectionalLight0.DiffuseColor = new Vector3(0.5f, 0, 0);
                        //basicEffect.DirectionalLight0.Direction = new Vector3(1, 0, 0);
                        //basicEffect.DirectionalLight0.SpecularColor = new Vector3(0, 0, 1);

                        //basicEffect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f);
                        //efeito.EmissiveColor = Color.Yellow.ToVector3();

                        //basicEffect.DirectionalLight1.Enabled = true;
                        //basicEffect.DirectionalLight1.Direction = new Vector3(22, 11, 56);
                        //basicEffect.DirectionalLight1.SpecularColor = Color.Black.ToVector3();
                        //basicEffect.DirectionalLight1.DiffuseColor = Color.Yellow.ToVector3();

                        //basicEffect.DirectionalLight2.Enabled = true;
                        //basicEffect.DirectionalLight2.Direction = new Vector3(-22, -11, -56);
                        //basicEffect.DirectionalLight2.SpecularColor = Color.Green.ToVector3();
                        //basicEffect.DirectionalLight2.DiffuseColor = Color.Purple.ToVector3();

                        //basicEffect.AmbientLightColor = Color.Green.ToVector3();

                        //basicEffect.FogEnabled = true;
                        //basicEffect.FogColor = Color.Black.ToVector3(); 
                        //basicEffect.FogStart = 80;
                        //basicEffect.FogEnd = 300;

                        //basicEffect.EmissiveColor = Color.Purple.ToVector3();


                        //basicEffect.LightingEnabled = true;
                        //basicEffect.Alpha = 0.5f;

                        //subMalha.Effect = basicEffect;
                    }
                    malha.Draw();
                }
            }
        }
    }
}
