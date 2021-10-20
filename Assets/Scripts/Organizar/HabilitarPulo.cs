using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HabilitarPulo : MonoBehaviour
{

    [Header("Configurações Colisão")]
    public float radius;
    public LayerMask layer;

    [Header("Posição do Colldier")]
    public Transform pulo;
    public Transform puloDuplo;

    [Header("Configurações")]
    public Controller personagem;

    [Header("Aparecer na Tela")]
    public TextMeshProUGUI puloTxt;

    //Texto de pulo para ser mostrado
    public string textoDoPulo;
    public string textoDoPuloDuplo;
    public GameObject caixaDeDialogo;

    void Start()
    {
        personagem = FindObjectOfType<Controller>();
    }

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(pulo.position, radius, layer);
        if(caixaDeDialogo != null)
        {
            if (hit != null)
            {
                caixaDeDialogo.SetActive(true);
                puloTxt.text = textoDoPulo;
                StartCoroutine(DesaparecerTexto());
                personagem.podePular = true;
                
            }
            Collider2D hitDuplo = Physics2D.OverlapCircle(puloDuplo.position, radius, layer);
            if (hitDuplo != null)
            {
                caixaDeDialogo.SetActive(true);
                puloTxt.text = textoDoPuloDuplo;
                StartCoroutine(DesaparecerTexto());
                personagem.podePularDuplo = true;
            }
        }
    }

    IEnumerator DesaparecerTexto()
    {
        yield return new WaitForSeconds(1f);
        caixaDeDialogo.SetActive(false);
    }
}
