using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musica; //array de canciones
    private AudioSource audioManagerSource; //audiosource
    private int songPlaying; //control de que numero de canción estamos reproduciendo
    public string[] nameSong; //array de los nombres de las canciones

    public TextMeshProUGUI songName;

    void Start()
    {
        audioManagerSource = GetComponent<AudioSource>(); //accedemos al audiosource de nuestro audio manager
        audioManagerSource.PlayOneShot(musica[songPlaying]);
         //empezamos reproduciendo la primera canción
    }


    void Update()
    {
        songName.text = nameSong[songPlaying]; //en todo momento mostrará por pantalla que canción está reproduciendo
    }

    public void PlaySong() //funcion para reanudar la canción
    {
        audioManagerSource.UnPause(); //le da a play a la canción actual que tenemos en el audiosource
    }
    public void PauseSong() //pausamos la canción
    {
        audioManagerSource.Pause();
    }

    public void NextSong() //reproducimos la siguiente canción de la lista
    {
        songPlaying++;
        if (songPlaying >= musica.Length) //si estamos en la quinta o última canción y le damos a next nos reproducirá la primera
        {
            songPlaying = 0;
        }
        audioManagerSource.Stop();
        audioManagerSource.PlayOneShot(musica[songPlaying], 1f);
    }

    public void PreviousSong() //reproducimos la anterior canción de la lista
    {
        songPlaying--;
        if (songPlaying<0) //si estamos en la primera canción y le damos a previous nos reproducirá la última
        {
            songPlaying = musica.Length - 1;
        }
        audioManagerSource.Stop();
        audioManagerSource.PlayOneShot(musica[songPlaying]);
    }

    public void RandomSong() //reproduce una canción aleatoria de la playlist
    {
        audioManagerSource.Stop();
        songPlaying = Random.Range(0, musica.Length);
        audioManagerSource.PlayOneShot(musica[songPlaying]);
    }

}
