using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Recoltable : MonoBehaviour
{
    public Vector3 sourcePosition;
    private Collider2D _collider;
    public bool ressourceDispo = true;

    IEnumerator RechargeSource()
    {
        yield return new WaitForSeconds(10);
        _collider.enabled = true;
        ressourceDispo = true;
        //transform.position = sourcePosition;
    }
    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        sourcePosition = transform.position;
    }

    public void RessourceRecolte()
    {
        //transform.position = new Vector3(100, 100, 100);
        _collider.enabled = false;
        ressourceDispo = false;
        StartCoroutine(RechargeSource());
    }
}
