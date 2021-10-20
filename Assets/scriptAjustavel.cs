using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAjustavel : MonoBehaviour
{
    public GameObject arma;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            arma.SetActive(false);    
        }
    }
}
