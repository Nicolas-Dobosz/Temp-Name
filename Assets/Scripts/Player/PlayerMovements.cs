using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovements : MonoBehaviour
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
        inputActions.FindActionMap("Player").Enable();
    }

    void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }

    void FixedUpdate()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
        body.linearVelocity = speed * Time.deltaTime * moveDirection;
    }
}
