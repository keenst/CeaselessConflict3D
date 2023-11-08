using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector2 _moveInput;
    private float _turnInput;

    private const int WalkSpeed = 100;
    private const int TurnSpeed = 10;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnTurn(InputAction.CallbackContext context)
    {
        _turnInput = context.ReadValue<float>();
    }

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        HandleMovement();
        HandleTurning();
    }

    private void HandleMovement()
    {
        Transform transform1 = transform;
        Vector3 moveDirection = transform1.forward * _moveInput.y + transform1.right * _moveInput.x;
        _rigidbody.velocity = moveDirection * (Time.fixedDeltaTime * WalkSpeed);
    }

    private void HandleTurning()
    {
        transform.localRotation *= Quaternion.Euler(0, 10 * _turnInput * Time.fixedDeltaTime * TurnSpeed, 0);
    }
}
