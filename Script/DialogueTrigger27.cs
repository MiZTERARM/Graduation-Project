using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger27 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager27>().StartDialogue(dialogue);
	}
}
