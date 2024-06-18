using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ar;
    public GameObject panel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            print("¼º°ø");
            GetComponent<ParticleSystem>().Play();
            Invoke("activeSuccess", 2f);

        }
    }

    private void activeSuccess() {
        ar.SetActive(false);
        panel.SetActive(true);
    }
}
