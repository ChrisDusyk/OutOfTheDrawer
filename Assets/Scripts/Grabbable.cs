using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
	public Rigidbody Rigidbody { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
		Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
