using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musica; //array de canciones
    private AudioSource audioManagerSource; //audiosource
    private int songPlaying; //control de que numero de canci�n estamos reproduciendo
    public string[] nameSong; //array de los nombres de las canciones

    public TextMeshProUGUI songName;

    void Start()
    {
        audioManagerSource = GetComponent<AudioSource>(); //accedemos al audiosource de nuestro audio manager
        audioManagerSource.PlayOneShot(musica[songPlaying]);
         //empezamos reproduciendo la primera canci�n
    }


    void Update()
    {
        songName.text = nameSong[songPlaying]; //en todo momento mostrar� por pantalla que canci�n est� reproduciendo
    }

    public void PlaySong() //funcion para reanudar la canci�n
    {
        audioManagerSource.UnPause(); //le da a play a la canci�n actual que tenemos en el audiosource
    }
    public void PauseSong() //pausamos la canci�n
    {
        audioManagerSource.Pause();
    }

    public void NextSong() //reproducimos la siguiente canci�n de la lista
    {
        songPlaying++;
        if (songPlaying >= musica.Length) //si estamos en la quinta o �ltima canci�n y le damos a next nos reproducir� la primera
        {
            songPlaying = 0;
        }
        audioManagerSource.Stop();
        audioManagerSource.PlayOneShot(musica[songPlaying], 1f);
    }

    public void PreviousSong() //reproducimos la anterior canci�n de la lista
    {
        songPlaying--;
        if (songPlaying<0) //si estamos en la primera canci�n y le damos a previous nos reproducir� la �ltima
        {
            songPlaying = musica.Length - 1;
        }
        audioManagerSource.Stop();
        audioManagerSource.PlayOneShot(musica[songPlaying]);
    }

    public void RandomSong() //reproduce una canci�n aleatoria de la playlist
    {
        audioManagerSource.Stop();
        songPlaying = Random.Range(0, musica.Length);
        audioManagerSource.PlayOneShot(musica[songPlaying]);
    }

}
