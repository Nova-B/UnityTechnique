using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// 조각 정보 갱신 
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
