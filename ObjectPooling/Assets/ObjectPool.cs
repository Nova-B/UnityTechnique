using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField]
    private GameObject poolingObjectPrefabs;

    private Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }

    private Bullet CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefabs, transform).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    private void Initialize(int count)
    {
        for(int i =0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public static Bullet GetObject()    //ť�� �ִ� ������Ʈ�� �������ִ� �Լ�
    {
        if(Instance.poolingObjectQueue.Count > 0)//������ �� ���� ��
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else//������ �� ���� ��
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(Bullet bullet)   //������ ������Ʈ ��ȯ�ϴ� �Լ�
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(bullet);
    }
}
