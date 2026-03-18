using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Recoltable : MonoBehaviour
{
    public Vector3 sourcePosition;
    private Collider2D collider;
    private

    IEnumerator RechargeSource()
    {
        yield return new WaitForSeconds(10);
        transform.position = sourcePosition;
    }
    private void Start()
    {
        collider = GetComponent<Collider2D>();
        sourcePosition = transform.position;
    }

    public void RessourceRecolte()
    {
        transform.position = new Vector3(100, 100, 100);
        StartCoroutine(RechargeSource());
    }
}
