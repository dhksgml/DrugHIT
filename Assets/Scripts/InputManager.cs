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

        //�ڷ� �̵�
        if ((Input.GetKey(KeyCode.A) && !p1.isAtk) && (Input.GetKey(KeyCode.A) && !p1.isBlock))
        {
            p1.walk_back(0);
        }

        //������ �̵�
        if((Input.GetKey(KeyCode.D) && !p1.isAtk) && (Input.GetKey(KeyCode.D) && !p1.isBlock))
        {
            p1.walk_front(0);
            if (p1.transform.position.x + 0.3f > p2.transform.position.x)
            {
                p1.transform.position = p2.transform.position - new Vector3(0.3f, 0, 0);
            }
        }

        //��� �ָ�
        if (Input.GetKeyDown(KeyCode.G) && !p1.GetCrouch())
        {
            p1.highPunch();
        }

        //�ߴ� ����
        if (Input.GetKeyDown(KeyCode.H) && !p1.GetCrouch())
        {
            p1.block();
        }

        //�ߴ� ������
        if (Input.GetKeyDown(KeyCode.J) && !p1.GetCrouch())
        {
            p1.kick();
        }

        if (Input.GetKey(KeyCode.S))
        {
            //��� ���� ��Ȱ��ȭ, �ϴ� ���� Ȱ��ȭ
            p1.SetUpper(false);
            p1.SetCrouch(true);

            //�ߴ� �ָ�
            if (Input.GetKeyDown(KeyCode.G)) p1.Punch();
            //�ϴ� ����
            if (Input.GetKeyDown(KeyCode.H)) p1.lowBlock();
            //�ϴ� ������
            if (Input.GetKeyDown(KeyCode.J)) p1.lowKick();
        }

        if (Input.GetKey(KeyCode.W))
        {
            //�ϴ� ���� ��Ȱ��ȭ, ��� ���� Ȱ��ȭ
            p1.SetCrouch(false);
            p1.SetUpper(true);

            //��� ����
            if (Input.GetKeyDown(KeyCode.H)) p1.highBlock();
            //��� ������
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

        //�ڷ� �̵�
        if ((Input.GetKey(KeyCode.RightArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.RightArrow) && !p2.isBlock))
        {
            p2.walk_back(1);
        }

        //������ �̵�
        if ((Input.GetKey(KeyCode.LeftArrow) && !p2.isAtk) && (Input.GetKey(KeyCode.LeftArrow) && !p2.isBlock))
        {
            p2.walk_front(1);
            if (p1.transform.position.x >= p2.transform.position.x - 0.3f)
            {
                p2.transform.position = p1.transform.position + new Vector3(0.3f, 0, 0);
            }
        }

        //��� �ָ�
        if (Input.GetKeyDown(KeyCode.Keypad1) && !p2.GetCrouch())
        {
            p2.highPunch();
        }

        //�ߴ� ����
        if (Input.GetKeyDown(KeyCode.Keypad2) && !p2.GetCrouch())
        {
            p2.block();
        }

        //�ߴ� ������
        if (Input.GetKeyDown(KeyCode.Keypad3) && !p2.GetCrouch())
        {
            p2.kick();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //��� ���� ��Ȱ��ȭ, �ϴ� ���� Ȱ��ȭ
            p2.SetUpper(false);
            p2.SetCrouch(true);

            //�ߴ� �ָ�
            if (Input.GetKeyDown(KeyCode.Keypad1)) p2.Punch();
            //�ϴ� ����
            if (Input.GetKeyDown(KeyCode.Keypad2)) p2.lowBlock();
            //�ϴ� ������
            if (Input.GetKeyDown(KeyCode.Keypad3)) p2.lowKick();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //�ϴ� ���� ��Ȱ��ȭ, ��� ���� Ȱ��ȭ
            p2.SetCrouch(false);
            p2.SetUpper(true);

            //��� ����
            if (Input.GetKeyDown(KeyCode.Keypad2)) p2.highBlock();
            //��� ������
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
