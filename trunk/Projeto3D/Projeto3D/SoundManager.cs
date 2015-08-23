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


namespace WindowsaGame1
{
    static class SoundManager
    {



        static Dictionary<String, Song> listaMusicas = new Dictionary<String, Song>();
        static Dictionary<String, SoundEffect> listaSons = new Dictionary<String, SoundEffect>();
        //static SoundEffectInstance instancia;

        static public float volumeMusica = 1;
        static public float volumeSom = 1;

        static public void AddMusic(string nome, Song musica)
        {
            listaMusicas.Add(nome, musica);
        }

        static public void PlayMusic(String nome)
        {
            MediaPlayer.Play(listaMusicas[nome]);

        }


        static public void StopMusic(String nome)
        {

            MediaPlayer.Stop();

        }



        static public void AddSom(string nome, SoundEffect som)
        {
            listaSons.Add(nome, som);
        }

        static public void PlaySound(String nome)
        {
            SoundEffectInstance instancia = listaSons[nome].CreateInstance();
            instancia.Volume = volumeSom;
            instancia.Play();
            //instancia.Apply3D

        }

        //Uma função que pare a musica

        static public void PauseMusic(String nome)
        {

            MediaPlayer.Pause();

        }

        static public void ResumeMusic(String nome)
        {

            MediaPlayer.Resume();

        }

        public static void ApplyVolume()
        {
            MediaPlayer.Volume = volumeMusica;
        }

    }
}

       
       



    
