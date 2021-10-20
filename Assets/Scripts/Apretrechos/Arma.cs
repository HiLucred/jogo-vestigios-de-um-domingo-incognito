using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [Header("Configurações da Arma")]
    public Transform lugarDoDisparo;
    public Transform lugarDaArma;
    public GameObject balaPrefab;

    //Câmera treme ao atirar
    private CameraShake camera;
    //Efeito sonoro ao atirar
    public AudioSource somTiro;

    [Header("Particula de Tiro")]
    public ParticleSystem particulaDoTiro;

    [Header("Animação de Recuo")] 
    private Animator animTiro;

    //Movimento da Arma
    private Dinamico dinamicoAcionar;
    
    private bool podeAtirar;
    
    private void Awake()
    {
        dinamicoAcionar = GetComponent<Dinamico>();
        camera = FindObjectOfType<CameraShake>();
        animTiro = GetComponent<Animator>();
    }

    void Update()
    {
        if (podeAtirar)
        {
            animTiro.SetBool("animTiro",false);
            if (Input.GetButtonDown("Fire1"))
            {
                Disparo();
                camera.TremerCamera();
                particulaDoTiro.Play();
            }
        }
        
    }

    void Disparo()
    {
        Instantiate(balaPrefab, lugarDoDisparo.position, lugarDoDisparo.rotation);
        animTiro.SetBool("animTiro",true);
        somTiro.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.parent = lugarDaArma;
            gameObject.transform.position = lugarDaArma.position;
            dinamicoAcionar.velocidade = 0;
            podeAtirar = true;
        }
    }
}
