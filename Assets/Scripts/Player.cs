using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { idle = 0, walk_front, walk_back, hb_pose, bb_pose, lb_pose, ha_pose, ba_pose, la_pose, hd_pose, bd_pose, ld_pose, hg_pose, bg_pose, lg_pose, hk_left, hk_right, bk_left, bk_right, lk_left, lk_right, hp_left, hp_right, bp_left, bp_right, Counter,win_pose, lose_pose }

public class Player : MonoBehaviour
{
    //플레이어 이동속도
    public float speed = 10;

    //플레이어 최대체력
    public float maxHP = 100;
    //플레이어 현재체력
    public float curHP = 100;
    //플레이어 현재 상태
    public State state = State.idle;
    //플레이어 색상
    protected int color = 0;
    //플레이어 공격력
    public int atkPower = 0;

    //하단 입력 여부
    public bool isCrouch = false;
    //상단 입력 여부
    public bool isUpper = false;
    //공격 입력 여부
    public bool isAtk = false;
    //막기 입력 여부
    public bool isBlock = false;

    public Animator animator;

    private AudioSource audioSource;
    public AudioClip[] audioClips;

    private BoxCollider head;
    private BoxCollider body;
    private BoxCollider leg;

    public bool isDie = false;

    private void Start()
    {
        head = transform.GetChild(1).GetComponent<BoxCollider>();
        body = transform.GetChild(2).GetComponent<BoxCollider>();
        leg = transform.GetChild(3).GetComponent<BoxCollider>();

        audioSource = this.GetComponent<AudioSource>();
    }

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


    public void AnimStop()
    {
        this.animator.StopPlayback();
    }
    public void Idle()
    {
        //Debug.Log("idle..");
        isUpper = false;
        isCrouch = false;
        isBlock = false;
        state = State.idle;
        atkPower = 0;

        //애니메이션
        this.animator.SetBool("leftAtk", false);
        this.animator.SetBool("walkBack", false);
        this.animator.SetBool("walkFront", false);
        
    }
    public void WalkBack(int PlayerNum)
    {
        if (!isAtk || !isBlock)
        {
            //Debug.Log("walk_back..");
            state = State.walk_back;
            //애니메이션
            
            this.animator.SetBool("walkBack", true);

            //플레이어1
            if (PlayerNum == 0)
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
            //애니메이션
            
            this.animator.SetBool("walkFront", true);

            //플레이어1
            if (PlayerNum == 0)
            {
                transform.position += new Vector3(1, 0, 0) * speed * 1.5f * Time.deltaTime;
            }
            //플레이어2
            else if (PlayerNum == 1)
            {
                transform.position += new Vector3(-1, 0, 0) * speed * 1.5f * Time.deltaTime;
            }
        }
    }

    public void HighPunch(int LRNum)
    {
        //Debug.Log("highPunch..");
        isAtk = true;
        //애니메이션
        this.animator.SetTrigger("hPunch");

        //효과음
        audioSource.clip = audioClips[0];

        if (LRNum == 1)
        {
            state = State.hp_right;
            this.animator.SetBool("leftAtk", true);
            atkPower = 5;
            StopAllCoroutines();
            StartCoroutine(DoAttack(0.7f));
        }
        
        if(LRNum == 0)
        {
            state = State.hp_left;
            atkPower = 4;
            StopAllCoroutines();
            StartCoroutine(DoAttack(0.5f));
        }
    }

    public void Punch(int LRNum)
    {
        //Debug.Log("Punch..");
        isAtk = true;
        //애니메이션
        this.animator.SetTrigger("bPunch");

        audioSource.clip = audioClips[0];

        if (LRNum == 1)
        {
            state = State.bp_right;
            this.animator.SetBool("leftAtk", true);
            atkPower = 7;
            StopAllCoroutines();
            StartCoroutine(DoAttack(0.6f));
        }
        
        if(LRNum == 0)
        {
            state = State.bp_left;
            atkPower = 6;
            StopAllCoroutines();
            StartCoroutine(DoAttack(0.8f));
        }
    }

