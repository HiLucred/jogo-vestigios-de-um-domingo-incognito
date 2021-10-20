using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassarelaQueCai : MonoBehaviour
{
    private TargetJoint2D joint;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    
    //Sprite que eu quero mudar *MUDA ISSO DEPOIS*
    public Sprite spriteMorrendo;

    void Start()
    {
        joint = GetComponent<TargetJoint2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void CairPlataforma()
    {
        bc.isTrigger = true;
        joint.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("CairPlataforma", 1f);
            sr.sprite = spriteMorrendo;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dano"))
        {
            Destroy(gameObject);
        }
    }
}
