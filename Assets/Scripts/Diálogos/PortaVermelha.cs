using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaVermelha : MonoBehaviour
{
    [Header("Diálogo do Personagem")]
    public Sprite imagemDePerfil;
    public string nomeDoPersonagem;
    public string dialogoDoPersonagem;

    [Header("Configurações")]
    //Sprite falando
    private SpriteRenderer atual;
    public Sprite parado;
    public Sprite falando;

    //Configurações para abrir o diálogo
    private bool abrirDialogo;
    public float radius;
    public LayerMask layer;
    public static Dialogo dialogo;

    [Header("Chave")]
    public GameObject espacoDaChave;
    private ChaveVermelha chaveSeguindo;
    private Controller jogador;

    [Header("Abrir a Porta")]
    public Color cor;

    private AudioSource audioDestrancando;
    //public BoxCollider2D bc;

    
    //!!!!  <----------
    // MUDEI A REFERÊNCIA DO DIALOGO, POIS ESTAVA CONFLITANDO COM O ARRAY
    // SÓ MUDAR DEPOIS
    //!!!!  <----------
    
    void Start()
    {
        //dialogo = FindObjectOfType<Dialogo>();
        chaveSeguindo = FindObjectOfType<ChaveVermelha>();
        jogador = FindObjectOfType<Controller>();
        atual = GetComponent<SpriteRenderer>();
        audioDestrancando = GetComponent<AudioSource>();
    }

    void Update()
    {
        Dialogo();
    }

    void Dialogo()
    {
        abrirDialogo = Physics2D.OverlapCircle(transform.position, radius, layer);
        if (abrirDialogo)
        {
            if (gameObject != null)
            {
                //dialogo.ChamarDialogo(imagemDePerfil, nomeDoPersonagem, dialogoDoPersonagem);
                atual.sprite = falando;
                Debug.Log("Abrir Dialogo");
            }
        }
        else
        {
            //dialogo.painelDeDialogo.SetActive(false);
            atual.sprite = parado;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (chaveSeguindo.alvo != null)
            {
                //dialogo.painelDeDialogo.SetActive(false);
                jogador.chaveVermelha.alvo = espacoDaChave.transform;
                audioDestrancando.Play();
                Destroy(jogador.chaveVermelha.gameObject, 1.7f);
                abrirDialogo = false;
                Destroy(gameObject, 1.7f);
            }
        }
    }
}
