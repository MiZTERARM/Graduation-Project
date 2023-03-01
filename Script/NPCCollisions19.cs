using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollisions19 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogManager19.instance.CallDialog();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogManager19.instance.HideBut();
        }
    }
}
