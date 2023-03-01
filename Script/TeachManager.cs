using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachManager : MonoBehaviour
{
    public static TeachManager instance;

    public GameObject TeachUI;
    public GameObject context;

    private void Awake()
    {
        instance = this;
    }

    public void CallTeach()
    {
        TeachUI.SetActive(true);
        context.SetActive(true);
    }

    public void HideTeach()
    {
        TeachUI.SetActive(false);
        context.SetActive(false);
    }
}
