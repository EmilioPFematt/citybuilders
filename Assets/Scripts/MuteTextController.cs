using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteTextController : MonoBehaviour
{
    public Text button;
    string mute = "Mute";
    string unmute = "Unmute";
    bool muted = false;
    private void Start()
    {

    }
    public void switchtext()
    {
        muted = !muted;
        if (muted)
        {
            button.text = unmute;
        }
        else
        {
            button.text = mute;
        }
    }
}
