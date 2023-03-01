using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollisions5 : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogManager5.instance.CallDialog();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogManager5.instance.HideBut();
        }
    }
}
