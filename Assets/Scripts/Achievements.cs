using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public GameObject aNote;
    public AudioSource aSound;
    public bool aActive = false;
    public GameObject aTitle;
    public GameObject aDesc;

    public GameObject a01Image;
    public static int a01Count;
    public int a01Trigger = 5;
    public int a01Code;
    public int a01Achieved;


    // Update is called once per frame
    void Start()
    {
        PlayerPrefs.SetInt("Ach01", 0);
        PlayerPrefs.SetInt("isAchieved01", 0);
    }
    void Update()
    {
        a01Code = PlayerPrefs.GetInt("Ach01");
        if (a01Count == a01Trigger && a01Code != 12345)
        {
            StartCoroutine(TriggerA01());
            PlayerPrefs.SetInt("isAchieved01", 1);
        }
    }

    IEnumerator TriggerA01(){
        aActive = true;
        a01Code = 12345;
        PlayerPrefs.SetInt("Ach01", a01Code);
        aSound.Play();
        a01Image.SetActive(true);
        aTitle.GetComponent<Text>().text = "Comprador Compulsivo!";
        aDesc.GetComponent<Text>().text = "Haz comprado 5 edificios!";
        aNote.SetActive(true);
        yield return new WaitForSeconds(5);

        //reset UI
        aNote.SetActive(false);
        a01Image.SetActive(false);
        aTitle.GetComponent<Text>().text = "";
        aDesc.GetComponent<Text>().text = "";
        aActive = false;
        
    }

    public void goToTrophies(){
        SceneManager.LoadScene("AchievementsScene");
    }
}
