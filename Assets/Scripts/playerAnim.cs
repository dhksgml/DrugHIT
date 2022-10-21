using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    public Animator anim;
    public playerController playerController;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerController = GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim_check();

        if(playerController.playerState == PlayerStates.Kick && !playerController.isAttack)
        {
            LKick_Anim();
        }
        else if(playerController.playerState == PlayerStates.Kick && playerController.isAttack)
        {
            RKick_Anim();
        }
    }

    public void LKick_Anim()
    {
        anim.SetTrigger("Lkick");
    }

    public void RKick_Anim()
    {
        anim.SetTrigger("Rkick");
    }

    public void Anim_check()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("left_kick") || anim.GetCurrentAnimatorStateInfo(0).IsName("right_kick"))
        {
            playerController.isAttack = true;
        }
        else
        {
            playerController.isAttack = false;
        }
    }
}
