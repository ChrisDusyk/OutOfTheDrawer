using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
	public Camera _camera;

	private Grabbable _grabbed;

	private bool _previousMouseDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		var mouseDown = Input.GetMouseButtonDown(0);

		if (!_previousMouseDown && mouseDown)
		{
			RaycastHit hit;
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
				_grabbed = hit.transform.GetComponent<Grabbable>();
		}
		else if (mouseDown && _grabbed != null)
		{
			_grabbed.transform.position += new Vector3(0, 0.01f, 0);
		}	
		else if (_previousMouseDown && !mouseDown)
			_grabbed = null;

		_previousMouseDown = mouseDown;
	}
}
