using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadradoEsmagador : MonoBehaviour
{
    [Header("Tempo e Velocidade")]
    public float tempoMaximo;
    public float velocidade;

    private AudioSource audioPilar;
    
    private CameraShake camera;
    private Rigidbody2D rb;
    private bool telaTreme;
    [SerializeField] private float tempo;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = FindObjectOfType<CameraShake>();
        audioPilar = GetComponent<AudioSource>();
        telaTreme = false;
    }

    private void FixedUpdate()
    {
        tempo += Time.fixedDeltaTime;
        if (tempo >= tempoMaximo)
        {
            velocidade *= -1;
            tempo = 0;
            if (telaTreme)
            {
                audioPilar.Play();
                camera.TremerCamera();
            }
        }
        rb.velocity = new Vector2(rb.velocity.x, velocidade);
    }

    #region >> Colisões <<
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                
                telaTreme = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                telaTreme = false;
            }
        }
        
    #endregion
    
}
