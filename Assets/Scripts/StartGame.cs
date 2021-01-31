using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
	public CameraPosition _cameraPosition;

	public GameObject _startPrefab;

    // Start is called before the first frame update
    void Start()
    {
		_cameraPosition.SetLocation(CameraPosition.Location.AcrossRoom);
		var prefab = Instantiate(_startPrefab);
		prefab.transform.parent = transform.parent;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
