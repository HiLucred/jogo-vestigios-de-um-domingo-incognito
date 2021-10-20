using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirando : MonoBehaviour
{
    [Header("Posição e Instância da Bala")]
    public GameObject balaPrefab;
    public Transform disparoPosition;
    public Transform areaDeGatilho;
    public Vector2 tamanhoDoGatilho;
    public float velocidade;
    public LayerMask layer;

    void Start()
    {
        
    }

    void Update()
    {
        Atirar();
    }

    void Atirar()
    {
        bool atirar = Physics2D.OverlapBox(areaDeGatilho.position, tamanhoDoGatilho, 0.0f, layer);
        if (atirar)
        {
            GameObject bala = Instantiate(balaPrefab, disparoPosition.position, disparoPosition.rotation);
            bala.GetComponent<Rigidbody2D>().AddForce(disparoPosition.forward * velocidade, ForceMode2D.Impulse);
            Destroy(bala, 2f);
        }
    }
}
