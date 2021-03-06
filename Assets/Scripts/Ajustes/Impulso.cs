using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulso : MonoBehaviour
{
    [Header("For?a Do Pulo")]
    public float forcaDoPulo;

    private AudioSource audioPulo;

    private void Awake()
    {
        audioPulo = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo);
            audioPulo.Play();
        }
    }
}