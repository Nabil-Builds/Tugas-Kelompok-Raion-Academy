using System;
using UnityEngine;

public class GunNoise : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundSource.PlayOneShot(sound);
    }

   
}
