using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulso2 : MonoBehaviour
{
    public Transform checagemDePulo;
    public Vector2 tamanhoDaChecagem;
    public LayerMask layer;
    public float forcaDoPulo;
    private Controller jogador;
    private bool colidiu;

    void Start()
    {
        jogador = FindObjectOfType<Controller>();
    }

    void FixedUpdate()
    {
        colidiu = Physics2D.OverlapBox(checagemDePulo.position, tamanhoDaChecagem, 0, layer);
        if (colidiu)
        {
            jogador.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo * Time.fixedDeltaTime
                , ForceMode2D.Impulse);
        }
    }
}
