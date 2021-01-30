using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
	public Rigidbody Rigidbody { get; private set; }

	public Collider Collider { get; private set; }

	public Vector3 StartPosition { get; private set; }

	public Vector3 MinimumOffset = new Vector3(-1000000, -1000000, -1000000);
	public Vector3 MaximumOffset = new Vector3(1000000, 1000000, 1000000);

	public bool RespectMouseColliders = true;

	public PhysicMaterial WhenGrabbed;

    // Start is called before the first frame update
    void Start()
    {
		Rigidbody = GetComponent<Rigidbody>();
		Collider = GetComponent<Collider>();
		StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
