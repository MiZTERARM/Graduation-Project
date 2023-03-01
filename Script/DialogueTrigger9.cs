using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger9 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager9>().StartDialogue(dialogue);
	}

}
