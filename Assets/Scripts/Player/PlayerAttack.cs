using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;

    InputAction attackAction;

    public WeaponData equippedWeapon;
    private float lastAttackTime;
    Transform attackPoint;

    void Awake()
    {
        attackPoint = transform;
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    void OnEnable()
    {
        attackAction.Enable();
    }

    void OnDisable()
    {
        attackAction.Disable();
    }

    void FixedUpdate()
    {
        if (Time.time > lastAttackTime)
        {
            attackAction.performed += context => {Attack();};
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        print("Attack");

        GameObject attackObject = Instantiate(
            equippedWeapon.prefab, 
            Vector3.zero,
            attackPoint.rotation);

        attackObject.transform.parent = transform;
        attackObject.transform.localPosition =  new Vector3(0.3f, 0.2f, 0f);
        
        WeaponAction action = attackObject.GetComponent<WeaponAction>();
        
        action.Initialize(equippedWeapon.baseDamage);
    }
}
