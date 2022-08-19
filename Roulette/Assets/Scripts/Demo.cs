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
            buttonSpin.interactable = false;//ȸ���ϴ� ���� ������ ����
            roulette.Spin(EndOfSpin);//ȸ������
        });
    }

    void EndOfSpin(RoulettePieceData selectData)
    {
        buttonSpin.interactable = true;
        Debug.Log($"{selectData.index}:{selectData.description}");
    }
}
