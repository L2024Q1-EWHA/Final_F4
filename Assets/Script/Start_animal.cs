using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_animal : MonoBehaviour  
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("start", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
