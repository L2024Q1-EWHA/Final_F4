using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BitGun : MonoBehaviour
{
    public Camera fpsCamera;         // 플레이어가 조준하는 위치를 결정
    public float range = 100f;       // 광선이 얼마나 투사되는지 결정, 무기의 범위로 볼 수 있다.
    public float damage = 10f;       //적에게 주는 피해량

    public float impactForce = 60f;     // Raycast가 Rigidbody 요소가 부착된 객체와 교차하는 경우 정의되는 양만큼 힘을 가한다.


    //리팩토링 진행
    public void shoot()
    {
        RaycastHit hit; // 레이에서 반환된 정보를 보유하는 변수
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {   // 콜라이더를 가진 오브젝트와 충돌 여부를 체크합니다. 충돌이 되면 True를 반환하고, RaycastHit로 충돌정보를 넘겨줌.

            Ghost ghost = hit.transform.GetComponent<Ghost>();  // 충돌을 감지한 충돌체에서 EnemyCube에 대한 컴포넌트 정보를 가져옵니다.

            if (hit.transform != null)  // 적이 만약 존재한다면
            {
                //Debug.Log("적에 맞았다 " + hit.transform.name);
                ghost.Attacked();
            }

/*            if (hit.rigidbody != null)  // RayCast로 적중한 게임 오브젝트에 Rigidbody 구성요소가 있다면
            {
                Debug.Log("밀려났다 " + hit.collider.name);
                hit.rigidbody.AddForce(-hit.normal * impactForce); // AddForce(방향 * 힘 값)
            }*/

        }
        Debug.Log("발사!");
        GameObject.Find("AsanGameManager").GetComponent<AsanGameManager>().CheckGameEnd();
    }
}
