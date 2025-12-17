using Mono.Cecil;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;

    InputAction moveAction;
    Rigidbody2D body;
    Vector2 moveDirection;

    public float speed;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        body = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
    }

    void FixedUpdate()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
        body.linearVelocity = speed * Time.deltaTime * moveDirection;

        if (moveDirection.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (moveDirection.x < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
