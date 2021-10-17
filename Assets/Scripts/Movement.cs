using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float MovementSpeed = 1;

    private Vector3 _horizontalMovement;
    private Vector3 _direction;
    private Rigidbody _rigidBody;

    public void Move(InputAction.CallbackContext actionContext)
    {
        var input = actionContext.ReadValue<Vector2>();
        var reorientedInput = new Vector3(input.x, 0, input.y);
        _horizontalMovement = reorientedInput * MovementSpeed;
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _direction = _horizontalMovement;
        _rigidBody.velocity = _direction;
    }
}
