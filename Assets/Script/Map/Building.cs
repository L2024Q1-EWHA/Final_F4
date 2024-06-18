using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Building : MonoBehaviour
{
    public GameObject panel;
    public GameObject ready_panel;
    public GameObject complete_panel;
    private bool down;

    private bool show;
    public bool ready;   // 스테이지 활성화 전 후
    public bool complete;    // 스테이지 완료 전 후

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ButtonPressed" + PlayerPrefs.GetInt("ButtonPressed").ToString());
        if(PlayerPrefs.GetInt("ButtonPressed") == 1)
        {
            GameObject.Find("Ecc").GetComponent<Building>().ready = true;
            GameObject.Find("Ecc").GetComponent<Building>().complete = true;
            GameObject.Find("Posco").GetComponent<Building>().ready = true;
        }
        else if(PlayerPrefs.GetInt("ButtonPressed") == 2)
        {
            GameObject.Find("Ecc").GetComponent<Building>().ready = true;
            GameObject.Find("Ecc").GetComponent<Building>().complete = true;
            GameObject.Find("Posco").GetComponent<Building>().ready = true;
            GameObject.Find("Posco").GetComponent<Building>().complete = true;
            GameObject.Find("Asan").GetComponent<Building>().ready = true;
        }
        else if(PlayerPrefs.GetInt("ButtonPressed") == 3)
        {
            GameObject.Find("Ecc").GetComponent<Building>().ready = true;
            GameObject.Find("Ecc").GetComponent<Building>().complete = true;
            GameObject.Find("Posco").GetComponent<Building>().ready = true;
            GameObject.Find("Posco").GetComponent<Building>().complete = true;
            GameObject.Find("Asan").GetComponent<Building>().ready = true;
            GameObject.Find("Asan").GetComponent<Building>().complete = true;

        }
        else
        {
            GameObject.Find("Ecc").GetComponent<Building>().ready = true;
        }

        down = false;

        show = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 건물 주변 반짝거리기
        Color color = gameObject.GetComponent<Image>().color;
        if (!down)
        {
            color.a += Time.deltaTime / 3;
            gameObject.GetComponent<Image>().color = color;

            if (color.a > 0.4f)
            {
                down = true;
            }
        }
        else
        {
            color.a -= Time.deltaTime / 3;
            gameObject.GetComponent<Image>().color = color;

            if (color.a < 0.1f)
            {
                down = false;
            }
        }
        
    }

    public void ShowPanel()
    {
        if (!show)
        {
            if (complete)
            {
                complete_panel.SetActive(true); // 스테이지 클리어
            }
            else if (ready)
            {
                panel.SetActive(true);  // 스테이지 활성화
            }
            else
            {
                ready_panel.SetActive(true);    // 스테이지 활성화 전
            }
            show = true;
        }
    }

    public void ExitPanel()
    {
        if (show)
        {
            if (complete)
            {
                complete_panel.SetActive(false); // 스테이지 클리어
            }
            else if (ready)
            {
                panel.SetActive(false);  // 스테이지 활성화
            }
            else
            {
                ready_panel.SetActive(false);    // 스테이지 활성화 전
            }
            show = false;
        }

    }

    // 고민씬으로 이동
    public void ChangeScene()
    {
        Debug.Log("move to " + gameObject.tag);
        if(gameObject.tag == "Ecc")
        {
            PlayerPrefs.SetInt("ButtonPressed", 1);
            SceneManager.LoadScene("Scene2");
        }
        else if(gameObject.tag == "Posco")
        {
            PlayerPrefs.SetInt("ButtonPressed", 2);
            SceneManager.LoadScene("Scene2");
        }
        else if(gameObject.tag == "Asan")
        {
            PlayerPrefs.SetInt("ButtonPressed", 3);
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            Debug.Log("이동 실패");
        }
    }
}
