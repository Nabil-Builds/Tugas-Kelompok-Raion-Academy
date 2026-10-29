using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Mine Day 2");
    }
}
