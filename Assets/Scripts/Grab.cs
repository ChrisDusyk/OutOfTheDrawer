using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
	public Camera _camera;

	private Grabbable _grabbed;

	private PhysicMaterial _oldMaterial;

	private RigidbodyConstraints _oldConstraints;

	private Vector3 _startPosition;

	private Vector3 _offset;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, Single.MaxValue, LayerMask.GetMask("GrabbableObjects")) && hit.rigidbody != null)
			{
				_grabbed = hit.transform.GetComponent<Grabbable>();

				_startPosition = hit.point;

				_offset = hit.transform.position - hit.point;

				_oldConstraints = _grabbed.Rigidbody.constraints;
				_grabbed.Rigidbody.constraints &= RigidbodyConstraints.FreezeRotation;
				_oldMaterial = _grabbed.Collider.material;
				_grabbed.Collider.material = _grabbed.WhenGrabbed;
			}
		}
		else if (_grabbed != null)
		{
			if (Input.GetMouseButtonUp(0))
			{
				_grabbed.Rigidbody.constraints = _oldConstraints;
				_grabbed.Collider.material = _oldMaterial;
				_oldMaterial = null;
				_grabbed = null;
			}
		}
	}

	void FixedUpdate()
	{
		if (_grabbed != null)
		{
			var mousePosition = Input.mousePosition;
			var mouseRay = _camera.ScreenPointToRay(mousePosition);

			if (new Plane(Vector3.up, _startPosition).Raycast(mouseRay, out var distance))
			{
				RaycastHit hit;
				Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

				Vector3 targetPosition;
				if (_grabbed.RespectMouseColliders && Physics.Raycast(ray, out hit, Single.MaxValue, LayerMask.GetMask("MouseColliders")) && hit.distance < distance)
					targetPosition = hit.point + _offset;
				else
					targetPosition = mouseRay.GetPoint(distance) + _offset;

				if (_grabbed.Rigidbody.isKinematic)
					_grabbed.Rigidbody.MovePosition(targetPosition);
				else
				{
					var delta = targetPosition - _grabbed.transform.position;

					var targetVelocity = delta * 20.0f;

					var deltaVelocity = targetVelocity - _grabbed.Rigidbody.velocity;

					_grabbed.Rigidbody.AddForce(deltaVelocity * Time.deltaTime * 20.0f * _grabbed.Rigidbody.mass, ForceMode.Impulse);
				}
			}
		}
	}
}
