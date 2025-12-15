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
    SpriteRenderer spriteRenderer;
    Vector2 moveDirection;

    public float speed;

    public WeaponData equippedWeapon;
    private float lastAttackTime;
    Transform attackPoint;

    void Awake()
    {
        attackPoint = transform;
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
        if (Time.time > lastAttackTime)
        {
            attackAction.performed += context => {Attack();};
            lastAttackTime = Time.time;
        }
        
        moveDirection = moveAction.ReadValue<Vector2>();
        body.linearVelocity = speed * Time.deltaTime * moveDirection;

        if (moveDirection.x > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDirection.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Attack()
    {
        print("Attack");

        GameObject attackObject = Instantiate(
            equippedWeapon.prefab, 
            attackPoint.position + new Vector3(spriteRenderer.flipX ? -0.3f : 0.3f, 0.2f, 0f), 
            attackPoint.rotation);
        
        WeaponAction action = attackObject.GetComponent<WeaponAction>();
        
        action.Initialize(equippedWeapon.baseDamage);
    }
}
