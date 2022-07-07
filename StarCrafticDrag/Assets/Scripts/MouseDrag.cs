using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField]
    private RectTransform dragRectangle;
    //���콺�� �巡���� ������ ����ȭ�ϴ� image UI�� RectTrasnfrom

    private Rect dragRect;//�巡���� ����
    private Vector2 start = Vector2.zero;//�巡�� ���� ��ġ
    private Vector2 end = Vector2.zero;//�巡�� ���� ��ġ

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

            //���콺 �� �� start�� end 0,0�� �Ⱥ��̰�
            start = end = Vector2.zero;
            DrawDragRectangle();
        }
    }

    private void DrawDragRectangle()
    {
        //�巡�� ���� �̹��� UI ��ġ
        dragRectangle.position = (start + end) * 0.5f;
        //�巡�� ���� �̹��� UI ũ��(����)
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
        //��� ������ �˻�
        foreach(UnitController unit in rtsUnitContoller.UnitList)
        {
            //������ ���� ��ǥ�� ȭ�� ��ǥ�� ��ȯ�� �巡�� ���� ���� �ִ��� �˻�
            if(dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position)))
            {
                rtsUnitContoller.DragSelectUnit(unit);
            }
        }
    }
}
