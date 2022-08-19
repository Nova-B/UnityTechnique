using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField]
    private Roulette roulette;
    [SerializeField]
    private Button buttonSpin;

    private void Awake()
    {
        buttonSpin.onClick.AddListener(() =>
        {
            buttonSpin.interactable = false;//회전하는 동안 누르지 못함
            roulette.Spin(EndOfSpin);//회전시작
        });
    }

    void EndOfSpin(RoulettePieceData selectData)
    {
        buttonSpin.interactable = true;
        Debug.Log($"{selectData.index}:{selectData.description}");
    }
}