    public void HighBlock()
    {
        //Debug.Log("highBlock..");
        isBlock = true;
        state = State.hb_pose;
        //애니메이션
        this.animator.SetTrigger("hBlock");

        audioSource.clip = audioClips[3];

        StopAllCoroutines();
        StartCoroutine(DoBlock());
    }
    public void Block()
    {
        //Debug.Log("block..");
        isBlock = true;
        state = State.bb_pose;
        //애니메이션
        this.animator.SetTrigger("bBlock");

        audioSource.clip = audioClips[3];

        StopAllCoroutines();
        StartCoroutine(DoBlock());

    }
    public void LowBlock()
    {
        //Debug.Log("lowBlock..");
        isBlock = true;
        state = State.lb_pose;
        //애니메이션
        this.animator.SetTrigger("lBlock");

        audioSource.clip = audioClips[3];

        StopAllCoroutines();
        StartCoroutine(DoBlock());
    }

    public void HighKick(int LRNum)
    {

        //Debug.Log("highKick..");
        isAtk = true;
        //애니메이션
        this.animator.SetTrigger("hKick");

        audioSource.clip = audioClips[1];

        if (LRNum == 1)
        {
            state = State.hk_right;
            //애니메이션
            this.animator.SetBool("leftAtk", true);
            atkPower = 18;
            StopAllCoroutines();
            StartCoroutine(DoAttack(1.0f));
        }
        
        if(LRNum == 0)
        {
            state = State.hk_left;
            atkPower = 15;
            StopAllCoroutines();
            StartCoroutine(DoAttack(1.0f));
        }
    }
    public void Kick(int LRNum)
    {
        //Debug.Log("kick..");
        isAtk = true;
        //애니메이션
        this.animator.SetTrigger("bKick");

        if (LRNum == 1)
        {
            state = State.bk_right;
            //애니메이션
            this.animator.SetBool("leftAtk", true);
            atkPower = 13;

            audioSource.clip = audioClips[2];

            StopAllCoroutines();
            StartCoroutine(DoAttack(0.6f));
        }
        
        if(LRNum == 0)
        {
            state = State.bk_left;
            atkPower = 10;

            audioSource.clip = audioClips[1];

            StopAllCoroutines();
            StartCoroutine(DoAttack(0.5f));
        }
    }
    public void LowKick(int LRNum)
    {
        //Debug.Log("lowKick..");
        isAtk = true;
        //애니메이션
        this.animator.SetTrigger("lKick");

        if (LRNum == 1)
        {
            //애니메이션
            this.animator.SetBool("leftAtk", true);

            state = State.lk_right;
            atkPower = 9;

            audioSource.clip = audioClips[2];

            StopAllCoroutines();
            StartCoroutine(DoAttack(0.6f));
        }
        
        if(LRNum == 0)
        {
            state = State.lk_left;
            atkPower = 6;

            audioSource.clip = audioClips[1];

            StopAllCoroutines();
            StartCoroutine(DoAttack(0.3f));
        }
    }

    public void Counter()
    {
        isUpper = false;
        isCrouch = false;
        isBlock = false;
        state = State.Counter;

        //애니메이션
        animator.SetBool("leftAtk", false);
        animator.SetBool("walkBack", false);
        animator.SetBool("walkFront", false);
    }

    public void Die()
    {
        isDie = true;
        head.enabled = false;
        body.enabled = false;
        leg.enabled = false;

        state = State.lose_pose;
        animator.SetTrigger("die");
    }

    public IEnumerator hsDamaged(float sec)
    {
        state = State.hd_pose;
        animator.SetTrigger("hsDamaged");
        yield return new WaitForSeconds(sec);
        if(!isDie)
            head.enabled = true;
        this.Idle();
    }

    public IEnumerator hwDamaged(float sec)
    {
        state = State.hd_pose;
        animator.SetTrigger("hwDamaged");
        yield return new WaitForSeconds(sec);
        if (!isDie)
            head.enabled = true;
        this.Idle();
    }

    public IEnumerator bDamaged(float sec)
    {
        state = State.bd_pose;
        animator.SetTrigger("bDamaged");
        yield return new WaitForSeconds(sec);
        if (!isDie)
            body.enabled = true;
        this.Idle();
    }

    public IEnumerator lDamaged(float sec)
    {
        state = State.ld_pose;
        animator.SetTrigger("lDamaged");
        yield return new WaitForSeconds(sec);
        if (!isDie)
            leg.enabled = true;
        this.Idle();
    }

    IEnumerator DoAttack(float sec)
    {
        audioSource.Play();
        yield return new WaitForSeconds(sec);
        isAtk = false;
        this.Idle();
    }

    IEnumerator DoBlock()
    {
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        isBlock = false;
        this.Idle();
    }
}
