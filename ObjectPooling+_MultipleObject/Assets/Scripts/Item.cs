using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected string id = "아이템";
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Explain();
    }
    protected virtual void Explain()
    {
        Debug.Log(id + "을 던집니다");
    }
    public void Shoot(Vector3 dir)
    {
        direction = dir;
        Invoke("DestoryItem", 3f);
    }

    protected virtual void DestoryItem()
    {
        ObjectPooling.ReturnObject(this, id);
    }

    private void Update()
    {
        transform.Translate(direction);
    }
}
