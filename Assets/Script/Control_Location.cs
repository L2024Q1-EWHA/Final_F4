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
        
        // ��� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
        ECC.SetActive(false);
        Posco.SetActive(false);
        Asan.SetActive(false);

        // ���� ��ư�� ���� ������Ʈ�� Ȱ��ȭ�մϴ�.
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
