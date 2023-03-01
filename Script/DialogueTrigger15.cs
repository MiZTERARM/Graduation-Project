using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger15 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager15>().StartDialogue(dialogue);
	}

}
