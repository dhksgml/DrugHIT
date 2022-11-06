using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { idle = 0, walk_front, walk_back, hb_pose, bb_pose, lb_pose, ha_pose, ba_pose, la_pose, hd_pose, bd_pose, ld_pose, hg_pose, bg_pose, lg_pose, hk_left, hk_right, bk_left, bk_right, lk_left, lk_right, hp_left, hp_right, bp_left, bp_right, win_pose, lose_pose }

public class Player : MonoBehaviour
{
    //�÷��̾� �̵��ӵ�
    public float speed = 10;

    //�÷��̾� �ִ�ü��
    protected float maxHP = 100;
    //�÷��̾� ����ü��
    protected float curHP = 100;
    //�÷��̾� ���� ����
    public State state = State.idle;
    //�÷��̾� ����
    protected int color = 0;
    //�÷��̾� ���ݷ�
    protected int atkPower = 0;

    //�ϴ� �Է� ����
    protected bool isCrouch = false;
    //��� �Է� ����
    protected bool isUpper = false;
    //���� �Է� ����
    public bool isAtk = false;
    //���� �Է� ����
    public bool isBlock = false;

    public Animator animator;


    public bool GetCrouch()
    {
        return isCrouch;
    }

    public void SetCrouch(bool B)
    {
        isCrouch = B;
    }

    public bool GetUpper()
    {
        return isUpper;
    }

    public void SetUpper(bool B)
    {
        isUpper = B;
    }

    public void Idle()
    {
        //Debug.Log("idle..");
        isUpper = false;
        isCrouch = false;
        isBlock = false;
        state = State.idle;

        //�ִϸ��̼�
        //animator.SetBool("walkBack", false);
        //animator.SetBool("walkFront", false);
        //animator.SetBool("idle", true);
    }
    public void WalkBack(int PlayerNum)
    {
        if (!isAtk || !isBlock)
        {
            //Debug.Log("walk_back..");
            state = State.walk_back;
            //�ִϸ��̼�
            animator.SetBool("idle", false);
            animator.SetBool("walkBack", true);

            //�÷��̾�1
            if (PlayerNum == 0)
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
            //�÷��̾�2
            else if(PlayerNum == 1)
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
        }
    }

    public void WalkFront(int PlayerNum)
    {
        if (!isAtk || !isBlock)
        {
            //Debug.Log("walk_front..");

            state = State.walk_front;
            //�ִϸ��̼�
            animator.SetBool("idle", false);
            animator.SetBool("walkFront", true);

            //�÷��̾�1
            if (PlayerNum == 0)
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
            //�÷��̾�2
            else if (PlayerNum == 1)
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
        }
    }
    public void HighPunch()
    {
        //Debug.Log("highPunch..");
        isAtk = true;
        if (state == State.hp_left)
        {
            state = State.hp_right;
            //�ִϸ��̼�
            animator.SetBool("leftAtk", true);
            animator.SetBool("hPunch", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.hp_left;
            //�ִϸ��̼�
            animator.SetBool("hPunch", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
    }

    public void Punch()
    {
        //Debug.Log("Punch..");
        isAtk = true;
        if (state == State.bp_left)
        {
            state = State.bp_right;
            //�ִϸ��̼�
            animator.SetBool("leftAtk", true);
            animator.SetBool("bPunch", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.bp_left;
            //�ִϸ��̼�
            animator.SetBool("bPunch", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
    }

    public void HighBlock()
    {
        //Debug.Log("highBlock..");
        isBlock = true;
        state = State.hb_pose;
        //�ִϸ��̼�
        animator.SetBool("hBlock", true);
        StopAllCoroutines();
        StartCoroutine(DoBlock());
    }
    public void Block()
    {
        //Debug.Log("block..");
        isBlock = true;
        state = State.bb_pose;
        //�ִϸ��̼�
        animator.SetBool("bBlock", true);
        StopAllCoroutines();
        StartCoroutine(DoBlock());

    }
    public void LowBlock()
    {
        //Debug.Log("lowBlock..");
        isBlock = true;
        state = State.lb_pose;
        //�ִϸ��̼�
        animator.SetBool("lBlock", true);
        StopAllCoroutines();
        StartCoroutine(DoBlock());
    }

    public void HighKick()
    {

        //Debug.Log("highKick..");
        isAtk = true;
        if (state == State.hk_left)
        {
            state = State.hk_right;
            //�ִϸ��̼�
            animator.SetBool("leftAtk", true);
            animator.SetBool("hKick", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.hk_left;
            //�ִϸ��̼�
            animator.SetBool("hKick", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
    }
    public void Kick()
    {
        //Debug.Log("kick..");
        isAtk = true;
        if (state == State.bk_left)
        {
            state = State.bk_right;
            //�ִϸ��̼�
            animator.SetBool("leftAtk", true);
            animator.SetBool("bKick", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.bk_left;
            //�ִϸ��̼�
            animator.SetBool("bKick", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
    }
    public void LowKick()
    {
        //Debug.Log("lowKick..");
        isAtk = true;
        if (state == State.lk_left)
        {
            state = State.lk_right;
            //�ִϸ��̼�
            animator.SetBool("leftAtk", true);
            animator.SetBool("lKick", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.lk_left;
            //�ִϸ��̼�
            animator.SetBool("leftAtk", true);
            animator.SetBool("lKick", true);
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
    }


    public void Damaged()
    {

    }

    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(1f);
        isAtk = false;
        this.Idle();
    }

    IEnumerator DoBlock()
    {
        yield return new WaitForSeconds(1f);
        isBlock = false;
        this.Idle();
    }

}
