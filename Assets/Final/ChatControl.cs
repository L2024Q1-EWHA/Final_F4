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
        // Button 컴포넌트를 가져와 클릭 이벤트에 메서드 추가
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