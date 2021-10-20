using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamico : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;
    private float tempo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        tempo += Time.fixedDeltaTime;
        if (tempo > 1.5f)
        {
            velocidade *= -1;
            tempo = 0;
        }

        rb.velocity = Vector2.up * velocidade * Time.fixedDeltaTime;
    }
}
