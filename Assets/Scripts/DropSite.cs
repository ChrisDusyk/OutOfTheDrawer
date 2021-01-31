using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DropSite : MonoBehaviour
{
	public string ExpectedObjectNames;

	private List<string> _remainingNames;

	public bool Completed => _remainingNames.Count == 0;

	public CameraPosition CameraPosition;

	public DialogueWindow DialogueOnComplete;

	public CameraPosition.Location CameraLocationOnComplete;

	public GameObject _objectToDisableOnComplete;

	public GameObject _objectToEnableAfterDialogue;

	public GameObject _uiToEnableAfterDialogue;

	public CameraPosition.Location CameraLocationAfterDialogue;

	public TMP_Text Text;

	private bool _completed;

    // Start is called before the first frame update
    void Start()
    {
		_remainingNames = ExpectedObjectNames.Split(',').ToList();
		Text.text = String.Join("\r\n", _remainingNames);
	}

	private bool _complete;

	public bool TryDrop(string name)
	{
		if (_remainingNames.Remove(name))
		{
			Text.text = String.Join("\r\n", _remainingNames);

			if (Completed)
				Complete();

			return true;
		}

		return false;
	}

	private void Complete()
	{
		gameObject.GetComponent<CanvasRenderer>().SetAlpha(0);
		foreach (var canvas in gameObject.GetComponentsInChildren<CanvasRenderer>())
			canvas.SetAlpha(0);

		_objectToDisableOnComplete.SetActive(false);

		CameraPosition.SetLocation(CameraLocationOnComplete);

		DialogueOnComplete.TriggerAnimation(SetComplete);
	}

	private void SetComplete()
	{
		_complete = true;
	}

    // Update is called once per frame
    void Update()
    {
		if (!_completed && Input.GetKeyDown(KeyCode.Z))
			Complete();

		if (_complete)
		{
			_complete = false;
			_completed = true;

			if (_objectToEnableAfterDialogue != null)
				_objectToEnableAfterDialogue.SetActive(true);
			if (_uiToEnableAfterDialogue != null)
				_uiToEnableAfterDialogue.SetActive(true);

			CameraPosition.SetLocation(CameraLocationAfterDialogue);

			enabled = false;
		}
    }
}
