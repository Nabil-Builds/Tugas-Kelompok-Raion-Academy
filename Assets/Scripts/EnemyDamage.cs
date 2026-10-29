using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Hit(collision);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Hit(collision);
    }

    void Hit(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        if (player != null) player.TakeDamage(damage);
    }
}