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

    public void PlaySong(){ //plays coin clip
        AudioSource.PlayClipAtPoint(Song, Camera.main.transform.position, 0.1f);
    }
     public void PlayGainMoney(){ //plays coin clip
        AudioSource.PlayClipAtPoint(GainMoney, Camera.main.transform.position, 0.1f);
    }
     public void PlayBuilding(){ //
        AudioSource.PlayClipAtPoint(BuildBuilding, Camera.main.transform.position, 0.1f);
    }
     public void PlayCitySounds(){
        AudioSource.PlayClipAtPoint(CitySounds, Camera.main.transform.position, 0.05f);
    }
}
