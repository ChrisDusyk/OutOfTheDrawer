using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
	public TMP_Text Text;

	public void DisplayDialogueText(string text)
	{
		Text.SetText(text);
	}
}
