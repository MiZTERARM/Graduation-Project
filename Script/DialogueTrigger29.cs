using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger29 : MonoBehaviour
{
	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager29>().StartDialogue(dialogue);
	}
}
