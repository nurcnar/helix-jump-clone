using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDisk : MonoBehaviour
{
    public static CreateDisk instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject child;
    public GameObject sector;
    private List<GameObject> sisters = new List<GameObject>();
    int i = 0;
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var disk = new GameObject();
            PoolingManager.instance.AddObjectToPool(disk);
            GenerateDisk(disk);
        }
    }

    void GenerateDisk(GameObject disk)
    {
        Vector3 pos = new Vector3(child.transform.position.x, child.transform.position.y - (i * 3), child.transform.position.z);
        disk.transform.rotation = child.transform.rotation;
        disk.transform.position = pos;
        disk.transform.SetParent(this.gameObject.transform);
        i++;
        Birth(disk);
    }
    private void Birth(GameObject disk)
    {
        int k = Random.Range(0, 6);
        for (int j = 0; j < 12; j++)
        {
            int c = Random.Range(0, 3);

            if (j == k)
                continue;
            var o = Instantiate(sector, transform.position, transform.rotation);
            sisters.Add(o);
            o.transform.position = disk.transform.position;
            o.transform.rotation = Quaternion.Euler(sector.transform.eulerAngles.x, sector.transform.rotation.y + 30 * (j + 1), sector.transform.rotation.z);
            o.transform.SetParent(disk.transform);
            var color = o.GetComponent<Renderer>();
            if (c == 1)
                color.material.color = Color.red;
        }
    }

    public void SetDiskColors(GameObject disk)
    {
        foreach (var item in disk.GetComponentsInChildren<Transform>())
        {
            if (item == disk.gameObject)
            {
                continue;
            }
            int c = Random.Range(0, 3);
            var renderer = item.GetComponent<Renderer>();
            if (renderer)
            {
                if (c == 1)
                    renderer.material.color = Color.red;
                else
                    renderer.material.color = new Color32(155,255,153,255);
            }

        }
    }
}