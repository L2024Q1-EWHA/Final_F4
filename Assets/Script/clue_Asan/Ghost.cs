using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour
{
    public GameObject body;
    public Material[] m;

    public void Attacked()
    {
        StartCoroutine("Attacked_motion");
        transform.Find("Canvas/HPBar/health").GetComponent<Image>().fillAmount -= 0.2f;
        if (transform.Find("Canvas/HPBar/health").GetComponent<Image>().fillAmount < 0.01f)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Attacked_motion()
    {
        body.GetComponent<SkinnedMeshRenderer>().material = m[1];
        yield return new WaitForSeconds(0.3f);
        body.GetComponent<SkinnedMeshRenderer>().material = m[0];
        yield return null;
    }
}
