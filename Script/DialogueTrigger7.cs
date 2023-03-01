using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger7 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager7>().StartDialogue(dialogue);
	}
}
