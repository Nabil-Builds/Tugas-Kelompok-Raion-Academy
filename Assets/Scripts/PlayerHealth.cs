using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Nyawa")]
    public int maxHealth = 3;
    private int currentHealth;

    [Header("UI")]
    public Text healthText;          // opsional, buat nampilin nyawa
    public GameObject loseScreen;    // panel layar kalah
    public Button restartButton;     // tombol restart di panel

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

        if (loseScreen != null) loseScreen.SetActive(false);
        if (restartButton != null) restartButton.onClick.AddListener(RestartScene);

        Time.timeScale = 1f;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Lose();
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Nyawa: " + currentHealth;
    }

    void Lose()
    {
        isDead = true;
        if (loseScreen != null) loseScreen.SetActive(true);
        Time.timeScale = 0f; // pause game
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}