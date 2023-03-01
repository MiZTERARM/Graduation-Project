using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger21 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager21>().StartDialogue(dialogue);
	}

}
