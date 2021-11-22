using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilitarSomLava : MonoBehaviour
{
    private AudioSource audioLava;

    private void Awake()
    {
        audioLava = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioLava.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioLava.Stop();
        }
    }
}
