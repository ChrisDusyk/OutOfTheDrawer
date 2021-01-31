using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	public CameraPosition _cameraPosition;

	public GameObject _objectToEnable;

	public GameObject _uiToEnable;

	// Start is called before the first frame update
	void Start()
    {
		_cameraPosition.SetLocation(CameraPosition.Location.AtFan);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_cameraPosition.SetLocation(CameraPosition.Location.WhiskyDrawer);
			_objectToEnable.SetActive(true);
			_uiToEnable.SetActive(true);

			enabled = false;
		}
	}
}
