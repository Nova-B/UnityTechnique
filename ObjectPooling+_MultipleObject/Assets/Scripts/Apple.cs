using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Item
{
    // Start is called before the first frame update
    void Start()
    {
        id = "Apple";
        Explain();
    }

    protected override void Explain()
    {
        Debug.Log(id + "�� �����ϴ�");
    }
    protected override void DestoryItem()
    {
        ObjectPooling.ReturnObject(this, id);
    }
}
