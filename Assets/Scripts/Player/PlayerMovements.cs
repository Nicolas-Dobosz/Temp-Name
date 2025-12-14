using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;

    InputAction moveAction;
    Vector2 moveDirection;

    Rigidbody2D body;

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

    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        body.linearVelocity = speed * Time.deltaTime * moveDirection;
    }
}
