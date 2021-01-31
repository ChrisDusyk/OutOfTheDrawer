using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
	public TMP_Text Text;
	public AudioSource AudioSource;

	public void DisplayDialogueText(string text)
	{
		Text.SetText(text);
	}

	public void TriggerAudioClip(AudioClip audio)
	{
		AudioSource.PlayOneShot(audio);
	}
}
