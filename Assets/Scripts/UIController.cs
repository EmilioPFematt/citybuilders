using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public Text TimeText; 
    int month = 1, year = 2022;


    public void goMainMenu(){ //Send to "main" game scene
        SceneManager.LoadScene("MenuScene");
    }

    public void updateText()
    {
        TimeText.text = "Mes/Año: " + month + "/" + year;
    }

    public void startTimer()
    {
        StartCoroutine(MatchTime());
    }

    IEnumerator MatchTime()
    {
        yield return new WaitForSeconds(1);
        month+=1; 
        if(month > 12){
            month = 1; 
            year+=1; 
        }
        updateText();
        StartCoroutine(MatchTime());
    }
}
