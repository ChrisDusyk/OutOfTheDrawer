using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	public DialogueWindow WhiskyDialogue;
	public DialogueWindow StationaryDialogue;
	public DialogueWindow EpilogueDialogue;

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			WhiskyDialogue.TriggerAnimation(WhiskyEnded);
		else if (Input.GetKeyDown(KeyCode.Alpha2))
			StationaryDialogue.TriggerAnimation(StationaryEnded);
		else if (Input.GetKeyDown(KeyCode.Alpha3))
			EpilogueDialogue.TriggerAnimation(() => Debug.Log("Epilogue Animation ended"));
	}

	private void StationaryEnded()
	{
		Debug.Log("Stationary Antimation ended");
	}

	private void WhiskyEnded()
	{
		Debug.Log("Animation ended");
	}
}
