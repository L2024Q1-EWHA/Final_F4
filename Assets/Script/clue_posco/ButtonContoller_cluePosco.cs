using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ButtonContoller_cluePosco : MonoBehaviour
{
    public GameObject ar;
    public GameObject tutorial_panel;

    public void OnGameStartButtonClick() {
        if (ar != null) {
            ar.SetActive(true);
            tutorial_panel.SetActive(false);
        }
    }

    public void OnNextButtonClcik() {
        //������ ���������� �̵�
        SceneManager.LoadScene("final_POSCO");
    }
}
