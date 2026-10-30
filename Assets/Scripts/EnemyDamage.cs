using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        Hit(other);
    }

    void Hit(Collider2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null) player.TakeDamage(damage);
    }
}