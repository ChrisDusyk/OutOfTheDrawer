using UnityEngine;
using UnityEditor;
using System.Collections;

public class ColliderToFit : MonoBehaviour
{

	[MenuItem("Collider/Fit to Children")]
	static void FitToChildren()
	{
		foreach (GameObject rootGameObject in Selection.gameObjects)
		{
			foreach (var collider in rootGameObject.GetComponents<Collider>())
			{
				bool hasBounds = false;
				Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

				for (int i = 0; i < rootGameObject.transform.childCount; ++i)
				{
					Renderer childRenderer = rootGameObject.transform.GetChild(i).GetComponent<Renderer>();
					if (childRenderer != null)
					{
						if (hasBounds)
						{
							bounds.Encapsulate(childRenderer.bounds);
						}
						else
						{
							bounds = childRenderer.bounds;
							hasBounds = true;
						}
					}
				}

				if (collider is BoxCollider boxCollider)
				{
					boxCollider.center = bounds.center - rootGameObject.transform.position;
					boxCollider.size = bounds.size;
				}
				else if (collider is SphereCollider sphereCollider)
				{
					sphereCollider.center = bounds.center - rootGameObject.transform.position;
					sphereCollider.radius = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
				}
				else if (collider is CapsuleCollider capsuleCollider)
				{
					capsuleCollider.center = bounds.center - rootGameObject.transform.position;
					capsuleCollider.height = bounds.extents.y * 2.0f;
					capsuleCollider.radius = Mathf.Max(bounds.extents.x, bounds.extents.z);
				}
			}
		}
	}

}