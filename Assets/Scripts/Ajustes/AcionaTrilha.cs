using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcionaTrilha : MonoBehaviour
{
    private AudioSource trilha;

    private void Start()
    {
        trilha = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trilha.Play();
        }
    }
}
