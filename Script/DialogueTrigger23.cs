using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger23 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager23>().StartDialogue(dialogue);
	}
}
