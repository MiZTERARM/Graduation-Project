using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollisions11 : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogManager11.instance.CallDialog();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogManager11.instance.HideBut();
        }
    }
}
