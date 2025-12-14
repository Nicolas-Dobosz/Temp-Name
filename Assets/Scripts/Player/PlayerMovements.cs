using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;

    InputAction moveAction;
    InputAction attackAction;
    Rigidbody2D body;
    Vector2 moveDirection;

    public float speed;

    public WeaponData equippedWeapon;
    private float lastAttackTime;
    public Transform attackPoint;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
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
        attackAction.performed += context => {Attack();};
        lastAttackTime = Time.time;
        moveDirection = moveAction.ReadValue<Vector2>();
        body.linearVelocity = speed * Time.deltaTime * moveDirection;
    }

    void Attack()
    {
        print("Attack");
    }
}
