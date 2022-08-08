using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Item
{
    void Start()
    {
        id = "Banana";
        Explain();
    }
    protected override void Explain()
    {
        Debug.Log(id + "을 던집니다");
    }

    protected override void DestoryItem()
    {
        ObjectPooling.ReturnObject(this, id);
    }
}
