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

    ////1p ���� Ȯ�ο� UI
    //[SerializeField]
    //private Text p1_text_UI;

    ////2p ���� Ȯ�ο� UI
    //[SerializeField]
    //private Text p2_text_UI;

    //1p Ű Ȯ�ο� UI
    [SerializeField]
    private GameObject p1_press_UI;

    //2p Ű Ȯ�ο� UI
    [SerializeField]
    private GameObject p2_press_UI;

    //�� �̵����� ����
    private Vector3 minPos;
    private Vector3 maxPos;

    private RoundManager roundManager;

    private void Start()
    {
        minPos = new Vector3(-5,0,0);
        maxPos = new Vector3(5, 0, 0);
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
    }

    void Update()
    {
        //p1_text_UI.text = "1P ���� : " + p1.state;
        //p2_text_UI.text = "2P ���� : " + p2.state;

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

        if(!roundManager.isPause)
        if (!p1.isDie && !(p1.state == State.hd_pose || p1.state == State.bd_pose || p1.state == State.ld_pose || p1.state == State.win_pose))
        {

            //�ڷ� �̵�
            if ((Input.GetKey(KeyCode.A) && !p1.isAtk) && (Input.GetKey(KeyCode.A) && !p1.isBlock))
            {
                //Debug.Log("AŰ ����");
                p1.WalkBack(0);
                if (p1.transform.position.x - 1.0f < minPos.x)
                {
                    p1.transform.position = minPos + new Vector3(1.0f, 0, 0);
                }
            }

            //������ �̵�
            if ((Input.GetKey(KeyCode.D) && !p1.isAtk) && (Input.GetKey(KeyCode.D) && !p1.isBlock))
            {
                //Debug.Log("DŰ ����");
                p1.WalkFront(0);
                if (p1.transform.position.x + 1.0f > p2.transform.position.x)
                {
                    p1.transform.position = p2.transform.position - new Vector3(1.0f, 0, 0);
                }
            }

            
            //��� �ָ�
            if (Input.GetKeyDown(KeyCode.G) && !p1.GetCrouch() && !p1.isBlock)
            {
                //Debug.Log("GŰ ����");
                if (p1.animator.GetCurrentAnimatorStateInfo(0).IsName("hp_straight_A") && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f)
                {
                    p1.HighPunch(1);
                }
                else
                {
                    p1.HighPunch(0);
                }
            }

            //�ߴ� ����
            if (Input.GetKeyDown(KeyCode.H) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock && !p1.isAtk)
            {
                //Debug.Log("HŰ ����");
                p1.Block();
            }

            //�ߴ� ������
            //if (Input.GetKeyDown(KeyCode.J) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock)
            if (Input.GetKeyDown(KeyCode.J) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock)
            {
                //Debug.Log("JŰ ����");
                if (p1.animator.GetCurrentAnimatorStateInfo(0).IsName("bk_push_left_A") && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f)
                {
                    p1.Kick(1);
                }
                else
                {
                    p1.Kick(0);
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log("�Ʒ�Ű ����");
                //��� ���� ��Ȱ��ȭ, �ϴ� ���� Ȱ��ȭ
                p1.SetUpper(false);
                p1.SetCrouch(true);

                //�ߴ� �ָ�
                if (Input.GetKeyDown(KeyCode.G) && !p1.isBlock)
                {
                    //Debug.Log("GŰ ����");

                    if (p1.animator.GetCurrentAnimatorStateInfo(0).IsName("bp_upper_left_A") && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f)
                    {
                        p1.Punch(1);
                    }
                    else
                    {
                        p1.Punch(0);
                    }
                }
                //�ϴ� ����
                if (Input.GetKeyDown(KeyCode.H) && !p1.isBlock && !p1.isAtk)
                {
                    //Debug.Log("HŰ ����");
                    p1.LowBlock();
                }
                //�ϴ� ������
                if (Input.GetKeyDown(KeyCode.J) && !p1.isBlock)
                {
                    //Debug.Log("JŰ ����");
                    if (p1.animator.GetCurrentAnimatorStateInfo(0).IsName("lk_rh_left_A") && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.1f)
                    {
                        p1.LowKick(1);
                    }
                    else
                    {
                        p1.LowKick(0);
                    }
                }
            }

            if (Input.GetKey(KeyCode.W))
            {
                //Debug.Log("��Ű ����");
                //�ϴ� ���� ��Ȱ��ȭ, ��� ���� Ȱ��ȭ

                p1.SetUpper(true);
                p1.SetCrouch(false);

                //��� ������
                if (Input.GetKeyDown(KeyCode.J) && !p1.isBlock)
                {
                    //Debug.Log("JŰ ����");

                    if (p1.animator.GetCurrentAnimatorStateInfo(0).IsName("hk_side_left_A") && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8f && p1.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f)
                    {
                        p1.HighKick(1);
                    }
                    else
                    {
                        p1.HighKick(0);
                    }
                }
                //��� ����
                if (Input.GetKeyDown(KeyCode.H) && !p1.isBlock && !p1.isAtk)
                {
                    //Debug.Log("HŰ ����");
                    p1.HighBlock();
                }

            }

            if (Input.GetKeyUp(KeyCode.W) && p1.state != State.Counter)
            {
                p1.SetUpper(false);
            }
            if (Input.GetKeyUp(KeyCode.S) && p1.state != State.Counter)
            {
                p1.SetCrouch(false);
            }

            if ((Input.GetKeyUp(KeyCode.A) && !p1.isAtk && !p1.isBlock) || (Input.GetKeyUp(KeyCode.D) && !p1.isAtk && !p1.isBlock) || (Input.GetKeyUp(KeyCode.H) && !p1.isAtk && !p1.isBlock) && p1.state != State.Counter)
            {
                p1.Idle();
            }


            if (Input.GetKeyUp(KeyCode.S) && p1.state != State.Counter)
            {
                p1.SetCrouch(false);
                p1.SetUpper(false);
            }
        }

        #endregion

        #region �÷��̾�2 ����

        if(!roundManager.isPause)
        if (!p2.isDie && !(p2.state == State.hd_pose || p2.state == State.bd_pose || p2.state == State.ld_pose || p2.state == State.win_pose))
        {

            //�ڷ� �̵�
            if ((Input.GetKey(KeyCode.RightArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.RightArrow) && !p2.isBlock))
            {
                //Debug.Log("���� Ű ����");
                p2.WalkBack(1);
                if (p2.transform.position.x + 1.0f > maxPos.x)
                {
                    p2.transform.position = maxPos - new Vector3(1.0f, 0, 0);
                }
            }

            //������ �̵�
            if ((Input.GetKey(KeyCode.LeftArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.LeftArrow) && !p2.isBlock))
            {
                //Debug.Log("������ Ű ����");
                p2.WalkFront(1);
                if (p2.transform.position.x < p1.transform.position.x + 1.0f)
                {
                    p2.transform.position = p1.transform.position + new Vector3(1.0f, 0, 0);
                }
            }

            //��� �ָ�
            if (Input.GetKeyDown(KeyCode.Keypad1) && !p2.GetCrouch() && !p2.isBlock)
            {
                //Debug.Log("����1Ű ����");
                if (p2.animator.GetCurrentAnimatorStateInfo(0).IsName("hp_straight_A") && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f)
                {
                    p2.HighPunch(1);
                }
                else
                {
                    p2.HighPunch(0);
                }
            }

            //�ߴ� ����
            if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.GetCrouch() && !p2.GetUpper() && !p2.isBlock && !p2.isAtk)
            {
                //Debug.Log("����2Ű ����");
                p2.Block();
            }

            //�ߴ� ������
            if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.GetCrouch() && !p2.GetUpper() && !p2.isBlock)
            {
                //Debug.Log("����3Ű ����");
                if (p2.animator.GetCurrentAnimatorStateInfo(0).IsName("bk_push_left_A") && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f)
                {
                    p2.Kick(1);
                }
                else
                {
                    p2.Kick(0);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("�Ʒ�Ű ����");
                //��� ���� ��Ȱ��ȭ, �ϴ� ���� Ȱ��ȭ
                p2.SetUpper(false);
                p2.SetCrouch(true);

                //�ߴ� �ָ�
                if (Input.GetKeyDown(KeyCode.Keypad1) && !p2.isBlock)
                {
                    //Debug.Log("����1Ű ����");
                    if (p2.animator.GetCurrentAnimatorStateInfo(0).IsName("bp_upper_left_A") && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f)
                    {
                        p2.Punch(1);
                    }
                    else
                    {
                        p2.Punch(0);
                    }
                }
                //�ϴ� ����
                if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.isBlock && !p2.isAtk)
                {
                    //Debug.Log("����2Ű ����");
                    p2.LowBlock();
                }
                //�ϴ� ������
                if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.isBlock)
                {
                    //Debug.Log("����3Ű ����");
                    if (p2.animator.GetCurrentAnimatorStateInfo(0).IsName("lk_rh_left_A") && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.7f && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.1f)
                    {
                        p2.LowKick(1);
                    }
                    else
                    {
                        p2.LowKick(0);
                    }
                }
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Debug.Log("��Ű ����");
                //�ϴ� ���� ��Ȱ��ȭ, ��� ���� Ȱ��ȭ

                p2.SetUpper(true);
                p2.SetCrouch(false);

                //��� ������
                if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.isBlock)
                {
                    //Debug.Log("����3Ű ����");
                    if (p2.animator.GetCurrentAnimatorStateInfo(0).IsName("hk_side_left_A") && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8f && p2.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f)
                    {
                        p2.HighKick(1);
                    }
                    else
                    {
                        p2.HighKick(0);
                    }
                }
                //��� ����
                if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.isBlock && !p2.isAtk)
                {
                    //Debug.Log("����2Ű ����");
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
        }

        
        #endregion

        
        }
    }
