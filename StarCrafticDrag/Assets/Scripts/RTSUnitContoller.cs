using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnitContoller : MonoBehaviour
{
    [SerializeField]
    private UnitSpawner unitSpawner;
    private List<UnitController> selectedUnitList;//드래그로 선택한 유닛
    public List<UnitController> UnitList { get; private set; }//맵에 존재하는 모든 유닛

    private void Awake()
    {
        selectedUnitList = new List<UnitController>();
        UnitList = unitSpawner.SpawnUnits();
    }

    ///<summary>
    ///마우스 클릭으로 유닛을 선택할 때 호출
    /// </summary>
    public void ClickSelectUnit(UnitController newUnit)
    {
        //기존 선택 유닛 모두 해제
        DeselectAll();

        SelectUnit(newUnit);
    }

    ///<summary>
    ///Shift+마우스 클릭으로 유닛을 선택할 때 호출
    /// </summary>
    public void ShiftClickSelectUnit(UnitController newUnit)
    {
        //기존에 선택되어 있는 유닛을 선택했으면
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
    ///선택된 모든 유닛을 이동할 때 호출
    /// </summary>
    public void MoveSelectedUnits(Vector3 end)
    {
        for(int i = 0; i < selectedUnitList.Count; ++i)
        {
            selectedUnitList[i].MoveTo(end);
        }
    }

    ///<summary>
    ///마우스 드래그로 유닛을 선택할 때 호출
    /// </summary>
    public void DragSelectUnit(UnitController newUnit)
    {
        if(!selectedUnitList.Contains(newUnit))
        {
            SelectUnit(newUnit);
        }
    }

    /// <summary>
    /// 모든 유닛의 선택을 해체할 때 호출
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
        newUnit.SelectUnit();//선택된 유닛 밑에 원 활성화

        selectedUnitList.Add(newUnit); //선택한 유닛정보 리스트에 저장
    }

    private void Deselectunit(UnitController newUnit)
    {
        newUnit.DeselectUnit();//선택된 유닛 밑에 원 비활성화

        selectedUnitList.Remove(newUnit);//선택한 유닛정보 리스트에서 제거
    }
}
