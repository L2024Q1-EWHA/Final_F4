using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AsanGameManager : MonoBehaviour
{
    public GameObject gun;
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject shootBtn;
    public GameObject Scoretext;
    public TextMeshProUGUI score;

    public void GameStart()
    {
        startPanel.SetActive(false);
        shootBtn.SetActive(true);
        Scoretext.SetActive(true);
    }

    public void MakeGun()
    {
        gun.SetActive(true);
    }

    public void CheckGameEnd()
    {
        if (GameObject.Find("Ghost1") == null && GameObject.Find("Ghost2") == null)
        {
            // ��� óġ
            Debug.Log("���� ��� óġ");
            score.text = "�� óġ 2/2";
            GameEnd();
        }
        else if (GameObject.Find("Ghost1") == null || GameObject.Find("Ghost2") == null)
        {
            // �ϳ��� óġ
            score.text = "�� óġ 1/2";
        }
        else
        {
            // ��� �������
            score.text = "�� óġ 0/2";
        }
    }

    void GameEnd()
    {
        endPanel.SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("final_ASAN");
    }
}
