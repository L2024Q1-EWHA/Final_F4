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
        PlayerPrefs.DeleteAll();    // ��� �÷��̾� ���� ���� �ʱ�ȭ

        BackgroundImg.SetActive(false);
        Tutorial.SetActive(false);
        StartButton.SetActive(false);
        Title.SetActive(true);

        if (TtS == null)
        {
            Debug.LogError("TtS (TextMeshPro) ������Ʈ�� �Ҵ��ϼ���!");
        }
        else
        {
            StartCoroutine(FadeText());
        }

        if (cameraMovement == null)
        {
            Debug.LogError("CameraMovement ��ũ��Ʈ�� �Ҵ��ϼ���!");
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
                Debug.LogError("StartButton�� Button ������Ʈ�� �߰��ϼ���!");
            }
        }
        else
        {
            Debug.LogError("StartButton ������Ʈ�� �Ҵ��ϼ���!");
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) // ��ġ �Ǵ� ���콺 Ŭ�� ����
        {
            if (!isTouched)
            {
                isTouched = true;
                Debug.Log("ȭ�� ��ġ ��");
                StopCoroutine(FadeText()); // ������ ���� �ڷ�ƾ ����
                StartCoroutine(FadeOutTextAndDisable(0.5f)); // 0.5�� ���� �ؽ�Ʈ ������ 0���� ���� �� ��Ȱ��ȭ
                cameraMovement.StopCameraMovement(0.5f); // ī�޶� �������� 0.5�� �Ŀ� ����
                StartCoroutine(ShowTutorial(0.5f)); // 0.5�� �Ŀ� Ʃ�丮�� ��Ÿ����
            }
        }
    }

    IEnumerator ShowTutorial(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Ʃ�丮�� ����");
        BackgroundImg.SetActive(true);
        Tutorial.SetActive(true);
        StartButton.SetActive(true);
    }

    IEnumerator FadeText()
    {
        while (!isTouched)
        {
            yield return StartCoroutine(FadeTo(0.2f, 1f)); // ������ 20���� ���̵�
            yield return StartCoroutine(FadeTo(0.9f, 1f)); // ������ 90���� ���̵�
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

        // �ؽ�Ʈ ��Ȱ��ȭ
        TtS.SetActive(false);
        Title.SetActive(false);
    }

    // StartButton�� Ŭ���� �� ȣ��� �޼���
    void OnStartButtonClicked()
    {
        Debug.Log("���ӽ���");
    }
}
