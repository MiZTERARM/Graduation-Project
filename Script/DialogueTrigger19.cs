using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger19 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager19>().StartDialogue(dialogue);
	}
}
