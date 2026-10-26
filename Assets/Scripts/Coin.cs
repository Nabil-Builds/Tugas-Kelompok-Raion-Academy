
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip sound;
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (LevelManager.instance != null)
            {
                playSound();
                LevelManager.instance.AddCoin(coinValue);
                
                Destroy(gameObject);
            }
        }
    }

    void playSound()
    {
        source.PlayOneShot(sound);
        print("SOUND PLAYED");
    }
}
