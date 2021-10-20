using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaAmarela : MonoBehaviour
{
    [Header("Di�logo do Personagem")]
    public Sprite imagemDePerfil;
    public string nomeDoPersonagem;
    //public string dialogoDoPersonagem[];

    [Header("Configura��es")]
    //Sprite falando
    private SpriteRenderer atual;
    public Sprite parado;
    public Sprite falando;

    //Configura��es para abrir o di�logo
    private bool abrirDialogo;
    public float radius;
    public LayerMask layer;
    //public static Dialogo dialogo;

    [Header("Chave")]
    public GameObject espacoDaChave;
    private ChaveSeguindo chaveSeguindo;
    private Controller jogador;

    [Header("Abrir a Porta")]
    public Color cor;
    //public BoxCollider2D bc;
    
    //!!!!  <----------
    // MUDEI A REFER�NCIA DO DIALOGO, POIS ESTAVA CONFLITANDO COM O ARRAY
    // S� MUDAR DEPOIS
    //!!!!  <----------
    
    void Start()
    {
        
        //dialogo = FindObjectOfType<Dialogo>();
        chaveSeguindo = FindObjectOfType<ChaveSeguindo>();
        jogador = FindObjectOfType<Controller>();
        atual = GetComponent<SpriteRenderer>();
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
            if(gameObject != null)
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
                jogador.chaveSeguindo.alvo = espacoDaChave.transform;
                Destroy(jogador.chaveSeguindo.gameObject, 1.7f);
                abrirDialogo = false;
                Destroy(gameObject,1.7f);
            }
        }
    }

}