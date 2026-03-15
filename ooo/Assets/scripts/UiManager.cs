using System;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _rock;
    [SerializeField] private TMP_Text _wood;
    [SerializeField] private TMP_Text _sword;

    public static UiManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void ActualiseUi(ObjectType type, int value)
    {
        switch (type)
        {
            case ObjectType.Rock:
                _rock.text = "Rock : " + value.ToString();
                break;
            case ObjectType.Wood:
                _wood.text = "Wood : " + value.ToString();
                break;
            case ObjectType.Sword:
                _sword.text = "Sword : " + value.ToString();
                break;
        }
    }
}
