using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiologueContackt : MonoBehaviour
{

	private void OnTriggerStay2D(Collider2D collision)
	{

		if (collision.CompareTag("NPC"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				DialogueTrigger tr = collision.transform.GetComponent<DialogueTrigger>();
				if (tr != null && tr.fileName != string.Empty)
				{
					DialogueManager.Internal.DialogueStart(tr.fileName);
				}
			}

			
		}

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("NPC") && collision.GetComponent<DialogueTrigger>() != null)
		{

			DialogueManager.Internal.CloseWindow();

		}
	}
}

