using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolingManager : MonoBehaviour
{ 
    public static PoolingManager instance;
    public List<GameObject> pool;
    private void Awake()
    {
        instance = this;
    }
    public GameObject PullObjectFromPool()
    {
        if(pool.Count>0)
        {
            GameObject obj=pool.First();
            pool.Remove(obj);
            obj.gameObject.SetActive(false);
            return obj;
        }
        return Instantiate(gameObject);
    }
    public void AddObjectToPool(GameObject obj)
    {
        obj.gameObject.SetActive(true);
        pool.Add(obj);
    }

    public void SendToBottom()
    {
        GameObject disk = PullObjectFromPool();
        disk.transform.position = pool.Last().transform.position - Vector3.up * 3;
        CreateDisk.instance.SetDiskColors(disk);
        AddObjectToPool(disk);
    }
}
