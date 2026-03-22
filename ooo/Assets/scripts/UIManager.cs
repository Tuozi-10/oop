using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _woodStorageUI;
    [SerializeField] private TMP_Text _rockStorageUI;
    [SerializeField] private TMP_Text _swordStorageUI;

    // haaaa c'était presque un sans faute, c'est dommage l'update pour mettre à jour ton UI, c'est tres couteux, 
    // le mieux à faire serait d'avoir une fonction "UpdateTexts" appellée par exemple dans ton AddToStorage, et autres moments de modifs
    // OU autre possibilité, faire un get/set sur tes mainWoodStorage/Rock/etc, et qu'ils updatent leur texte dans le setter
    private void Update()
    {
        _woodStorageUI.text = MainHouse.Instance.mainWoodStorage.ToString();
        _rockStorageUI.text = MainHouse.Instance.mainRockStorage.ToString();
        _swordStorageUI.text = MainHouse.Instance.mainSwordStorage.ToString();
    }
}
