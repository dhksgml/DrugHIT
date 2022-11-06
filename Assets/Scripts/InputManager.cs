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

    //1p 상태 확인용 UI
    [SerializeField]
    private Text p1_text_UI;

    //2p 상태 확인용 UI
    [SerializeField]
    private Text p2_text_UI;

    //1p 키 확인용 UI
    [SerializeField]
    private GameObject p1_press_UI;

    //2p 키 확인용 UI
    [SerializeField]
    private GameObject p2_press_UI;


    void Update()
    {
        p1_text_UI.text = "1P 상태 : " + p1.state;
        p2_text_UI.text = "2P 상태 : " + p2.state;

        #region 누른 조작키 UI
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


        #region 플레이어1 조작
        //뒤로 이동
        if ((Input.GetKey(KeyCode.A) && !p1.isAtk) && (Input.GetKey(KeyCode.A) && !p1.isBlock))
        {
            Debug.Log("A키 눌림");
            p1.WalkBack(0);
        }

        //앞으로 이동
        if((Input.GetKey(KeyCode.D) && !p1.isAtk) && (Input.GetKey(KeyCode.D) && !p1.isBlock))
        {
            Debug.Log("D키 눌림");
            p1.WalkFront(0);
            if (p1.transform.position.x + 0.3f > p2.transform.position.x)
            {
                p1.transform.position = p2.transform.position - new Vector3(0.3f, 0, 0);
            }
        }

        //상단 주먹
        if (Input.GetKeyDown(KeyCode.G) && !p1.GetCrouch() && !p1.isBlock)
        {
            Debug.Log("G키 눌림");
            p1.HighPunch();
        }

        Debug.Log("p1.isBlock : " + !p1.isBlock);
        Debug.Log("p1.isAtk : " + !p1.isAtk);

        //중단 막기
        if (Input.GetKeyDown(KeyCode.H) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock && !p1.isAtk)
        {
            Debug.Log("H키 눌림");
            p1.Block();
        }

        //중단 발차기
        //if (Input.GetKeyDown(KeyCode.J) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock)
        if (Input.GetKeyDown(KeyCode.J) && !p1.GetCrouch() && !p1.GetUpper() && !p1.isBlock)
        {
            Debug.Log("J키 눌림");
            p1.Kick();
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("아래키 눌림");
            //상단 상태 비활성화, 하단 상태 활성화
            p1.SetUpper(false);
            p1.SetCrouch(true);

            //중단 주먹
            if (Input.GetKeyDown(KeyCode.G) && !p1.isBlock)
            {
                Debug.Log("G키 눌림");
                p1.Punch();
            }
            //하단 막기
            if (Input.GetKeyDown(KeyCode.H) && !p1.isBlock && !p1.isAtk)
            {
                Debug.Log("H키 눌림");
                p1.LowBlock();
            }
            //하단 발차기
            if (Input.GetKeyDown(KeyCode.J) && !p1.isBlock)
            {
                Debug.Log("J키 눌림");
                p1.LowKick();
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("위키 눌림");
            //하단 상태 비활성화, 상단 상태 활성화
            
            p1.SetUpper(true);
            p1.SetCrouch(false);

            //상단 발차기
            if (Input.GetKeyDown(KeyCode.J) && !p1.isBlock)
            {
                Debug.Log("J키 눌림");
                p1.HighKick();
            }
            //상단 막기
            if (Input.GetKeyDown(KeyCode.H) && !p1.isBlock && !p1.isAtk)
            {
                Debug.Log("H키 눌림");
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

        #region 플레이어2 조작
        //뒤로 이동
        if ((Input.GetKey(KeyCode.RightArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.RightArrow) && !p2.isBlock))
        {
            Debug.Log("왼쪽 키 눌림");
            p2.WalkBack(1);
        }

        //앞으로 이동
        if ((Input.GetKey(KeyCode.LeftArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.LeftArrow) && !p2.isBlock))
        {
            Debug.Log("오른쪽 키 눌림");
            p2.WalkFront(1);
            if (p2.transform.position.x < p1.transform.position.x + 0.3f)
            {
                p2.transform.position = p1.transform.position + new Vector3(0.3f, 0, 0);
            }
        }

        //상단 주먹
        if (Input.GetKeyDown(KeyCode.Keypad1) && !p2.GetCrouch() && !p2.isBlock)
        {
            Debug.Log("숫자1키 눌림");
            p2.HighPunch();
        }

        Debug.Log("p2.isBlock : " + !p2.isBlock);
        Debug.Log("p2.isAtk : " + !p2.isAtk);

        //중단 막기
        if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.GetCrouch() && !p2.GetUpper() && !p2.isBlock && !p2.isAtk)
        {
            Debug.Log("숫자2키 눌림");
            p2.Block();
        }

        //중단 발차기
        if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.GetCrouch() && !p2.GetUpper() && !p2.isBlock)
        {
            Debug.Log("숫자3키 눌림");
            p2.Kick();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("아래키 눌림");
            //상단 상태 비활성화, 하단 상태 활성화
            p2.SetUpper(false);
            p2.SetCrouch(true);

            //중단 주먹
            if (Input.GetKeyDown(KeyCode.Keypad1) && !p2.isBlock)
            {
                Debug.Log("숫자1키 눌림");
                p2.Punch();
            }
            //하단 막기
            if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.isBlock && !p2.isAtk)
            {
                Debug.Log("숫자2키 눌림");
                p2.LowBlock();
            }
            //하단 발차기
            if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.isBlock)
            {
                Debug.Log("숫자3키 눌림");
                p2.LowKick();
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("위키 눌림");
            //하단 상태 비활성화, 상단 상태 활성화

            p2.SetUpper(true);
            p2.SetCrouch(false);

            //상단 발차기
            if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.isBlock)
            {
                Debug.Log("숫자3키 눌림");
                p2.HighKick();
            }
            //상단 막기
            if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.isBlock && !p2.isAtk)
            {
                Debug.Log("숫자2키 눌림");
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
