using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Movimenta��o do Inimigo")]
    private Rigidbody2D rb;
    private bool inverter;
    public float velocidade;

    //Configura��es para inverter
    public Transform pontoA;
    public Transform pontoB;
    public LayerMask layer;

    [Header("Inimigo Levando Dano")]
    private SpriteRenderer sp;
    public Color corOriginal;
    public Color corDeDano;
    public float forcaDoArremeso;

    [Header("Efeito sonoro do impacto com o jogador")]
    public AudioSource somPulo;

    //Refer�ncia
    private Controller jogador;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        jogador = FindObjectOfType<Controller>();
    }

    private void FixedUpdate()
    {
        Movimento();
    }

    void Movimento()
    {
        rb.velocity = new Vector2(velocidade, rb.velocity.y);
        //inverter = Physics2D.Linecast(pontoA.position, pontoB.position, layer);
        inverter = Physics2D.Linecast(pontoA.position, pontoB.position, layer);
        if (inverter)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocidade *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            jogador.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoArremeso, ForceMode2D.Impulse);
            somPulo.Play();
            StartCoroutine(Piscar());
        }
    }
    IEnumerator Piscar()
    {
        sp.color = corDeDano;
        yield return new WaitForSeconds(0.2f);
        sp.color = corOriginal;
        yield return new WaitForSeconds(0.2f);
        sp.color = corDeDano;
        yield return new WaitForSeconds(0.2f);
        sp.color = corOriginal;
        yield return new WaitForSeconds(0.2f);
        sp.color = corDeDano;
        yield return new WaitForSeconds(0.2f);
        sp.color = corOriginal;
    }
}
