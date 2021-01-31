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
			{
				gameObject.GetComponent<CanvasRenderer>().SetAlpha(0);

				_objectToDisableOnComplete.SetActive(false);

				CameraPosition.SetLocation(CameraLocationOnComplete);

				DialogueOnComplete.TriggerAnimation(() => _complete = true);
			}

			return true;
		}

		return false;
	}

    // Update is called once per frame
    void Update()
    {
		if (_complete)
		{
			_complete = false;

			_objectToEnableAfterDialogue?.SetActive(true);
			_uiToEnableAfterDialogue?.SetActive(true);
			CameraPosition.SetLocation(CameraLocationAfterDialogue);
		}
    }
}
