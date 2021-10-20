using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Laser Aparecer e Desaparece")]
    private SpriteRenderer sp;
    private BoxCollider2D bc;
    private float timer;
    private bool acctive;
    
    [Header("Parametros da Força do Dano")]
    public float forcaDoPulo;
    public int dano;
    
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            acctive = !acctive;
            timer = 0;
        }
        if (acctive)
        {
            sp.enabled = true;
            bc.enabled = true;
        }
        else
        {
            sp.enabled = false;
            bc.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Vida>().Saude(dano);
            collision.gameObject.GetComponent<Vida>().PiscarJogador();
        }
    }

}
