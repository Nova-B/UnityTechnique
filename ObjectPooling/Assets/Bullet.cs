using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;

    public void Shoot(Vector3 dir)
    {
        direction = dir;
        Invoke("DestoryBullet", 5f);
    }

    private void DestoryBullet()
    {
        ObjectPool.ReturnObject(this);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction);
    }
}
