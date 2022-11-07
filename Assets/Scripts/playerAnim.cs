using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    public Animator animator;

    public void InitAnimIdle()
    {
        animator.SetBool("walkBack", false);
        animator.SetBool("walkFront", false);
    }

    public void InitAnimWalkFront()
    {
        animator.SetBool("walkBack", false);
        animator.SetBool("walkFront", true);
    }

    public void InitAnimWalkBack()
    {
        animator.SetBool("walkBack", true);
        animator.SetBool("walkFront", false);
    }

    public void InitAnimHPunch()
    {
        animator.SetBool("leftAtk", false);
    }

    public void InitAnimBKick()
    {
        animator.SetBool("leftAtk", false);
    }
}
