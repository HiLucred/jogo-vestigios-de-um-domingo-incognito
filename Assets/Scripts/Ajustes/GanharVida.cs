using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GanharVida : MonoBehaviour
{
    [Header("Ganhar Vida")]
    public int vida;
    private SpriteRenderer sp;
    public ParticleSystem particulaDeVida;
    
    //Som recuperação de vida
    public GameObject somRecuperaVida;

    [Header("Mostrar Botão R")]
    private bool detectou;
    public float raio;
    public LayerMask layer;
    public GameObject botaoR;
    private Controller jogador;

    private void Start()
    {
        jogador = FindObjectOfType<Controller>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    { 
        detectou = Physics2D.OverlapCircle(transform.position, raio, layer);
        if (detectou)
        {
            botaoR.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                jogador.GetComponent<Vida>().Saude(-vida);
                jogador.GetComponent<Vida>().somDano.Pause();
                Instantiate(somRecuperaVida, transform.position, quaternion.identity);
                jogador.GetComponent<Vida>().percaDeVida.Pause();
                particulaDeVida.Play();
                StartCoroutine(JogadorPiscando());
                Destroy(gameObject, 0.3f);
            }
        }
        else
        {
            botaoR.SetActive(false);
        }
    }

    IEnumerator JogadorPiscando()
    {
        sp.color = new Color(131f, 255f, 0f, 255f);
        yield return new WaitForSeconds(0.2f);
        sp.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.2f);
        sp.color = new Color(131f, 255f, 0f, 255f);
        yield return new WaitForSeconds(0.2f);
        sp.color = new Color(1f, 1f, 1f, 1f);
    }
}