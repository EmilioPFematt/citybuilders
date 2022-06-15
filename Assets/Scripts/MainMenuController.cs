//Controls main menu, plasy sounds
//MainMenuController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public MusicController controlMusic;
    public void StartToplay(){ //Send to "main" game scene
        SceneManager.LoadScene("GameScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        controlMusic.PlayBackgroundMusic(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
