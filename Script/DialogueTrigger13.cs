using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger13 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager13>().StartDialogue(dialogue);
	}
}
