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

namespace Projeto3D.Scenes
{
    class Level : SceneBase
    {
        bool paused = false;
        Player player;
        Camera3D camera;
        Pontos pontos;
        Random random;
        
        Objeto2D background,backgroundslow;
        Texture2D texture,zombie,pausedTexture,slowmotionbar;
        Vector2 slowposition;
        Rectangle pausedRectangle, slowRectangle;
        Point frameSize = new Point(16, 16);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(14, 1);
        Point frameSize2 = new Point(73, 73);
        Point currentFrame2 = new Point(0, 0);
        Point sheetSize2 = new Point(4, 4);
        int quantidadeInimigos;

        float timer = 0.5f, timerslow = 5;         // Inicia timer de 0,5 segundo
        const float TIMER = 0.5f, TIMERSLOW = 5;

        public Level()
            : base()
        {
            Game1.self.Window.Title = "Another Game Of Zombie";

        }

        public override void start()
        {
            background = new Objeto2D(Game1.self.Content.Load<Texture2D>("fundo"));
            background.posicao.X = 512;
            background.posicao.Y = 384;

            backgroundslow = new Objeto2D(Game1.self.Content.Load<Texture2D>("fundoslow"));
            backgroundslow.posicao.X = 512;
            backgroundslow.posicao.Y = 384;

            texture = Game1.self.Content.Load<Texture2D>("coracaovida");
            zombie = Game1.self.Content.Load<Texture2D>("Zombie_Tank");
            pausedTexture = Game1.self.Content.Load<Texture2D>("pause");
            pausedRectangle = new Rectangle(0, 0, 1024, 768);
            slowmotionbar = Game1.self.Content.Load<Texture2D>("slowmotionbar");
            slowposition = new Vector2(330, 600);
            slowRectangle = new Rectangle(0, 0, slowmotionbar.Width, slowmotionbar.Height);

            player = new Player(Game1.self.Content.Load<Model>("player"));

            InimigoManager.modeloInimigos = Game1.self.Content.Load<Model>("inimigo");

            pontos = new Pontos();

            TiroManager.Initialize(Game1.self.Content.Load<Model>("player"));

            camera = new Camera3D();

            random = new Random();


            //quantidadeInimigos = 4;
            InimigoManager.criarInimigo(quantidadeInimigos);

        }

        public override void terminate()
        {
            camera = null;
            player = null;
        }
        int timeSizeLastFrame = 0;
        int timeSizeLastFrame2 = 0;
        public override void update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

           
            
            if (!paused)  // se não estiver pausado, inicia o timer para poder pausar quando apertar P.
            {
                timer -= elapsed;
                if (timer < 0)
                {
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                {
                    paused = true;
                    timer = TIMER;
                }
                }
            timeSizeLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            timeSizeLastFrame2 += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSizeLastFrame > 50)
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


            if (timeSizeLastFrame2 > 100)
            {
                timeSizeLastFrame2 -= 100;
                currentFrame2.X++;

                if (currentFrame2.X >= sheetSize2.X)
                {
                    currentFrame2.X = 0;

                    currentFrame2.Y++;

                    if (currentFrame2.Y >= sheetSize2.Y)
                        currentFrame2.Y = 0;

                }
            }




            if (Player.Self.posicao.X >= 26.0f)
            {
                Player.Self.posicao.X = 26.0f;  // colisao do player com o lado direito e esquerdo da tela 
            }
            else if (Player.Self.posicao.X <= -26.0f)
            {
                Player.Self.posicao.X = -26.0f;  // ----------------------------------------
            }
            if (Player.Self.posicao.Z <= -19.3f)
            {
                Player.Self.posicao.Z = -19.3f;  // colisao do player com o lado de cima e de baixo da tela 
            }
            else if (Player.Self.posicao.Z >= +19.3f)
            {
                Player.Self.posicao.Z = +19.3f;
            }





            TiroManager.Update(gameTime);

            for (int t = 0; t < TiroManager.listaTiro.Count; t++)
            {
                Tiro umTiro = TiroManager.listaTiro[t];

                for (int i = 0; i < InimigoManager.listaInimigos.Count; i++)
                {

                    Inimigo inimigoUm = InimigoManager.listaInimigos[i];

                    if (umTiro.hitTestObject(inimigoUm))
                    {
                        if (umTiro.visible == true)
                            TiroManager.listaTiro.Remove(umTiro);
                        pontos.GanharPontos(10);
                        InimigoManager.listaInimigos.Remove(inimigoUm);
                    }

                }

            }

            InimigoManager.Update(gameTime);

            if (InimigoManager.listaInimigos.Count == 0)
            {
                quantidadeInimigos++;
                InimigoManager.criarInimigo(quantidadeInimigos);
            }

