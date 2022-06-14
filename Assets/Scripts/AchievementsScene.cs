using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchievementsScene : MonoBehaviour
{
    public GameObject Title;
    public GameObject Desc;
    public GameObject LockedImage;
    public GameObject TrophyImage;
    public GameObject LockedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("isAchieved01") == 1){
            LockedImage.SetActive(false);
            TrophyImage.SetActive(true);
            Title.GetComponent<Text>().text = "Comprador Compulsivo!";
            Desc.GetComponent<Text>().text = "Haz comprado 5 edificios!";
            LockedText.GetComponent<Text>().text = "";
        }
    }

    public void returnToGame(){
        SceneManager.LoadScene("GameScene");
    }
}
