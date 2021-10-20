using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoQuebravel : MonoBehaviour
{
    [Header("Controle de Vida")]
    public int saudeMaxima = 60;
    public int saude;
    
    [Header("Levar Dano no Personagem")]
    private SpriteRenderer sr;

    public SpriteRenderer sr1;
    public SpriteRenderer sr2;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        saude = saudeMaxima;
    }

    public void Saude(int dano)
    {
        saude -= dano;
        if (saude == 40)
        {
            sr.sprite = sr1.sprite;
        }

        switch (saude)
        {
            case 40:
                sr.sprite = sr1.sprite;
            break;
            
            case 20:
                sr.sprite = sr2.sprite;
            break;
        }

        if(saude >= saudeMaxima)
        {
            saude = saudeMaxima;
        }else if(saude <= 0)
        {
            saude = 0;
            Destroy(gameObject);
            Debug.Log("Fim de Jogo");
        }
    }
}
