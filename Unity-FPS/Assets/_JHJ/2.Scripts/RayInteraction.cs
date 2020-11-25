using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteraction : MonoBehaviour
{
    Camera playerCam;
    public float distance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
    }

    void FireBullet()
    {
        //Vector3 rayOrigin = playerCam.transform.position;

        //카메라 상의 위치를 찍으면 실제 월드좌표로 바꿔줌.
        //
        Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));

        if(Input.GetMouseButtonDown(0))
        {

        }
    }
}
