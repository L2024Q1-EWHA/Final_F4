using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ECCGameController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject restartButton;
    public GameObject bubblePrefab;
    public Canvas canvas;
    public TMP_Text remainingBubblesText;
    public TMP_Text timerText;
    public GameObject howtoplay;
    public GameObject ECC_Final_Hint;
    public GameObject backButton;
    public GameObject gameClear;
    public GameObject gameOver;

    private int remainingBubbles = 15;
    private int bubblecount = 15;
    private float gameTime = 10f;
    private bool gameActive = false;

    public void Start()
    {
        restartButton.SetActive(false);
        backButton.SetActive(false);
        gameClear.SetActive(false);
        gameOver.SetActive(false);
        timerText.enabled = false;
        remainingBubblesText.enabled = false;
    }

    // 게임 설정값 초기화
    private void InitializeGame()
    {
        remainingBubbles = bubblecount;
        gameTime = 10f;
        gameActive = false;
        timerText.enabled = false;
        remainingBubblesText.enabled = false;
        startButton.SetActive(true);
        restartButton.SetActive(false);
        ECC_Final_Hint.SetActive(false);
        backButton.SetActive(false);
        gameClear.SetActive(false);
        gameOver.SetActive(false);
    }

    // 게임 시작
    public void StartGame()
    {
        timerText.enabled = true;
        howtoplay.SetActive(false);
        startButton.SetActive(false);
        gameActive = true;
        UpdateRemainingBubblesText();
        StartCoroutine(SpawnBubbles());
        StartCoroutine(GameTimer());
    }

    // 버블 스폰 코루틴
    private IEnumerator SpawnBubbles()
    {
        for (int i = 0; i < bubblecount; i++)
        {
            if (!gameActive) yield break;

            Vector2 randomPosition = new Vector2(
                Random.Range(0, canvas.pixelRect.width),
                Random.Range(0, canvas.pixelRect.height)
            );

            GameObject bubble = Instantiate(bubblePrefab, randomPosition, Quaternion.identity, canvas.transform);
            bubble.GetComponent<Button>().onClick.AddListener(() => BubbleClicked(bubble));

            yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        }
    }

    // 타이머 코루틴
    private IEnumerator GameTimer()
    {
        while (gameTime > 0)
        {
            timerText.text = "제한 시간: " + gameTime.ToString("F2") + "초";
            yield return new WaitForSeconds(0.1f);
            gameTime -= 0.1f;
        }

        timerText.text = "제한 시간 : 0.00초";
        if (remainingBubbles > 0)
        {
            EndGame(false);
        }
    }

    // 버블 클릭 시
    private void BubbleClicked(GameObject bubble)
    {
        if (!gameActive) return;

        Destroy(bubble);
        remainingBubbles--;
        UpdateRemainingBubblesText();

        if (remainingBubbles <= 0)
        {
            EndGame(true);
        }
    }

    // 남은 버블 수 출력
    private void UpdateRemainingBubblesText()
    {
        // remainingBubblesText.text = "남은 개수: " + remainingBubbles;
    }

    // 게임 종료(isWin : 게임 클리어)
    private void EndGame(bool isWin)
    {
        gameActive = false;
        StopAllCoroutines();

        if (isWin)
        {
            // timerText.text = "GAME CLEAR";
            ECC_Final_Hint.SetActive(true);
            backButton.SetActive(true);
            gameClear.SetActive(true);

        }
        else
        {
            // timerText.text = "GAME OVER";
            restartButton.SetActive(true);
            gameOver.SetActive(true);
        }
    }

    // 게임 재시작
    public void RestartGame()
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.CompareTag("Bubble"))
            {
                Destroy(child.gameObject);
            }
        }

        InitializeGame();
        StartGame();
    }

    // 씬 전환
    public void ChangeMapScene()
    {
        SceneManager.LoadScene("final_ECC");
    }
}
