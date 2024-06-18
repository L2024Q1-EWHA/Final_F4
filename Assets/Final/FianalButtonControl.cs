using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FianalButtonControl : MonoBehaviour
{
    public Button selectButton; // UI Button
    public GameObject object1; 
    public GameObject object2; 
    public GameObject object3; 

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 등록
        selectButton.onClick.AddListener(OnSelectButtonClicked);
    }

    void OnSelectButtonClicked()
    {
        // 오브젝트 활성화
        object1.SetActive(true);
        object2.SetActive(true);
        object3.SetActive(true);

        // 버튼 비활성화
        selectButton.gameObject.SetActive(false);
    }

    public void OnNextButtonClicked()
    {
        SceneManager.LoadScene("Map");
    }

    public void OnNextStartScene()
    {
        SceneManager.LoadScene("Maingate");
    }
}
