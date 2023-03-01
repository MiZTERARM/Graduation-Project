using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger25 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager25>().StartDialogue(dialogue);
	}
}
