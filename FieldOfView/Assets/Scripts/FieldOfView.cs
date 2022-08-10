using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float sightRadius;
    [Range(0, 360)]
    public float sightAngle;

    [SerializeField] LayerMask targetLayer;
    [SerializeField] LayerMask obstacleLayer;

    public List<Transform> targetListInFeild = new List<Transform>();

    private void Start()
    {
        StartCoroutine(Detect(0.2f));
    }

    public Vector3 DirectionFromAngle(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad)).normalized;
    }

    IEnumerator Detect(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            DetectTargetInView();
        }
    }

    public void DetectTargetInView()
    {
        targetListInFeild.Clear();
        Collider[] targetsCol = Physics.OverlapSphere(transform.position, sightRadius, targetLayer);
        for(int i = 0; i < targetsCol.Length; i++)
        {
            Transform target = targetsCol[i].transform;
            Vector3 dirTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirTarget) < sightAngle / 2)
            {
                float dstTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, dirTarget, dstTarget, obstacleLayer))
                {
                    targetListInFeild.Add(target);
                }
            }
        }
    }
}
