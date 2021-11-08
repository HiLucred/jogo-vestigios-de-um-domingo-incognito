using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(BoxCollider2D))]

public class ZoomCam : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    private CinemachineVirtualCamera virtualCamera = null;

    #endregion


    #region MonoBehaviour

    private void Start ()
    {
        virtualCamera.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.CompareTag("Player") )
            virtualCamera.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ( other.CompareTag("Player") )
            virtualCamera.enabled = false;
    }
    
    private void OnValidate ()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    #endregion
}