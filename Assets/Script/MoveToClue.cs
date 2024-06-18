using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToClue : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;

    public void OnCameraButtonClick()
    {
        if (Object1.activeSelf)
        {
            SceneManager.LoadScene("clue_ECC");
        }
        else if (Object2.activeSelf)
        {
            SceneManager.LoadScene("clue_POSCO");
        }
        else if (Object3.activeSelf)
        {
            SceneManager.LoadScene("clue_ASAN");
        }
    }
}
