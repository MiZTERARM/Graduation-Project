using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour
{
    public void FullScreen(bool is_fullscreen)
    {
        Screen.fullScreen = is_fullscreen;

        Debug.Log("Fullscreen is"+is_fullscreen);
    }
}
