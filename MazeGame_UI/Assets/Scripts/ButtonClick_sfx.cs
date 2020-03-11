using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonClick_sfx : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playsfx()
    {
        audioSource.Play();
    }
}
