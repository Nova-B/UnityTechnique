using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Camera maiCam;
    // Start is called before the first frame update
    void Start()
    {
        maiCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("1"))
        {
            RaycastHit hits;
            if(Physics.Raycast(maiCam.ScreenPointToRay(Input.mousePosition), out hits))
            {
                Debug.Log(1);
                Vector3 direction = new Vector3(hits.point.x, transform.position.y, hits.point.z) - transform.position;
                var obj = ObjectPooling.GetObject("Apple");
                obj.transform.position = transform.position + direction.normalized;
                obj.Shoot(direction.normalized);
            }
        }

        if (Input.GetKey("2"))
        {
            Debug.Log(2);
            RaycastHit hits;
            if (Physics.Raycast(maiCam.ScreenPointToRay(Input.mousePosition), out hits))
            {
                Vector3 direction = new Vector3(hits.point.x, transform.position.y, hits.point.z) - transform.position;
                var obj = ObjectPooling.GetObject("Banana");
                obj.transform.position = transform.position + direction.normalized;
                obj.Shoot(direction.normalized);
            }
        }
    }
}
