using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerUnit;
    [SerializeField]
    private LayerMask layerGround;

    private Camera mainCamera;
    private RTSUnitContoller rtsUnitContoller;

    private void Awake()
    {
        mainCamera = Camera.main;
        rtsUnitContoller = GetComponent<RTSUnitContoller>();
    }

    private void Update()
    {
        //���콺 ���� Ŭ������ ���� ���� or ����
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //������ �ε����� ������Ʈ�� ���� �� (������ Ŭ������ ��)
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerUnit))
            {
                if (hit.transform.GetComponent<UnitController>() == null) return;

                if(Input.GetKey(KeyCode.LeftShift))
                {
                    rtsUnitContoller.ShiftClickSelectUnit(hit.transform.GetComponent<UnitController>());
                }
                else
                {
                    rtsUnitContoller.ClickSelectUnit(hit.transform.GetComponent<UnitController>());
                }
            }
            else//�ε����� ������Ʈ�� ���� ��
            {
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    rtsUnitContoller.DeselectAll();
                }
            }
        }

        //���콺 ������ Ŭ������ ���� �̵�
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //���� ������Ʈ(layerUnit)�� Ŭ������ ��
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
            {
                rtsUnitContoller.MoveSelectedUnits(hit.point);
            }
        }
    }
}
