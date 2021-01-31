using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
	private const string ALPHA_CODE = "<color=#00000000>";

	public TMP_Text Text;
	private string[] _allDialogue;

	CanvasGroup Group;

	void Start()
	{
		Group = GetComponent<CanvasGroup>();
		Group.alpha = 0;
	}

	public void Show(string[] text)
	{
		Group.alpha = 1;
		_allDialogue = text;
		StartCoroutine(DisplayText());
	}

	public void Close()
	{
		StopAllCoroutines();
		Group.alpha = 0;
	}

	private IEnumerator DisplayText()
	{
		foreach (var dialogue in _allDialogue)
		{
			Text.text = "";

			var originalText = dialogue;
			var displayedText = string.Empty;
			var alphaIndex = 0;

			foreach (var c in originalText.ToCharArray())
			{
				++alphaIndex;
				Text.text = originalText;
				displayedText = Text.text.Insert(alphaIndex, ALPHA_CODE);
				Text.text = displayedText;

				yield return new WaitForSecondsRealtime(0.03f);
			}

			yield return new WaitForSecondsRealtime(0.25f);
		}

		Group.alpha = 0;

		yield return null;
	}
}
