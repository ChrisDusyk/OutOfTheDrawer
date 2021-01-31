using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
	public TMP_Text Text;
	public AudioSource AudioSource;

	private Animator _animator;

	private System.Action _callbackAction;

	public void Start()
	{
		_animator = gameObject.GetComponent<Animator>();
	}

	public void DisplayDialogueText(string text)
	{
		Text.SetText(text.Replace("NEWLINE", System.Environment.NewLine));
	}

	public void TriggerAudioClip(AudioClip audio)
	{
		AudioSource.PlayOneShot(audio);
	}

	public void TriggerAnimation(System.Action callbackAction)
	{
		_callbackAction = callbackAction;
		_animator.SetTrigger("StartAnimation");
	}

	public void EndAnimation()
	{
		_callbackAction();
	}
}
