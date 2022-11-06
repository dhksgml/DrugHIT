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
        animator.SetBool("idle", true);
    }

    public void InitAnimIWalkFront()
    {
        animator.SetBool("walkBack", false);
        animator.SetBool("walkFront", true);
        animator.SetBool("idle", false);
    }

    public void InitAnimIWalkBack()
    {
        animator.SetBool("walkBack", true);
        animator.SetBool("walkFront", false);
        animator.SetBool("idle", false);
    }
}
