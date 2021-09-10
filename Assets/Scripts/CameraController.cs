using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public GameObject line;
    private float distance;
    private Vector3 targetPos;

    void Awake()
    {
        distance = -target.transform.position.y + transform.position.y;
        targetPos = transform.position;
    }
    private void Update()
    {
        if (target.transform.position.y < line.transform.position.y)
        {
            PoolingManager.instance.SendToBottom();
            CameraMove();
            GameManager.instance.Score++;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10);
    }
    // Update is called once per frame
    void CameraMove()
    {
        Vector3 curPos = transform.position;
        curPos.y = target.transform.position.y + distance;
        targetPos = curPos;
        line.transform.position = new Vector3(line.transform.position.x, PoolingManager.instance.pool.First().transform.position.y, line.transform.position.z);
    }
}
