using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	public DialogueWindow Dialogue;

	private string[] _testDialogue;

	// Start is called before the first frame update
	void Start()
	{
		_testDialogue = new string[]
		{
			"It was a long month. A very long month. The Edwards dame nearly got me shot by her husband’s bodyguards yesterday. Never got paid for that one.",
			"I took a job investigating the sewage plant, don’t know what I was thinking there. At least the pay was solid.",
			"I got hired to tail some gangster’s girl, making sure she ain’t cheatin’. She was, he didn’t take the news well. Also didn’t get paid for that.",
			"Unfortunately that’s all I’ve gotten all month, and one paying job don’t pay the bills.",
			"I may not know much, but I knew I needed a strong drink after all of that….."
		};
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			Dialogue.Show(_testDialogue);
		}
		else if (Input.GetKeyUp(KeyCode.Return))
		{
			Dialogue.Close();
		}
	}
}
