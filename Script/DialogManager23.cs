using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager23 : MonoBehaviour
{
    public static DialogManager23 instance;

    public GameObject dialogUI;
    public GameObject context;

    private void Awake()
    {
        instance = this;
    }

    public void CallDialog()
    {
        dialogUI.SetActive(true);
        context.SetActive(true);
    }

    public void HideBut()
    {
        dialogUI.SetActive(false);
        context.SetActive(false);
    }
}
