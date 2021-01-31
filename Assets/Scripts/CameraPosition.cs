using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
	public enum Location
	{
		AtFan,
		AcrossRoom,
		WhiskyDrawer,
		BehindDesk,
		StationaryDrawer,
		AtDoor
	}

	private Dictionary<Location, (Vector3 position, Vector3 rotation)> _locations = new Dictionary<Location, (Vector3 position, Vector3 rotation)>()
	{
		{ Location.AtFan, (new Vector3(-1.2f, 1.0f, -1.447f), new Vector3(-20.0f, 30.0f, 0.0f)) },
		{ Location.AcrossRoom, (new Vector3(1.1f, 1.5f, 2.4f), new Vector3(5.0f, -150.0f, 0.0f)) },
		{ Location.WhiskyDrawer, (new Vector3(0.747f, 1.211f, -1.447f), new Vector3(60.0f, 0.0f, 0.0f)) },
		{ Location.BehindDesk, (new Vector3(0.2f, 1.4f, -1.447f), new Vector3(10.0f, -10.0f, 0.0f)) },
		{ Location.StationaryDrawer, (new Vector3(-0.747f, 1.711f, -1.447f), new Vector3(60.0f, 0.0f, 0.0f)) },
		{ Location.AtDoor, (new Vector3(0.4f, 1.4f, 0.8f), new Vector3(6.0f, 25.0f, 0.0f)) }
	};

	public void SetLocation(Location location)
	{
		gameObject.GetComponent<Camera>().transform.position = _locations[location].position;
		gameObject.GetComponent<Camera>().transform.rotation = Quaternion.Euler(_locations[location].rotation);
	}

    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
