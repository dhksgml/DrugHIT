using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Player1 p1;

    [SerializeField]
    private Player2 p2;
    void Update()
    {
        Debug.Log(p1.state);

        //뒤로 이동
        if ((Input.GetKey(KeyCode.A) && !p1.isAtk) && (Input.GetKey(KeyCode.A) && !p1.isBlock))
        {
            p1.walk_back(0);
        }

        //앞으로 이동
        if((Input.GetKey(KeyCode.D) && !p1.isAtk) && (Input.GetKey(KeyCode.D) && !p1.isBlock))
        {
            p1.walk_front(0);
            if (p1.transform.position.x + 0.3f > p2.transform.position.x)
            {
                p1.transform.position = p2.transform.position - new Vector3(0.3f, 0, 0);
            }
        }

        //상단 주먹
        if (Input.GetKeyDown(KeyCode.G) && !p1.GetCrouch())
        {
            p1.highPunch();
        }

        //중단 막기
        if (Input.GetKeyDown(KeyCode.H) && !p1.GetCrouch())
        {
            p1.block();
        }

        //중단 발차기
        if (Input.GetKeyDown(KeyCode.J) && !p1.GetCrouch())
        {
            p1.kick();
        }

        if (Input.GetKey(KeyCode.S))
        {
            //상단 상태 비활성화, 하단 상태 활성화
            p1.SetUpper(false);
            p1.SetCrouch(true);

            //중단 주먹
            if (Input.GetKeyDown(KeyCode.G)) p1.Punch();
            //하단 막기
            if (Input.GetKeyDown(KeyCode.H)) p1.lowBlock();
            //하단 발차기
            if (Input.GetKeyDown(KeyCode.J)) p1.lowKick();
        }

        if (Input.GetKey(KeyCode.W))
        {
            //하단 상태 비활성화, 상단 상태 활성화
            p1.SetCrouch(false);
            p1.SetUpper(true);

            //상단 막기
            if (Input.GetKeyDown(KeyCode.H)) p1.highBlock();
            //상단 발차기
            if (Input.GetKeyDown(KeyCode.J)) p1.lowKick();
        }
        
        if ((Input.GetKeyUp(KeyCode.A) && !p1.isAtk && !p1.isBlock) || (Input.GetKeyUp(KeyCode.D) && !p1.isAtk && !p1.isBlock) || (Input.GetKeyUp(KeyCode.H) && !p1.isBlock))
        {
            p1.idle();
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            p1.SetCrouch(false);
            p1.SetUpper(false);
        }

        //뒤로 이동
        if ((Input.GetKey(KeyCode.RightArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.RightArrow) && !p2.isBlock))
        {
            p2.walk_back(1);
        }

        //앞으로 이동
        if ((Input.GetKey(KeyCode.LeftArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.LeftArrow) && !p2.isBlock))
        {
            p2.walk_front(1);
            if (p1.transform.position.x >= p2.transform.position.x - 0.3f)
            {
                p2.transform.position = p1.transform.position + new Vector3(0.3f, 0, 0);
            }
        }

        //상단 주먹
        if (Input.GetKeyDown(KeyCode.Keypad1) && !p2.GetCrouch())
        {
            p2.highPunch();
        }

        //중단 막기
        if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.GetCrouch())
        {
            p2.block();
        }

        //중단 발차기
        if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.GetCrouch())
        {
            p2.kick();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //상단 상태 비활성화, 하단 상태 활성화
            p2.SetUpper(false);
            p2.SetCrouch(true);

            //중단 주먹
            if (Input.GetKeyDown(KeyCode.Keypad1)) p2.Punch();
            //하단 막기
            if (Input.GetKeyDown(KeyCode.Keypad2)) p2.lowBlock();
            //하단 발차기
            if (Input.GetKeyDown(KeyCode.Keypad3)) p2.lowKick();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //하단 상태 비활성화, 상단 상태 활성화
            p2.SetCrouch(false);
            p2.SetUpper(true);

            //상단 막기
            if (Input.GetKeyDown(KeyCode.Keypad2)) p2.highBlock();
            //상단 발차기
            if (Input.GetKeyDown(KeyCode.Keypad3)) p2.lowKick();
        }

        if ((Input.GetKeyUp(KeyCode.LeftArrow) && !p2.isAtk && !p2.isBlock) || (Input.GetKeyUp(KeyCode.RightArrow) && !p2.isAtk && !p2.isBlock) || (Input.GetKeyUp(KeyCode.Keypad2) && !p2.isBlock))
        {
            p2.idle();
        }


        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            p2.SetCrouch(false);
            p2.SetUpper(false);
        }
    }
}
