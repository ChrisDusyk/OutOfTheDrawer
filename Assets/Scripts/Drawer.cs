using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
	public float _travelDistance = 1.0f;

	public Vector3 _travelAxis = Vector3.forward;

    // Start is called before the first frame update
    void Start()
    {
		_travelAxis.Normalize();

		var sliderJoint = gameObject.AddComponent<ConfigurableJoint>();
		sliderJoint.autoConfigureConnectedAnchor = false;
		sliderJoint.anchor = _travelAxis * _travelDistance * 0.5f;
		sliderJoint.connectedAnchor = transform.position;
		sliderJoint.axis = _travelAxis;
		sliderJoint.xMotion = ConfigurableJointMotion.Limited;
		sliderJoint.yMotion = ConfigurableJointMotion.Locked;
		sliderJoint.zMotion = ConfigurableJointMotion.Locked;
		sliderJoint.linearLimit = new SoftJointLimit() { limit = _travelDistance * 0.5f };

		if (gameObject.GetComponent<Rigidbody>() is Rigidbody rigidbody)
			rigidbody.drag = 4.0f;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
