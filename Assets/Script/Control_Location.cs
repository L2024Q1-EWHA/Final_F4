using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Control_Location : MonoBehaviour
{
    public GameObject ECC;
    public GameObject Posco;
    public GameObject Asan;
    public GameObject ECC_dialogue;
    public GameObject Posco_dialogue;
    public GameObject Asan_dialogue;

    void Start()
    {
        int buttonPressed = PlayerPrefs.GetInt("ButtonPressed");
        
        // 모든 오브젝트를 비활성화합니다.
        ECC.SetActive(false);
        Posco.SetActive(false);
        Asan.SetActive(false);

        // 눌린 버튼에 따라 오브젝트를 활성화합니다.
        switch (buttonPressed)
        {
            case 1:
                ECC.SetActive(true);
                ECC_dialogue.SetActive(true);
                break;
            case 2:
                Posco.SetActive(true);
                Posco_dialogue.SetActive(true);
                break;

            case 3:
                Asan.SetActive(true);
                Asan_dialogue.SetActive(true);
                break;
        }
    }
}
