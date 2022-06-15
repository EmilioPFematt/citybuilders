//José Carlos de la Torre Hernández A01235953
//Script para pausar
//PauseMenu.cs 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuControl : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public void PauseGame(){ //controls the flow of pause and resume 
        if(GameIsPaused){
            Resume();
        }
        else{
            Pause();
        }
    }
    public void Resume(){ //continues time, changes the bool for the if in the PauseGame function, and destroys the pause menu
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause(){ //stops time, changes the bool for the if in the PauseGame function, and displays the pause menu
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void goToTrophies(){
        Resume();
        SceneManager.LoadScene("AchievementsScene");
    }
}
