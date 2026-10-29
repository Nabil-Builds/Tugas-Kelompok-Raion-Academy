using Unity.VisualScripting;
using UnityEngine;

public class GranadeDamage : MonoBehaviour
{
    [SerializeField] int damage = 10;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

    }
}
