using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class worryscene_button : MonoBehaviour
{
    public GameObject map;
    public GameObject ecc, posco, asan;
    public GameObject q1, q2, q3;

    public void OnMapButtonClick() {
        map.SetActive(true);

        if (ecc.activeSelf) {
            q1.SetActive(false);
        }
        if (posco.activeSelf) {
            q2.SetActive(false);
        }
        if (asan.activeSelf) {
            q3.SetActive(false);
        }
    }

    public void OnMapXButtonClick() {
        map.SetActive(false);
        if (ecc.activeSelf)
        {
            q1.SetActive(true);
        }
        if (posco.activeSelf)
        {
            q2.SetActive(true);
        }
        if (asan.activeSelf)
        {
            q3.SetActive(true);
        }
    }
}
