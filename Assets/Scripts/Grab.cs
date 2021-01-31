using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grab : MonoBehaviour
{
	public Camera _camera;

	private Grabbable _grabbed;

	private Droppable _droppable;

	private PhysicMaterial _oldMaterial;

	private RigidbodyConstraints _oldConstraints;

	private float _oldAngularDrag;

	private Vector3 _startPosition;

	private Vector3 _offset;

	private DropSite _dropSite;

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

			if (Physics.Raycast(ray, out hit, Single.MaxValue, ~LayerMask.GetMask("MouseColliders")) && hit.rigidbody != null)
			{
				_grabbed = hit.transform.GetComponent<Grabbable>();

				if (_grabbed != null)
				{
					_startPosition = hit.point;

					_offset = hit.transform.position - hit.point;

					_oldConstraints = _grabbed.Rigidbody.constraints;
					_grabbed.Rigidbody.constraints &= RigidbodyConstraints.FreezeRotation;
					_oldAngularDrag = _grabbed.Rigidbody.angularDrag;
					_grabbed.Rigidbody.angularDrag = 10.0f;
					_oldMaterial = _grabbed.Collider.material;
					_grabbed.Collider.material = _grabbed.WhenGrabbed;

					_droppable = _grabbed.GetComponent<Droppable>();
				}
			}
		}
		else if (_grabbed != null)
		{
			if (Input.GetMouseButtonUp(0))
			{
				if (_dropSite != null && _dropSite.PrefabTrigger != null)
				{
					_dropSite.gameObject.SetActive(false);

					var newObject = Instantiate(_dropSite.PrefabTrigger);
					newObject.transform.parent = transform;
				}

				_grabbed.Rigidbody.constraints = _oldConstraints;
				_grabbed.Rigidbody.angularDrag = _oldAngularDrag;
				_grabbed.Collider.material = _oldMaterial;
				_oldMaterial = null;
				_grabbed = null;
				_droppable = null;
				_dropSite = null;
			}
		}
	}

	void FixedUpdate()
	{
		if (_grabbed != null)
		{
			var mousePosition = Input.mousePosition;

			if (_droppable != null)
			{
				var eventData = new PointerEventData(EventSystem.current);
				eventData.position = mousePosition;

				var results = new List<RaycastResult>();
				EventSystem.current.RaycastAll(eventData, results);

				var dropSiteCandidate = results.Select(result => result.gameObject.GetComponent<DropSite>()).FirstOrDefault(o => o != null);

				if (dropSiteCandidate != null && dropSiteCandidate.ExpectedObjectName == _droppable.Name)
					_dropSite = dropSiteCandidate;
				else
					_dropSite = null;
			}
			else 
				_dropSite = null;

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

					_grabbed.Rigidbody.AddForce(deltaVelocity * Time.deltaTime * 40.0f * _grabbed.Rigidbody.mass, ForceMode.Impulse);
				}
			}
		}
	}
}
