using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// ���� ���� ���� 
/// </summary>
public class RoulettePiece : MonoBehaviour
{
    [SerializeField]
    private Image imageIcon;
    [SerializeField]
    private TextMeshProUGUI textDescription;

    public void Setup(RoulettePieceData pieceData)
    {
        imageIcon.sprite = pieceData.icon;
        textDescription.text = pieceData.description;
    }
}
