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
        // ��ư Ŭ�� �̺�Ʈ�� �޼��� ���
        selectButton.onClick.AddListener(OnSelectButtonClicked);
    }

    void OnSelectButtonClicked()
    {
        // ������Ʈ Ȱ��ȭ
        object1.SetActive(true);
        object2.SetActive(true);
        object3.SetActive(true);

        // ��ư ��Ȱ��ȭ
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
