
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] AudioClip sound;
    public int coinValue = 1;
    [SerializeField] float lifeTime = 10;

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

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void playSound()
    {
        Vector3 soundPos = transform.position;
        soundPos.z = Camera.main.transform.position.z;
        AudioSource.PlayClipAtPoint(sound, transform.position, 1);
        print("SOUND PLAYED");
    }
}
