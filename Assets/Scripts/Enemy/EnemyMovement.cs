using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	private enum State
	{
		Patrol,
		Chase
	}

	public GameObject player;
	public int walkSpeed;

	private Rigidbody _rigidbody;
	private State _state = State.Patrol;

	public void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	public void Update()
	{
		LookForPlayer();
		
		switch (_state)
		{
			case State.Patrol:
				{
					Patrol();
				} break;

			case State.Chase:
				{
					Chase();
				} break;
		}
	}

	private void LookForPlayer()
	{
		Vector3 playerPos = player.transform.position;
		Vector3 pos = transform.position;

		RaycastHit hit;
		Physics.Raycast(pos, playerPos - pos, maxDistance: 10, hitInfo: out hit);

		if (hit.collider.gameObject != player)
		{
			_state = State.Patrol;
			return;
		}

		_state = State.Patrol;
	}

	private void Patrol()
	{
		float sign = 0;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward, maxDistance: 0.5F, hitInfo: out hit))
		{
			Vector3 wallPos = hit.collider.transform.position;
			float angle = Vector3.Angle(transform.position, wallPos);
			sign = Mathf.Sign(angle);
		}
		else if (Physics.Raycast(transform.position, transform.right, maxDistance: 0.2F, hitInfo: out hit))
		{
			sign = -1;
		}
		else if (Physics.Raycast(transform.position, -transform.right, maxDistance: 0.2F, hitInfo: out hit))
		{
			sign = 1;
		}

		transform.Rotate(new Vector3(0, 1, 0), 0.5F * sign); 
		_rigidbody.velocity = transform.forward * walkSpeed * Time.fixedDeltaTime;
	}

	private void Chase()
	{
	}
}
