using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class IAOlhoAtirador : MonoBehaviour
{
    [Header("Movimentação do Inimigo")]
    private Rigidbody2D rb;
    private bool inverter;
    public float velocidade;

    //Configurações para inverter
    public Transform pontoA;
    public Transform pontoB;
    public LayerMask layer;

    [Header("Inimigo atira no jogador")] 
    public GameObject balaOlho;
    public Transform lugarDoOlho;

    [Header("Inimigo Levando Dano")]
    private SpriteRenderer sp;
    public Color corOriginal;
    public Color corDeDano;

    //Referência
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
        inverter = Physics2D.Linecast(pontoA.position, pontoB.position, layer);
        if (inverter)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocidade *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(balaOlho, lugarDoOlho.position, quaternion.identity);
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
        Destroy(gameObject);
    }
}
