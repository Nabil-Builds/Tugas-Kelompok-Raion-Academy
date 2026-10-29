
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    [SerializeField] GameObject coin;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(gameObject.name + " HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (CompareTag("Enemy"))
        {
            LevelManager.instance.AddKill();
            GameObject dropCoin = Instantiate(coin, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
