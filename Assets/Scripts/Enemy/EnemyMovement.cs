using UnityEngine;
using UnityEngine.AI;

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
	private NavMeshAgent _agent;
	private State _state = State.Patrol;

	public void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_agent = GetComponent<NavMeshAgent>();
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

		RaycastHit hitForward;

		bool blockedRight = Physics.Raycast(transform.position, transform.right, maxDistance: 2);
		bool blockedLeft = Physics.Raycast(transform.position, -transform.right, maxDistance: 2);
		bool blockedForward = Physics.Raycast(transform.position, transform.forward, maxDistance: 0.8F, hitInfo: out hitForward);

		if (blockedLeft && blockedRight && blockedForward)
		{
			Vector3 wallPos = hitForward.collider.transform.position;
			float angle = Vector3.Angle(transform.position, wallPos);
			sign = Mathf.Sign(angle);
		}
		else if (!blockedLeft && !blockedRight)
		{
			sign = Mathf.Sign(Random.Range(-1, 1));
		}
		else if (Random.Range(0, 1) > 0.5F & blockedForward)
		{
			if (blockedLeft)
			{
				sign = 1;
			}
			else if (blockedRight)
			{
				sign = -1;
			}
		}
		else
		{
			if (blockedRight)
			{
				sign = -1;
			}
			else if (blockedLeft)
			{
				sign = 1;
			}
		}

		transform.Rotate(new Vector3(0, 1, 0), 0.8F * sign);
		_agent.SetDestination(transform.position + transform.forward);
	}

	private void Chase()
	{
	}
}
