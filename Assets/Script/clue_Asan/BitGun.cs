using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BitGun : MonoBehaviour
{
    public Camera fpsCamera;         // �÷��̾ �����ϴ� ��ġ�� ����
    public float range = 100f;       // ������ �󸶳� ����Ǵ��� ����, ������ ������ �� �� �ִ�.
    public float damage = 10f;       //������ �ִ� ���ط�

    public float impactForce = 60f;     // Raycast�� Rigidbody ��Ұ� ������ ��ü�� �����ϴ� ��� ���ǵǴ� �縸ŭ ���� ���Ѵ�.


    //�����丵 ����
    public void shoot()
    {
        RaycastHit hit; // ���̿��� ��ȯ�� ������ �����ϴ� ����
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {   // �ݶ��̴��� ���� ������Ʈ�� �浹 ���θ� üũ�մϴ�. �浹�� �Ǹ� True�� ��ȯ�ϰ�, RaycastHit�� �浹������ �Ѱ���.

            Ghost ghost = hit.transform.GetComponent<Ghost>();  // �浹�� ������ �浹ü���� EnemyCube�� ���� ������Ʈ ������ �����ɴϴ�.

            if (hit.transform != null)  // ���� ���� �����Ѵٸ�
            {
                //Debug.Log("���� �¾Ҵ� " + hit.transform.name);
                ghost.Attacked();
            }

/*            if (hit.rigidbody != null)  // RayCast�� ������ ���� ������Ʈ�� Rigidbody ������Ұ� �ִٸ�
            {
                Debug.Log("�з����� " + hit.collider.name);
                hit.rigidbody.AddForce(-hit.normal * impactForce); // AddForce(���� * �� ��)
            }*/

        }
        Debug.Log("�߻�!");
        GameObject.Find("AsanGameManager").GetComponent<AsanGameManager>().CheckGameEnd();
    }
}
