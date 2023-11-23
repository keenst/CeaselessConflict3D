using UnityEngine;

public class LightController : MonoBehaviour
{
	public LightEntity[] entities;

	private Vector3[] _lights;

	public void Update()
	{
		foreach (Vector3 light in _lights)
		{
			foreach (LightEntity entity in entities)
			{
				Vector3 entityPos = entity.transform.position;

				if (Vector3.Magnitude(light - entityPos) > 5)
				{
					entity.isLit = false;
					continue;
				}

				RaycastHit hit;
				Physics.Raycast(light, entityPos - light, maxDistance: 5, hitInfo: out hit);

				if (hit.collider.gameObject != entity.gameObject)
				{
					entity.isLit = false;
					continue;
				}

				entity.isLit = true;
			}
		}
	}

	public void SetLights(Vector3[] lights)
	{
		_lights = lights;
	}
}
