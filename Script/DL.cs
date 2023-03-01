using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DL : MonoBehaviour
{
    public Dialogue dialogue;


    /*  public void TriggerDialogue()
      {
          FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
      }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
            if (other.tag == "Player")
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }

}
