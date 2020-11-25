using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //수류탄의 역할 
    //총알은 생성하면 스스로 날아가다가 충돌하면 폭발.
    //하지만 수류탄은 생성되자마자 스스로 이동하면 안됨. 
    //수류탄은 플레이어가 직접 던져야 함.
    //수류탄이 다른 오브젝트와 충돌 시 폭발하면서 자신도 사라져야 함.

    public GameObject fxFactory;    //이펙트 프리팹

    //충돌처리 
    private void OnCollisionEnter(Collision collision)
    {
        //폭발이펙트 생성 
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;

        //다른 오브젝트 삭제
        //자기자신도 삭제하기 
        Destroy(gameObject);
    }
}
