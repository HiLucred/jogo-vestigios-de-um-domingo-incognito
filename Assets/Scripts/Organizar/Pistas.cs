using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistas : MonoBehaviour
{
    [Header("Pistas Novas")]
    public Sprite imagemDescoberta;
    public string descoberta;
    public Transform portaAmarela;

    public LayerMask layer;

    [Header("Pistas Nova 2")]
    public Sprite imagemDescoberta2;
    public string descoberta2;
    public Transform portaVermelha;

    //Referência
    private Descobrimento descobrimento;

    void Update()
    {
        descobrimento = FindObjectOfType<Descobrimento>();
        bool gatilho = Physics2D.OverlapBox(portaAmarela.transform.position, new Vector2(0.5f, 0.5f), 0, layer);
        if (gatilho)
        {
            descobrimento.Pistas(descoberta, imagemDescoberta);
        }

        bool gatilho2 = Physics2D.OverlapBox(portaVermelha.transform.position, new Vector2(0.5f, 0.5f), 0, layer);
        if (gatilho2)
        {
            descobrimento.PistasDois(descoberta2, imagemDescoberta2);
        }
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            descobrimento.Pistas(descoberta, imagemDescoberta);
        }
    }*/
}
