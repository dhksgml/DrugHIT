using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    public Animator animator;

    public void InitAnimIdle()
    {
        this.animator.SetBool("walkBack", false);
        this.animator.SetBool("walkFront", false);
    }

    public void InitAnimWalkFront()
    {
        this.animator.SetBool("walkBack", false);
        this.animator.SetBool("walkFront", true);
    }

    public void InitAnimWalkBack()
    {
        this.animator.SetBool("walkBack", true);
        this.animator.SetBool("walkFront", false);
    }

    public void InitAnimHPunch()
    {
        this.animator.SetBool("leftAtk", false);
    }

    public void InitAnimBKick()
    {
        this.animator.SetBool("leftAtk", false);
    }
}
