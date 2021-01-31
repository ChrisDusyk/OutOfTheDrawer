using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	public CameraPosition _cameraPosition;

	public DialogueWindow _dialogue;

	public GameObject _objectToEnable;

	public GameObject _uiToEnable;

	public GameObject _splashScreen;

	private bool _running;
	private bool _complete;

	// Start is called before the first frame update
	void Start()
    {
		_cameraPosition.SetLocation(CameraPosition.Location.AtFan);
	}

    // Update is called once per frame
    void Update()
    {
		if (!_running && Input.GetKeyDown(KeyCode.Space))
		{
			_splashScreen.SetActive(false);

			_cameraPosition.SetLocation(CameraPosition.Location.AcrossRoom);

			_dialogue.TriggerAnimation(() => _complete = true);

			_running = true;
		}
		if (_complete)
		{
			_complete = false;

			_cameraPosition.SetLocation(CameraPosition.Location.WhiskyDrawer);

			_objectToEnable.SetActive(true);
			_uiToEnable.SetActive(true);
		}
	}
}
