using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnitContoller : MonoBehaviour
{
    [SerializeField]
    private UnitSpawner unitSpawner;
    private List<UnitController> selectedUnitList;//�巡�׷� ������ ����
    public List<UnitController> UnitList { get; private set; }//�ʿ� �����ϴ� ��� ����

    private void Awake()
    {
        selectedUnitList = new List<UnitController>();
        UnitList = unitSpawner.SpawnUnits();
    }

    ///<summary>
    ///���콺 Ŭ������ ������ ������ �� ȣ��
    /// </summary>
    public void ClickSelectUnit(UnitController newUnit)
    {
        //���� ���� ���� ��� ����
        DeselectAll();

        SelectUnit(newUnit);
    }

    ///<summary>
    ///Shift+���콺 Ŭ������ ������ ������ �� ȣ��
    /// </summary>
    public void ShiftClickSelectUnit(UnitController newUnit)
    {
        //������ ���õǾ� �ִ� ������ ����������
        if(selectedUnitList.Contains(newUnit))
        {
            Deselectunit(newUnit);
        }
        else
        {
            SelectUnit(newUnit);
        }
    }

    ///<summary>
    ///���õ� ��� ������ �̵��� �� ȣ��
    /// </summary>
    public void MoveSelectedUnits(Vector3 end)
    {
        for(int i = 0; i < selectedUnitList.Count; ++i)
        {
            selectedUnitList[i].MoveTo(end);
        }
    }

    ///<summary>
    ///���콺 �巡�׷� ������ ������ �� ȣ��
    /// </summary>
    public void DragSelectUnit(UnitController newUnit)
    {
        if(!selectedUnitList.Contains(newUnit))
        {
            SelectUnit(newUnit);
        }
    }

    /// <summary>
    /// ��� ������ ������ ��ü�� �� ȣ��
    /// </summary>
    public void DeselectAll()
    {
        for(int i = 0; i<selectedUnitList.Count; ++i)
        {
            selectedUnitList[i].DeselectUnit();
        }

        selectedUnitList.Clear();
    }

    private void SelectUnit(UnitController newUnit)
    {
        newUnit.SelectUnit();//���õ� ���� �ؿ� �� Ȱ��ȭ

        selectedUnitList.Add(newUnit); //������ �������� ����Ʈ�� ����
    }

    private void Deselectunit(UnitController newUnit)
    {
        newUnit.DeselectUnit();//���õ� ���� �ؿ� �� ��Ȱ��ȭ

        selectedUnitList.Remove(newUnit);//������ �������� ����Ʈ���� ����
    }
}
