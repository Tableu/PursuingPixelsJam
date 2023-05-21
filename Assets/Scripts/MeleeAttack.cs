using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private WeaponStats stats;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health health = other.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(stats.damage);
            }
        }
    }
}
