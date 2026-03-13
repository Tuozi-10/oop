using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private stock stock;
    [SerializeField] private TMP_Text[] text;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        text[0].text = stock.bois + " Bwa";
        text[1].text = stock.pierre + " Pyhère";
        text[2].text = stock.sword + " Souworde";
    }
}
