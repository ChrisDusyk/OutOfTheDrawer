using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
	public Rigidbody Rigidbody { get; private set; }

	public Collider Collider { get; private set; }

	public PhysicMaterial WhenGrabbed;

    // Start is called before the first frame update
    void Start()
    {
		Rigidbody = GetComponent<Rigidbody>();
		Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
