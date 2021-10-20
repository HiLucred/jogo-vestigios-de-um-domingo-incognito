using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassarelaMovel : MonoBehaviour
{
    private Rigidbody2D rb;
    private float tempo;
    public float velocidadeDaPassarela;
    public int tempoMaximo;
    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        tempo += Time.deltaTime;
        if(tempo >= tempoMaximo)
        {
            velocidadeDaPassarela *= -1;
            sr.flipX = !sr.flipX;
            tempo = 0;
        }
        rb.velocity = new Vector2(velocidadeDaPassarela, rb.velocity.y);
        
    }
}
