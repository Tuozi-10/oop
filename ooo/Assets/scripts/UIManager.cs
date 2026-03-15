using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _woodStorageUI;
    [SerializeField] private TMP_Text _rockStorageUI;
    [SerializeField] private TMP_Text _swordStorageUI;

    private void Update()
    {
        _woodStorageUI.text = MainHouse.Instance.mainWoodStorage.ToString();
        _rockStorageUI.text = MainHouse.Instance.mainRockStorage.ToString();
        _swordStorageUI.text = MainHouse.Instance.mainSwordStorage.ToString();
    }
}
