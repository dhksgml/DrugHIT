using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private HitManager hitManager;

    private Player1 p1;
    private Player2 p2;

    private void Start()
    {
        hitManager = GameObject.Find("hitManager").GetComponent<HitManager>();
        p1 = GameObject.FindGameObjectWithTag("p1").GetComponent<Player1>();
        p2 = GameObject.FindGameObjectWithTag("p2").GetComponent<Player2>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //player1
        if (this.gameObject.layer == 6)
        {
            if (this.CompareTag("head") && (p2.state == State.hp_left || p2.state == State.hp_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R")
                {
                    //1p 막기 성공
                    if(p1.state == State.hb_pose)
                    {
                        p1.isUpper = false;
                        p1.isCrouch = false;
                        p1.isBlock = false;
                        p1.state = State.hg_pose;

                        //애니메이션
                        p1.animator.SetBool("leftAtk", false);
                        p1.animator.SetBool("walkBack", false);
                        p1.animator.SetBool("walkFront", false);

                        hitManager.isHeadWeakHit2 = true;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isHeadWeakHit1 = true;
                    }
                }
            }
            
            if (this.CompareTag("head") && (p2.state == State.hk_left || p2.state == State.hk_right))
            {
                if (other.name == "foot.L" || other.name == "foot.R")
                {
                    if(p1.state == State.hb_pose)
                    {
                        p1.isUpper = false;
                        p1.isCrouch = false;
                        p1.isBlock = false;
                        p1.state = State.hg_pose;

                        //애니메이션
                        p1.animator.SetBool("leftAtk", false);
                        p1.animator.SetBool("walkBack", false);
                        p1.animator.SetBool("walkFront", false);

                        hitManager.isHeadStrongHit2 = true;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isHeadStrongHit1 = true;
                    }
                }
            }

            if (this.CompareTag("body") && (p2.state == State.bp_left || p2.state == State.bp_right || p2.state == State.bk_left || p2.state == State.bk_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    if (p1.state == State.bb_pose)
                    {
                        p1.isUpper = false;
                        p1.isCrouch = false;
                        p1.isBlock = false;
                        p1.state = State.hg_pose;

                        //애니메이션
                        p1.animator.SetBool("leftAtk", false);
                        p1.animator.SetBool("walkBack", false);
                        p1.animator.SetBool("walkFront", false);

                        hitManager.isBodyHit2 = true;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isBodyHit1 = true;
                    }
                }
            }
            
            if (this.CompareTag("leg") && (p2.state == State.lk_left || p2.state == State.lk_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    if (p1.state == State.lb_pose)
                    {
                        p1.isUpper = false;
                        p1.isCrouch = false;
                        p1.isBlock = false;
                        p1.state = State.hg_pose;

                        //애니메이션
                        p1.animator.SetBool("leftAtk", false);
                        p1.animator.SetBool("walkBack", false);
                        p1.animator.SetBool("walkFront", false);

                        hitManager.isLegHit2 = true;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isLegHit1 = true;
                    }
                }
            }
        }
        //player2
        if (this.gameObject.layer == 7)
        {
            if (this.CompareTag("head") && (p1.state == State.hp_left || p1.state == State.hp_right))
            {
                
                if (other.name == "hand.L" || other.name == "hand.R")
                {

                    this.GetComponent<BoxCollider>().enabled = false;
                    hitManager.isHeadWeakHit2 = true;
                }
            }
            
            if (this.CompareTag("head") && (p1.state == State.hk_left || p1.state == State.hk_right))
            {
                if (other.name == "foot.L" || other.name == "foot.R")
                {

                    this.GetComponent<BoxCollider>().enabled = false;
                    hitManager.isHeadStrongHit2 = true;
                }
            }

            if (this.CompareTag("body") && (p1.state == State.bp_left || p1.state == State.bp_right || p1.state == State.bk_left || p1.state == State.bk_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    hitManager.isBodyHit2 = true;
                }
            }
            
            if (this.CompareTag("leg") && (p1.state == State.lk_left || p1.state == State.lk_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    
                    this.GetComponent<BoxCollider>().enabled = false;
                    hitManager.isLegHit2 = true;
                }
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{   
    //    //player1
    //    if (this.gameObject.layer == 6)
    //    {
    //        if (this.CompareTag("head"))
    //        {
    //            if(other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
    //                hitManager.isHeadHit1 = false;
    //        }
    //        else if (this.CompareTag("body"))
    //        {
    //            if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
    //                hitManager.isBodyHit1 = false;
    //        }
    //        else if (this.CompareTag("leg"))
    //        {
    //            if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
    //                hitManager.isLegHit1 = false;
    //        }
    //    }
    //    //player2
    //    if (this.gameObject.layer == 7)
    //    {
    //        if (this.CompareTag("head"))
    //        {
    //            if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
    //                hitManager.isHeadHit2 = false;
    //        }
    //        else if (this.CompareTag("body"))
    //        {
    //            if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
    //                hitManager.isBodyHit2 = false;
    //        }
    //        else if (this.CompareTag("leg"))
    //        {
    //            if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
    //                hitManager.isLegHit2 = false;
    //        }
    //    }
    //}
}
