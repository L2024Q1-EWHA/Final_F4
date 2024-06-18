using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class TouchTextEffect : MonoBehaviour
{
    public GameObject TtS;
    public GameObject BackgroundImg;
    public GameObject Tutorial;
    public GameObject StartButton;
    public GameObject Title;
    public CameraMovement cameraMovement;
    private bool isTouched = false;

    void Start()
    {
        PlayerPrefs.DeleteAll();    // 모든 플레이어 게임 정보 초기화

        BackgroundImg.SetActive(false);
        Tutorial.SetActive(false);
        StartButton.SetActive(false);
        Title.SetActive(true);

        if (TtS == null)
        {
            Debug.LogError("TtS (TextMeshPro) 오브젝트를 할당하세요!");
        }
        else
        {
            StartCoroutine(FadeText());
        }

        if (cameraMovement == null)
        {
            Debug.LogError("CameraMovement 스크립트를 할당하세요!");
        }

        
        if (StartButton != null)
        {
            Button startButtonComponent = StartButton.GetComponent<Button>();
            if (startButtonComponent != null)
            {
                startButtonComponent.onClick.AddListener(OnStartButtonClicked);
            }
            else
            {
                Debug.LogError("StartButton에 Button 컴포넌트를 추가하세요!");
            }
        }
        else
        {
            Debug.LogError("StartButton 오브젝트를 할당하세요!");
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) // 터치 또는 마우스 클릭 감지
        {
            if (!isTouched)
            {
                isTouched = true;
                Debug.Log("화면 터치 됨");
                StopCoroutine(FadeText()); // 불투명도 변경 코루틴 정지
                StartCoroutine(FadeOutTextAndDisable(0.5f)); // 0.5초 동안 텍스트 불투명도 0까지 감소 후 비활성화
                cameraMovement.StopCameraMovement(0.5f); // 카메라 움직임을 0.5초 후에 정지
                StartCoroutine(ShowTutorial(0.5f)); // 0.5초 후에 튜토리얼 나타내기
            }
        }
    }

    IEnumerator ShowTutorial(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("튜토리얼 등장");
        BackgroundImg.SetActive(true);
        Tutorial.SetActive(true);
        StartButton.SetActive(true);
    }

    IEnumerator FadeText()
    {
        while (!isTouched)
        {
            yield return StartCoroutine(FadeTo(0.2f, 1f)); // 불투명도 20까지 페이드
            yield return StartCoroutine(FadeTo(0.9f, 1f)); // 불투명도 90까지 페이드
        }
    }

    IEnumerator FadeTo(float targetAlpha, float duration)
    {
        TMP_Text textComponent = TtS.GetComponent<TMP_Text>();
        float startAlpha = textComponent.color.a;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            Color newColor = textComponent.color;
            newColor.a = Mathf.Lerp(startAlpha, targetAlpha, elapsed / duration);
            textComponent.color = newColor;
            yield return null;
        }

        Color finalColor = textComponent.color;
        finalColor.a = targetAlpha;
        textComponent.color = finalColor;
    }

    IEnumerator FadeOutTextAndDisable(float duration)
    {
        TMP_Text textComponent = TtS.GetComponent<TMP_Text>();
        float startAlpha = textComponent.color.a;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            Color newColor = textComponent.color;
            newColor.a = Mathf.Lerp(startAlpha, 0f, elapsed / duration);
            textComponent.color = newColor;
            yield return null;
        }

        Color finalColor = textComponent.color;
        finalColor.a = 0f;
        textComponent.color = finalColor;

        // 텍스트 비활성화
        TtS.SetActive(false);
        Title.SetActive(false);
    }

    // StartButton이 클릭될 때 호출될 메서드
    void OnStartButtonClicked()
    {
        Debug.Log("게임시작");
    }
}
