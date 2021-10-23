using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    #region Variáveis
    
    [Header("Movimento")]
    public float velocidade;

    [Header("Pulo")]
    public float forcaDoPulo;
    private bool noChao;
    private bool puloDuplo;

    [Header("Checagem do Chão")]
    public Transform A;
    public Transform B;
    public LayerMask layer;

    [Header("Física")]
    private Rigidbody2D rb;

    [Header("Habilitar Movimentos Básicos")]
    public bool podePular;
    public bool podePularDuplo;
    public bool podeMover;

    [Header("Espaços para objetos")]
    public Transform chave;
    public ChaveSeguindo chaveSeguindo;
    public ChaveVermelha chaveVermelha;

    [Header("Partículas, Animações e Sons")] 
    //Particulas
    public ParticleSystem petalas;

    private Animator animacao;
    //Audio do pulo
    public AudioSource somPulo;
    

    #endregion
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        chaveSeguindo = FindObjectOfType<ChaveSeguindo>();
        chaveVermelha = FindObjectOfType<ChaveVermelha>();
        animacao = GetComponent<Animator>();
    }

    void Update() {
        if (!podePular)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,0),ForceMode2D.Impulse);
            return;
        }
        Pulo();
    }

    private void FixedUpdate()
    {
        if (!podeMover)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,GetComponent<Rigidbody2D> ().velocity.y);
            return;
        }
        Movimento();
    }

    void Movimento()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidade * Time.fixedDeltaTime , rb.velocity.y);
            animacao.SetBool("podeCorrer", true);
            ParticulaPetala();
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidade * Time.fixedDeltaTime, rb.velocity.y);
            animacao.SetBool("podeCorrer", true);
            ParticulaPetala();
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            animacao.SetBool("podeCorrer", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void Pulo()
    {
        noChao = Physics2D.Linecast(A.position, B.position, layer);
        if (Input.GetButtonDown("Jump"))
        {
            if (noChao && podePular)
            {
                rb.AddForce(Vector2.up * forcaDoPulo, ForceMode2D.Impulse);
                animacao.SetBool("podePular", true);
                puloDuplo = true;
                somPulo.Play();
            }
            else if (puloDuplo && podePularDuplo)
            {
                rb.AddForce(Vector2.up * forcaDoPulo, ForceMode2D.Impulse);
                puloDuplo = false;
                somPulo.Play();
            }
        }
    }

    #region particulas e animacoes

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cenario"))
        {
            animacao.SetBool("podeCorrer", false);
            animacao.SetBool("podePular", false);
        }
    }

    void ParticulaPetala()
    {
        petalas.Play();
    }


    #endregion
  
}