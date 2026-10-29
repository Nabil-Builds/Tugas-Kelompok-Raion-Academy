using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Nyawa")]
    public int maxHealth = 5;
    public float damageCooldown = 1f;   // jeda antar kena damage (detik)
    private int currentHealth;
    private float nextDamageTime = 0f;

    [Header("UI")]
    public Text healthText;

    [Header("Scene")]
    public string gameOverSceneName = "GameOver";

    private bool isDead = false;

    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        if (Time.time < nextDamageTime) return;   // masih cooldown, abaikan

        nextDamageTime = Time.time + damageCooldown;

        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Nyawa: " + currentHealth;
    }

    void Die()
    {
        isDead = true;
        GameOverData.lastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(gameOverSceneName);
    }
}