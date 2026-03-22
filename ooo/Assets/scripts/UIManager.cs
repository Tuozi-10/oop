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

    // à éviter completement les updates d'UI dans un update, c'est tres couteux, ca force des redraw de l'UI inutils etc, de manière générale pour l'UI il faut:
    // modifier seulement quand la valeur est modifiée ( event, callback, properties ),
    //  et si besoin à chaque update à ce moment là ( genre un timer ), là du coup bien faire un canvas séparé des autres éléments d'UI pour redraw que le nécessaire
    private void Update()
    {
        text[0].text = stock.bois + " Bwa";
        text[1].text = stock.pierre + " Pyhère";
        text[2].text = stock.sword + " Souworde";
    }
}
