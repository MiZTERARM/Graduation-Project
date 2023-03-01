using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger11 : MonoBehaviour
{
	
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager11>().StartDialogue(dialogue);
	}

}
