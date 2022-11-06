using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { idle = 0, walk_front, walk_back, hb_pose, bb_pose, lb_pose, ha_pose, ba_pose, la_pose, hd_pose, bd_pose, ld_pose, hg_pose, bg_pose, lg_pose, hk_left, hk_right, bk_left, bk_right, lk_left, lk_right, hp_left, hp_right, bp_left, bp_right, win_pose, lose_pose }

public class Player : MonoBehaviour
{
    //플레이어 이동속도
    public float speed = 10;

    //플레이어 최대체력
    protected float maxHP = 100;
    //플레이어 현재체력
    protected float curHP = 100;
    //플레이어 현재 상태
    public State state = State.idle;
    //플레이어 색상
    protected int color = 0;
    //플레이어 공격력
    protected int atkPower = 0;

    //하단 입력 여부
    protected bool isCrouch = false;
    //상단 입력 여부
    protected bool isUpper = false;
    //공격 입력 여부
    public bool isAtk = false;
    //막기 입력 여부
    public bool isBlock = false;

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
    }
    public void WalkBack(int PlayerNum)
    {
        if (!isAtk || !isBlock)
        {
            //Debug.Log("walk_back..");
            state = State.walk_back;
            
            //플레이어1
            if(PlayerNum == 0)
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
            //플레이어2
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

            //플레이어1
            if (PlayerNum == 0)
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
            //플레이어2
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
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.hp_left;
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
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.bp_left;
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
    }

    public void HighBlock()
    {
        //Debug.Log("highBlock..");
        state = State.hb_pose;
        isBlock = true;
        StopAllCoroutines();
        StartCoroutine(DoBlock());
    }
    public void Block()
    {
        //Debug.Log("block..");
        state = State.bb_pose;
        isBlock = true;
        StopAllCoroutines();
        StartCoroutine(DoBlock());

    }
    public void LowBlock()
    {
        //Debug.Log("lowBlock..");
        state = State.lb_pose;
        isBlock = true;
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
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.hk_left;
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
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.bk_left;
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
            StopAllCoroutines();
            StartCoroutine(DoAttack());
        }
        else
        {
            state = State.lk_left;
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
