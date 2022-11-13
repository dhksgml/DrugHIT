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
                        p1.Counter();
                        hitManager.isHeadStrongHit2 = true;
                        //막기 성공 시, 2p 공격력 반사
                        p2.curHP -= p2.atkPower;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isHeadWeakHit1 = true;

                        //1p 체력 소모
                        p1.curHP -= p2.atkPower;

                    }
                }
            }
            
            if (this.CompareTag("head") && (p2.state == State.hk_left || p2.state == State.hk_right))
            {
                if (other.name == "foot.L" || other.name == "foot.R")
                {
                    if(p1.state == State.hb_pose)
                    {
                        p1.Counter();
                        hitManager.isHeadStrongHit2 = true;
                        p2.curHP -= p2.atkPower;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isHeadStrongHit1 = true;
                        p1.curHP -= p2.atkPower;
                    }
                }
            }

            if (this.CompareTag("body") && (p2.state == State.bp_left || p2.state == State.bp_right || p2.state == State.bk_left || p2.state == State.bk_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    if (p1.state == State.bb_pose)
                    {
                        p1.Counter();
                        hitManager.isHeadStrongHit2 = true;
                        p2.curHP -= p2.atkPower;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isBodyHit1 = true;
                        p1.curHP -= p2.atkPower;
                    }
                }
            }
            
            if (this.CompareTag("leg") && (p2.state == State.lk_left || p2.state == State.lk_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    if (p1.state == State.lb_pose)
                    {
                        p1.Counter();
                        hitManager.isHeadStrongHit2 = true;
                        p2.curHP -= p2.atkPower;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isLegHit1 = true;
                        p1.curHP -= p2.atkPower;
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
                    //2p 막기 성공
                    if (p2.state == State.hb_pose)
                    {
                        p2.Counter();
                        hitManager.isHeadStrongHit1 = true;
                        p1.curHP -= p1.atkPower;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isHeadWeakHit2 = true;
                        p2.curHP -= p1.atkPower;
                    }
                }
            }
            
            if (this.CompareTag("head") && (p1.state == State.hk_left || p1.state == State.hk_right))
            {
                if (other.name == "foot.L" || other.name == "foot.R")
                {
                    //2p 막기 성공
                    if (p2.state == State.hb_pose)
                    {
                        p2.Counter();
                        hitManager.isHeadStrongHit1 = true;
                        p1.curHP -= p1.atkPower;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isHeadStrongHit2 = true;
                        p2.curHP -= p1.atkPower;
                    }
                }
            }

            if (this.CompareTag("body") && (p1.state == State.bp_left || p1.state == State.bp_right || p1.state == State.bk_left || p1.state == State.bk_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    //2p 막기 성공
                    if (p2.state == State.bb_pose)
                    {
                        p2.Counter();
                        hitManager.isHeadStrongHit1 = true;
                        p1.curHP -= p1.atkPower;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isBodyHit2 = true;
                        p2.curHP -= p1.atkPower;
                    }
                }
            }
            
            if (this.CompareTag("leg") && (p1.state == State.lk_left || p1.state == State.lk_right))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    //2p 막기 성공
                    if (p2.state == State.lb_pose)
                    {
                        p2.Counter();
                        hitManager.isHeadStrongHit1 = true;
                        p1.curHP -= p1.atkPower;
                    }
                    else
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                        hitManager.isLegHit2 = true;
                        p2.curHP -= p1.atkPower;
                    }
                }
            }
        }

        if (p1.curHP <= 0)
        {
            hitManager.DieP1();
        }

        if (p2.curHP <= 0)
        {
            hitManager.DieP2();
        }
    }

}
