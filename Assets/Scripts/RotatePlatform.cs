using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    private float screenWidth;
    private Vector3 pressPoint;
    private Quaternion startRotation;
    private void Start()
    {
        screenWidth = Screen.width;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))//fareye bastığımız an true ve hemen ardından false
        {
            pressPoint = Input.mousePosition;
            startRotation = transform.rotation;
        }

        if(Input.GetMouseButton(0)) //fare basılı olduğu sürece true
        {
            float mouseDelta = (Input.mousePosition - pressPoint).x; // a = mouse'un 1 önceki frame ile şimdiki frame (an) arasındaki pozisyon farkı. türev
            transform.rotation = startRotation * Quaternion.Euler(Vector3.down * (mouseDelta / screenWidth) * 360);
        }
    }
}
