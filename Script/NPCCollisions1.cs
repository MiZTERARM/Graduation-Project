using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCollisions1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogManager1.instance.CallDialog();
            QuestManager.instance.EndDialogue();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogManager1.instance.HideBut();
        }
    }

}
