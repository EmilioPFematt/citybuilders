//Script para controllar muscia y efectos de sonido
//MusicoController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip Song;
    public AudioClip GainMoney;
    public AudioClip BuildBuilding;
    public AudioClip CitySounds;
    public AudioSource origin;
    public AudioClip background;
    bool state = true;
    public void PlaySong(){ //plays coin clip
        AudioSource.PlayClipAtPoint(Song, Camera.main.transform.position, 0.1f);
    }
    public void PlayBackgroundMusic(bool state)
    {
        origin = GetComponent<AudioSource>();
        origin.clip = background;
        if (state)
        {
            origin.loop = true;
            origin.Play();
        }
        else
        {
            origin.loop = false;
            origin.Stop();
        }

    }
    public void change_state_background_music()
    {
        state = !state;
        PlayBackgroundMusic(state);
    }
     public void PlayGainMoney(){ //plays coin clip
        if (state)
        {
            AudioSource.PlayClipAtPoint(GainMoney, Camera.main.transform.position, 0.1f);
        }
        
    }
     public void PlayBuilding(){ //
        if (state)
        {
            AudioSource.PlayClipAtPoint(BuildBuilding, Camera.main.transform.position, 0.1f);
        }
        
    }
     public void PlayCitySounds(){
        if (state)
        {
            AudioSource.PlayClipAtPoint(CitySounds, Camera.main.transform.position, 0.05f);
        }
    }
}
