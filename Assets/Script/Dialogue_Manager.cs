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
    //SerializeField : inspectorâ���� ���� ������ �� �ֵ��� �ϴ� ������.

    [SerializeField] private GameObject question;
    [SerializeField] private GameObject location;
    [SerializeField] private GameObject nameBar;
    [SerializeField] private GameObject dialogueBar;
    [SerializeField] private TMP_Text txt_name;
    [SerializeField] private TMP_Text txt_Dialogue; // �ؽ�Ʈ�� �����ϱ� ���� ����

    private bool isDialogue = false; //��ȭ�� ���������� �˷��� ����
    private int count = 0; //��簡 �󸶳� ����ƴ��� �˷��� ����

    [SerializeField] private Dialogue[] dialogue;


    public void ShowDialogue()
    {
        question.SetActive(false);
        ONOFF(true); //��ȭ�� ���۵�
        count = 0;
        NextDialogue(); //ȣ����ڸ��� ��簡 ����� �� �ֵ��� 
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
            //ù��° ���� ù��° cg���� ��� ���� cg�� ����Ǹ鼭 ȭ�鿡 ���̰� �ȴ�. 
            txt_Dialogue.text = dialogue[count].dialogue;
            count++; //���� ���� cg�� �������� 
            print(count);
   
    }


    // Update is called once per frame
    void Update()
    {

        //ȭ���� Ŭ���� ������ ��簡 ����ǵ���. 
        if (isDialogue) //Ȱ��ȭ�� �Ǿ��� ���� ��簡 ����ǵ���
        {
            if (Input.GetMouseButtonDown(0))
            {
                //��ȭ�� ���� �˾ƾ���.
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
