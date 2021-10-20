using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoLava : MonoBehaviour
{
    [Header("Parametros da Força do Dano")]
    public float forcaDoPulo;
    public int dano;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Vida>().Saude(dano);
            collision.gameObject.GetComponent<Vida>().PiscarJogador();
        }
    }
    
}
