using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Player1 p1;

    [SerializeField]
    private Player2 p2;

    //1p ���� Ȯ�ο� UI
    [SerializeField]
    private Text p1_text_UI;

    //2p ���� Ȯ�ο� UI
    [SerializeField]
    private Text p2_text_UI;

    //1p Ű Ȯ�ο� UI
    [SerializeField]
    private GameObject p1_press_UI;

    //2p Ű Ȯ�ο� UI
    [SerializeField]
    private GameObject p2_press_UI;


    void Update()
    {
        p1_text_UI.text = "1P ���� : " + p1.state;
        p2_text_UI.text = "2P ���� : " + p2.state;

        #region ���� ����Ű UI
        if (Input.GetKey(KeyCode.A)) { p1_press_UI.transform.GetChild(0).gameObject.SetActive(false); } else { p1_press_UI.transform.GetChild(0).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.S)) { p1_press_UI.transform.GetChild(1).gameObject.SetActive(false); } else { p1_press_UI.transform.GetChild(1).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.W)) { p1_press_UI.transform.GetChild(2).gameObject.SetActive(false); } else { p1_press_UI.transform.GetChild(2).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.D)) { p1_press_UI.transform.GetChild(3).gameObject.SetActive(false); } else { p1_press_UI.transform.GetChild(3).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.G)) { p1_press_UI.transform.GetChild(4).gameObject.SetActive(false); } else { p1_press_UI.transform.GetChild(4).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.H)) { p1_press_UI.transform.GetChild(5).gameObject.SetActive(false); } else { p1_press_UI.transform.GetChild(5).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.J)) { p1_press_UI.transform.GetChild(6).gameObject.SetActive(false); } else { p1_press_UI.transform.GetChild(6).gameObject.SetActive(true); }

        if (Input.GetKey(KeyCode.LeftArrow)) { p2_press_UI.transform.GetChild(0).gameObject.SetActive(false); } else { p2_press_UI.transform.GetChild(0).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.DownArrow)) { p2_press_UI.transform.GetChild(1).gameObject.SetActive(false); } else { p2_press_UI.transform.GetChild(1).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.UpArrow)) { p2_press_UI.transform.GetChild(2).gameObject.SetActive(false); } else { p2_press_UI.transform.GetChild(2).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.RightArrow)) { p2_press_UI.transform.GetChild(3).gameObject.SetActive(false); } else { p2_press_UI.transform.GetChild(3).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.Keypad1)) { p2_press_UI.transform.GetChild(4).gameObject.SetActive(false); } else { p2_press_UI.transform.GetChild(4).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.Keypad2)) { p2_press_UI.transform.GetChild(5).gameObject.SetActive(false); } else { p2_press_UI.transform.GetChild(5).gameObject.SetActive(true); }
        if (Input.GetKey(KeyCode.Keypad3)) { p2_press_UI.transform.GetChild(6).gameObject.SetActive(false); } else { p2_press_UI.transform.GetChild(6).gameObject.SetActive(true); }
        #endregion


        #region �÷��̾�1 ����
        //�ڷ� �̵�
        if ((Input.GetKey(KeyCode.A) && !p1.isAtk) && (Input.GetKey(KeyCode.A) && !p1.isBlock))
        {
            Debug.Log("AŰ ����");
            p1.WalkBack(0);
        }

        //������ �̵�
        if((Input.GetKey(KeyCode.D) && !p1.isAtk) && (Input.GetKey(KeyCode.D) && !p1.isBlock))
        {
            Debug.Log("DŰ ����");
            p1.WalkFront(0);
            if (p1.transform.position.x + 0.3f > p2.transform.position.x)
            {
                p1.transform.position = p2.transform.position - new Vector3(0.3f, 0, 0);
            }
        }

        //��� �ָ�
        if (Input.GetKeyDown(KeyCode.G) && !p1.GetCrouch() && !p1.isBlock)
        {
            Debug.Log("GŰ ����");
            p1.HighPunch();
        }

        Debug.Log("p1.isBlock : " + !p1.isBlock);
        Debug.Log("p1.isAtk : " + !p1.isAtk);

        //�ߴ� ����
        if (Input.GetKeyDown(KeyCode.H) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock && !p1.isAtk)
        {
            Debug.Log("HŰ ����");
            p1.Block();
        }

        //�ߴ� ������
        //if (Input.GetKeyDown(KeyCode.J) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock)
        if (Input.GetKeyDown(KeyCode.J) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock)
        {
            Debug.Log("JŰ ����");
            p1.Kick();
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("�Ʒ�Ű ����");
            //��� ���� ��Ȱ��ȭ, �ϴ� ���� Ȱ��ȭ
            p1.SetUpper(false);
            p1.SetCrouch(true);

            //�ߴ� �ָ�
            if (Input.GetKeyDown(KeyCode.G) && !p1.isBlock)
            {
                Debug.Log("GŰ ����");
                p1.Punch();
            }
            //�ϴ� ����
            if (Input.GetKeyDown(KeyCode.H) && !p1.isBlock && !p1.isAtk)
            {
                Debug.Log("HŰ ����");
                p1.LowBlock();
            }
            //�ϴ� ������
            if (Input.GetKeyDown(KeyCode.J) && !p1.isBlock)
            {
                Debug.Log("JŰ ����");
                p1.LowKick();
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("��Ű ����");
            //�ϴ� ���� ��Ȱ��ȭ, ��� ���� Ȱ��ȭ
            
            p1.SetUpper(true);
            p1.SetCrouch(false);

            //��� ������
            if (Input.GetKeyDown(KeyCode.J) && !p1.isBlock)
            {
                Debug.Log("JŰ ����");
                p1.HighKick();
            }
            //��� ����
            if (Input.GetKeyDown(KeyCode.H) && !p1.isBlock && !p1.isAtk)
            {
                Debug.Log("HŰ ����");
                p1.HighBlock();
            }
            
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            p1.SetUpper(false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            p1.SetCrouch(false);
        }

        if ((Input.GetKeyUp(KeyCode.A) && !p1.isAtk && !p1.isBlock) || (Input.GetKeyUp(KeyCode.D) && !p1.isAtk && !p1.isBlock) || (Input.GetKeyUp(KeyCode.H) && !p1.isAtk  && !p1.isBlock))
        {
            p1.Idle();
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            p1.SetCrouch(false);
            p1.SetUpper(false);
        }

        #endregion

        #region �÷��̾�2 ����
        //�ڷ� �̵�
        if ((Input.GetKey(KeyCode.RightArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.RightArrow) && !p2.isBlock))
        {
            Debug.Log("���� Ű ����");
            p2.WalkBack(1);
        }

        //������ �̵�
        if ((Input.GetKey(KeyCode.LeftArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.LeftArrow) && !p2.isBlock))
        {
            Debug.Log("������ Ű ����");
            p2.WalkFront(1);
            if (p2.transform.position.x < p1.transform.position.x + 0.3f)
            {
                p2.transform.position = p1.transform.position + new Vector3(0.3f, 0, 0);
            }
        }

        //��� �ָ�
        if (Input.GetKeyDown(KeyCode.Keypad1) && !p2.GetCrouch() && !p2.isBlock)
        {
            Debug.Log("����1Ű ����");
            p2.HighPunch();
        }

        Debug.Log("p2.isBlock : " + !p2.isBlock);
        Debug.Log("p2.isAtk : " + !p2.isAtk);

        //�ߴ� ����
        if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.GetCrouch() && !p2.GetUpper() && !p2.isBlock && !p2.isAtk)
        {
            Debug.Log("����2Ű ����");
            p2.Block();
        }

        //�ߴ� ������
        if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.GetCrouch() && !p2.GetUpper() && !p2.isBlock)
        {
            Debug.Log("����3Ű ����");
            p2.Kick();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("�Ʒ�Ű ����");
            //��� ���� ��Ȱ��ȭ, �ϴ� ���� Ȱ��ȭ
            p2.SetUpper(false);
            p2.SetCrouch(true);

            //�ߴ� �ָ�
            if (Input.GetKeyDown(KeyCode.Keypad1) && !p2.isBlock)
            {
                Debug.Log("����1Ű ����");
                p2.Punch();
            }
            //�ϴ� ����
            if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.isBlock && !p2.isAtk)
            {
                Debug.Log("����2Ű ����");
                p2.LowBlock();
            }
            //�ϴ� ������
            if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.isBlock)
            {
                Debug.Log("����3Ű ����");
                p2.LowKick();
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("��Ű ����");
            //�ϴ� ���� ��Ȱ��ȭ, ��� ���� Ȱ��ȭ

            p2.SetUpper(true);
            p2.SetCrouch(false);

            //��� ������
            if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.isBlock)
            {
                Debug.Log("����3Ű ����");
                p2.HighKick();
            }
            //��� ����
            if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.isBlock && !p2.isAtk)
            {
                Debug.Log("����2Ű ����");
                p2.HighBlock();
            }

        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            p2.SetUpper(false);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            p2.SetCrouch(false);
        }

        if ((Input.GetKeyUp(KeyCode.LeftArrow) && !p2.isAtk && !p2.isBlock) || (Input.GetKeyUp(KeyCode.RightArrow) && !p2.isAtk && !p2.isBlock) || (Input.GetKeyUp(KeyCode.Keypad2) && !p2.isAtk && !p2.isBlock))
        {
            p2.Idle();
        }


        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            p2.SetCrouch(false);
            p2.SetUpper(false);
        }
        #endregion

        
        }
    }
