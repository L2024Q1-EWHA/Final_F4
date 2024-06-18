using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;

[System.Serializable]
public class Dialogue {
    
    public string name;
    [TextArea]
    public string dialogue;
}

public class Dialogue_Manager : MonoBehaviour
{
    //SerializeField : inspector창에서 직접 접근할 수 있도록 하는 변수임.

    [SerializeField] private GameObject question;
    [SerializeField] private GameObject location;
    [SerializeField] private GameObject nameBar;
    [SerializeField] private GameObject dialogueBar;
    [SerializeField] private TMP_Text txt_name;
    [SerializeField] private TMP_Text txt_Dialogue; // 텍스트를 제어하기 위한 변수

    private bool isDialogue = false; //대화가 진행중인지 알려줄 변수
    private int count = 0; //대사가 얼마나 진행됐는지 알려줄 변수

    [SerializeField] private Dialogue[] dialogue;


    public void ShowDialogue()
    {
        question.SetActive(false);
        ONOFF(true); //대화가 시작됨
        count = 0;
        NextDialogue(); //호출되자마자 대사가 진행될 수 있도록 
    }

    private void ONOFF(bool _flag)
    {
        nameBar.SetActive(_flag);
        dialogueBar.SetActive(_flag);

        txt_name.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
            txt_name.text = dialogue[count].name;
            //첫번째 대사와 첫번째 cg부터 계속 다음 cg로 진행되면서 화면에 보이게 된다. 
            txt_Dialogue.text = dialogue[count].dialogue;
            count++; //다음 대사와 cg가 나오도록 
            print(count);
   
    }


    // Update is called once per frame
    void Update()
    {

        //화면을 클릭할 때마다 대사가 진행되도록. 
        if (isDialogue) //활성화가 되었을 때만 대사가 진행되도록
        {
            if (Input.GetMouseButtonDown(0))
            {
                //대화의 끝을 알아야함.
                if (count < dialogue.Length) NextDialogue();
                else
                {
                    isDialogue = false;
                    print("false");
                    ONOFF(false);
                    question.SetActive(true);
                }
            }
        }

    }
}
