using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource src;
    public int AudioQueue;

    private void Start()
    {
        src.volume = 100;
        src.clip = clips[AudioQueue];
        src.Play();
    }
}
