using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField]
    private RectTransform dragRectangle;
    //마우스로 드래그한 범위를 가시화하는 image UI의 RectTrasnfrom

    private Rect dragRect;//드래그한 범위
    private Vector2 start = Vector2.zero;//드래그 시작 위치
    private Vector2 end = Vector2.zero;//드래그 종료 위치

    private Camera mainCamera;
    private RTSUnitContoller rtsUnitContoller;

    private void Awake()
    {
        mainCamera = Camera.main;
        rtsUnitContoller = GetComponent<RTSUnitContoller>();

        DrawDragRectangle();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            start = Input.mousePosition;
            dragRect = new Rect();
        }

        if(Input.GetMouseButton(0))
        {
            end = Input.mousePosition;

            DrawDragRectangle();
        }

        if(Input.GetMouseButtonUp(0))
        {
            CalculateDragRect();
            SelectUnits();

            //마우스 땔 시 start와 end 0,0로 안보이게
            start = end = Vector2.zero;
            DrawDragRectangle();
        }
    }

    private void DrawDragRectangle()
    {
        //드래그 범위 이미지 UI 위치
        dragRectangle.position = (start + end) * 0.5f;
        //드래그 범위 이미지 UI 크기(절댓값)
        dragRectangle.sizeDelta = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
    }

    private void CalculateDragRect()
    {
        if(Input.mousePosition.x < start.x)
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }
        else
        {
            dragRect.xMin = start.x;
            dragRect.xMax = Input.mousePosition.x;
        }

        if(Input.mousePosition.y < start.y)
        {
            dragRect.yMin = Input.mousePosition.y;
            dragRect.yMax = start.y;
        }
        else
        {
            dragRect.yMin = start.y;
            dragRect.yMax = Input.mousePosition.y;
        }
    }

    private void SelectUnits()
    {
        //모든 유닛을 검사
        foreach(UnitController unit in rtsUnitContoller.UnitList)
        {
            //유닛의 월드 좌표를 화면 좌표로 변환해 드래그 범위 내에 있는지 검사
            if(dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position)))
            {
                rtsUnitContoller.DragSelectUnit(unit);
            }
        }
    }
}
