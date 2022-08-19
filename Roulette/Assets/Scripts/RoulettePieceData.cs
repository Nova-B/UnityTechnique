using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �귿 �� ������ ������
/// </summary>
[System.Serializable]
public class RoulettePieceData
{
    public Sprite icon; //������ �̹��� ����
    public string description;  //�̸�, �Ӽ�, �ɷ�ġ ����

    //3���� ������ ����Ȯ���� 100, 60, 40�̸�
    //����Ȯ���� ���� 200.    50%, 30% 20%
    [Range(1, 100)]
    public int chance = 100; //����Ȯ��

    [HideInInspector]
    public int index;   //������ ����
    [HideInInspector]
    public int weight;  //����ġ
}
