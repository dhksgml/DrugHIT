using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private HitManager hitManager;

    private void Start()
    {
        hitManager = GameObject.Find("hitManager").GetComponent<HitManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //player1
        if (this.gameObject.layer == 6)
        {
            if (this.CompareTag("head"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    hitManager.isHeadHit1 = true;
                    this.GetComponent<BoxCollider>().enabled = false;
                }
            }
            
            if (this.CompareTag("body"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    hitManager.isBodyHit1 = true;
                    this.GetComponent<BoxCollider>().enabled = false;
                }
            }
            
            if (this.CompareTag("leg"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    hitManager.isLegHit1 = true;
                    this.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
        //player2
        else if (this.gameObject.layer == 7)
        {
            if (this.CompareTag("head"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    hitManager.isHeadHit2 = true;
                    this.GetComponent<BoxCollider>().enabled = false;
                }
            }
            
            if (this.CompareTag("body"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    hitManager.isBodyHit2 = true;
                    this.GetComponent<BoxCollider>().enabled = false;
                }
            }
            
            if (this.CompareTag("leg"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                {
                    hitManager.isLegHit2 = true;
                    this.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {   
        //player1
        if (this.gameObject.layer == 6)
        {
            if (this.CompareTag("head"))
            {
                if(other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                    hitManager.isHeadHit1 = false;
            }
            else if (this.CompareTag("body"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                    hitManager.isBodyHit1 = false;
            }
            else if (this.CompareTag("leg"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                    hitManager.isLegHit1 = false;
            }
        }
        //player2
        if (this.gameObject.layer == 7)
        {
            if (this.CompareTag("head"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                    hitManager.isHeadHit2 = false;
            }
            else if (this.CompareTag("body"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                    hitManager.isBodyHit2 = false;
            }
            else if (this.CompareTag("leg"))
            {
                if (other.name == "hand.L" || other.name == "hand.R" || other.name == "foot.L" || other.name == "foot.R")
                    hitManager.isLegHit2 = false;
            }
        }
    }
}
