using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acionarfim : MonoBehaviour
{
    public GameObject painelFim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            painelFim.SetActive(true);
        }
    }
}
