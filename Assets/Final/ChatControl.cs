using UnityEngine;
using UnityEngine.UI;

public class ChatControl: MonoBehaviour
{
    public GameObject text1; 
    public GameObject text2; 
    public GameObject chatObject;
    public GameObject nextButton;
    private bool isToggled = false; 

    void Start()
    {
        // Button ������Ʈ�� ������ Ŭ�� �̺�Ʈ�� �޼��� �߰�
        Button toggleButton = GetComponent<Button>();
        toggleButton.onClick.AddListener(ToggleObjects);
    }

    void ToggleObjects()
    {
        if (!isToggled)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            isToggled = true;
        }
        else
        {
            nextButton.SetActive(true);
            chatObject.SetActive(false);
        }
    }
}