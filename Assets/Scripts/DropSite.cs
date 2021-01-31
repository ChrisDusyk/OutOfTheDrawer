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

	public GameObject PrefabTrigger;

	public TMP_Text Text;

    // Start is called before the first frame update
    void Start()
    {
		_remainingNames = ExpectedObjectNames.Split(',').ToList();
		Text.text = String.Join("\r\n", _remainingNames);
	}

	public bool TryDrop(string name)
	{
		if (_remainingNames.Remove(name))
		{
			Text.text = String.Join("\r\n", _remainingNames);

			if (Completed)
			{
				gameObject.SetActive(false);

				var newObject = Instantiate(PrefabTrigger);
				newObject.transform.parent = transform;
			}

			return true;
		}

		return false;
	}

    // Update is called once per frame
    void Update()
    {
    }
}
