using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    [Header("초기 아이템 오브젝트 풀링 갯수")]
    [SerializeField] int[] objectNum;
    [SerializeField] GameObject[] items;

    Dictionary<string, GameObject> itemDic = new Dictionary<string, GameObject>();
    
    Queue<Item> objectPoolingQueue = new Queue<Item>();
    Dictionary<string, Queue<Item>> queueDic = new Dictionary<string, Queue<Item>>();
    private void Awake()
    {
        Instance = this;
        Initialize();
    }

    Item CreateObject(string key)
    {
        var itemObj = Instantiate(itemDic[key], transform).GetComponent<Item>();
        itemObj.gameObject.SetActive(false);
        return itemObj;
    }
    private void Initialize()
    {
        for (int i = 0; i < items.Length; i++)
        {
            itemDic.Add(items[i].name, items[i]);
            queueDic.Add(items[i].name, new Queue<Item>());
        }
        int id = 0;
        foreach (var key in itemDic.Keys)
        {
            for (int j = 0; j < objectNum[id]; j++)
            {
                queueDic[key].Enqueue(CreateObject(key));
                //CreateObject(key);
            }
            id++;
        }
    }
    public static Item GetObject(string key)
    {
        if (Instance.queueDic[key].Count > 0)
        {
            var tmpObj = Instance.queueDic[key].Dequeue();
            tmpObj.transform.SetParent(null);
            tmpObj.gameObject.SetActive(true);
            return tmpObj;
        }
        else
        {
            var tmpObj = Instance.CreateObject(key);
            tmpObj.transform.SetParent(null);
            tmpObj.gameObject.SetActive(true);
            return tmpObj;
        }
    }

    public static void ReturnObject(Item item, string key)
    {
        item.gameObject.SetActive(false);
        item.transform.SetParent(Instance.transform);
        Instance.queueDic[key].Enqueue(item);
    }
}
