using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*<유니티 관련 다출 면접문제> 
 * 
 * 유니티 최적화
 * 1. 오브젝트 풀링 
 * 2. 정점수 줄이기 LOD
 * 3. 파티클에서 3D모델보다는 가급적 스프라이트 사용하기 
 * 4. 사용하지 않는 함수 제거하기 
 * 5. 레이어 마스크를 사용하여 충돌처리(불필요한 충돌로 인한 연산 방지)
 * 유니티 내부적으로 속도 향상을 위해 비트연산 처리 
 * 총 32비트를 사용하기 때문에 레이어도 32개까지 추가 가능 
 * 
 * */

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFX;
    public GameObject bombFactory;  //폭탄 프리팹 
    public GameObject firePoint;    //폭탄 발사위치 
    public float power = 20f;       //폭탄이 날아가는 파워 

    //private void Start()
    //{
    //    int layer = gameObject.layer;
    //    layer = 1 << 8 | 1 << 9 | 1 << 10;
    //}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if (Input.GetMouseButtonDown(1))
        {
            FireBomb();
        }
    }

    public void Fire()
    {
        Ray ray = new Ray(Camera.main.transform.position,
                  Camera.main.transform.forward);

        RaycastHit hitInfo;

        //레이랑 충돌했나?
        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log("충돌오브젝트 : " + hitInfo.transform.name);

            //충돌지점에 총알이펙트 생성
            GameObject bulletFxObj = Instantiate(bulletFX);

            //충돌한 오브젝트에 대한 정보는 hitInfo 안에 들어있음.
            bulletFxObj.transform.position = hitInfo.point;

            //파편이 부딪힌 지점이 향하는 방향으로 튀게 해주어야 함.
            bulletFxObj.transform.forward = hitInfo.normal;
        }
    }

    public void FireBomb()
    {
        GameObject bomb = Instantiate(bombFactory);
        bomb.transform.position = firePoint.transform.position;

        //폭탄은 플레이어가 던지기 때문에 
        //폭탄의 리지드바디를 이용해서 던지면 됨. 
        Rigidbody rb = bomb.GetComponent<Rigidbody>();

        //전방으로 물리적인 힘을 가한다. 
        //rb.AddForce(Camera.main.transform.forward * power, ForceMode.Impulse);

        //45도 각도로 발사 
        Vector3 dir = Camera.main.transform.forward + (Camera.main.transform.up * 1.5f);
        rb.AddForce(dir * power, ForceMode.Impulse);
    }
}