            for (int t = 0; t < InimigoManager.listaInimigos.Count; t++)
            {
                Inimigo inimigoUm = InimigoManager.listaInimigos[t];
                if (inimigoUm.hitTestObject(player))
                {
                    player.TomandoDano();
                }
            }
            player.Update(gameTime);
            if (player.vida == 0)
            {
                SceneManager.setScene(new GameOver());
            }

           
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        {
                            slowRectangle.Width -= 5;


                        }
            else if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {

                slowRectangle.Width = 340;
            }

            
            
            for (int t = 0; t < TiroManager.listaTiro.Count; t++)
            {
                Tiro tiroLento = TiroManager.listaTiro[t];

                for (int u = 0; u < InimigoManager.listaInimigos.Count; u++)
                {
                    Inimigo inimigoLento = InimigoManager.listaInimigos[u];


                    try
                    {

                        if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        {

                            if (slowRectangle.Width < 20)   // se o tamanho da barra de slow motion for menor que 20, desativa o slow motion
                            {
                                player.cameraLenta = false;
                                inimigoLento.cameraLenta = false;
                                tiroLento.cameraLenta = false;

                            }
                            else    // senão continua ativado
                            {
                                player.cameraLenta = true;
                                inimigoLento.cameraLenta = true;
                                tiroLento.cameraLenta = true;
                            }
                        }
                        else if (Keyboard.GetState().IsKeyUp(Keys.Space))
                        {
                            if (player != null)
                            {
                                player.cameraLenta = false;
                                inimigoLento.cameraLenta = false;
                                tiroLento.cameraLenta = false;
                                
                            }
                        }
                    }

                    catch (NullReferenceException exception) { var trace = new System.Diagnostics.StackTrace(exception); }
                }
            }
            
            }
        
            else if (paused) // Se estiver pausado, inicia o timer para poder pausar quando apertar P
            {
                timer -= elapsed;
                
                    if (Keyboard.GetState().IsKeyDown(Keys.P))
                    {
                        if (timer < 0)
                        {

                            paused = false;
                            timer = TIMER; // zera o timer
                        }
                        
                       
                        
                    }
                
            }
            
        }
           
            //camera.lookAt = player.posicao;
            //camera.position = player.posicao + new Vector3(0, 50, 5);
       



        public override void draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
            Vector2 pos = new Vector2(
        (frameSize.X) / 2,
        (frameSize.Y) / 2);
                
            Vector2 pos2 = new Vector2(
        (frameSize.X) / 2 + 20,
        (frameSize.Y) / 2
        );

            Vector2 pos3 = new Vector2(
        (frameSize.X) / 2 + 40,
        (frameSize.Y) / 2
        );

            Vector2 pos4 = new Vector2(
        (frameSize2.X) / 2 + 200,
        (frameSize2.Y) / 2 + 200
        );


            spriteBatch.End();
            
            spriteBatch.Begin();
            
            background.Draw(spriteBatch);

            if (player.vida == 1 || player.vida == 2 || player.vida == 3) // desenha o primeiro coração se tiver 1 , 2 ou 3 vidas
            {
                spriteBatch.Draw(texture, pos,
           new Rectangle(currentFrame.X * frameSize.X,
               currentFrame.Y * frameSize.Y,
               frameSize.X,
               frameSize.Y),
           Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
            if (player.vida == 2 || player.vida == 3)  // desenha o segundo coração se tiver 2 ou 3 vidas
                {
                    spriteBatch.Draw(texture, pos2,
               new Rectangle(currentFrame.X * frameSize.X,
                   currentFrame.Y * frameSize.Y,
                   frameSize.X,
                   frameSize.Y),
               Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);


                    
                }

            if (player.vida == 3)  // desenha o terceiro coração se tiver 1 , 2 ou 3 vidas
                {
                    spriteBatch.Draw(texture, pos3,
                        new Rectangle(currentFrame.X * frameSize.X,
                        currentFrame.Y * frameSize.Y,
                        frameSize.X,
                        frameSize.Y),
                        Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                    
                }

            if (Pontos.Self.pontos >= 150)  // se tiver 150 pontos, nasce o boss

            {
            spriteBatch.Draw(zombie, pos4,
                   new Rectangle(currentFrame2.X * frameSize2.X,
                       currentFrame2.Y * frameSize2.Y,
                       frameSize2.X,
                       frameSize2.Y),
                   Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            }

            pontos.Draw(spriteBatch);

            
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && slowRectangle.Width >= 20) //desenha a fumaça de fundo da camera lenta e tira a fumaça quando a barra acabar.
            {
                backgroundslow.Draw(spriteBatch);
                spriteBatch.Draw(slowmotionbar, slowposition, slowRectangle, Color.White);
                
            }
            
            spriteBatch.End();
            spriteBatch.Begin();
              player.Draw(camera);
            TiroManager.Draw(camera);
            InimigoManager.Draw(camera);

            if (paused)
            {
                spriteBatch.Draw(pausedTexture, pausedRectangle, Color.White);

            }

        }
    }
}


