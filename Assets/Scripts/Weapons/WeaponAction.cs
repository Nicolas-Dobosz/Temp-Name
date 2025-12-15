using UnityEngine;

public class WeaponAction : MonoBehaviour
{
    private float currentDamage;
    
    public void Initialize(float baseDmg)
    {
        currentDamage = baseDmg;
        Destroy(gameObject, 0.2f); 
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
    //         if (enemyHealth != null)
    //         {
    //             enemyHealth.TakeDamage(currentDamage);
    //         }
    //     }
    // }
}